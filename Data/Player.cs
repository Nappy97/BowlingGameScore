using static BowlingGame.Data.ScoringType;

namespace BowlingGame.Data;

public class Player
{
    // Player 구분
    public int PlayerId { get; }

    // 총합 스코어
    public int TotalScore { get; private set; }

    // 각 회의 스코어
    public List<Frame> _Frames = new();

    public Player(int playerId)
    {
        PlayerId = playerId;
        _Frames.AddRange(Enumerable.Range(1, 10).Select(_ => new Frame()));
    }

    public void AddFrameResult(Frame frame)
    {
        _Frames[frame.FrameId - 1] = frame;
    }

    public void AddTotalResult()
    {
        TotalScore = _Frames.Sum(frame => frame.TotalScore);
    }

    public void CalculateEachFrame(Player player)
    {
        for (var i = 0; i < player._Frames.Count; i++)
        {
            switch (player._Frames[i].ScoringType)
            {
                // 스트라이크이고, 다음회도 스트라이크일경우
                case Strike when player._Frames[i + 1].ScoringType == Strike:
                    player._Frames[i].TotalScore = player._Frames[i].TotalScore + player._Frames[i + 1].FirstScore +
                                                  player._Frames[i + 2].FirstScore;
                    break;
                // 스트라이크 이고, 9회일때
                case Strike when player._Frames[i + 1].ThirdScore != 0:
                    player._Frames[i].TotalScore += player._Frames[i + 1].FirstScore + player._Frames[i + 1].SecondScore;
                    break;
                case Strike:
                    player._Frames[i].TotalScore += player._Frames[i + 1].TotalScore;
                    break;
                case Spare:
                    player._Frames[i].TotalScore += player._Frames[i + 1].FirstScore;
                    break;
                default:
                    player._Frames[i].TotalScore = player._Frames[i].TotalScore;
                    break;
            }
        }
    }
}