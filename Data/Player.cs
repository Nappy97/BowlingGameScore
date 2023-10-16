using static BowlingGame.Data.ScoringType;

namespace BowlingGame.Data;

public class Player
{
    // Player 구분
    public int PlayerId { get; }

    // 총합 스코어
    public int TotalScore { get; set; }

    // 각 회의 스코어
    public List<Frame> Frames = new();

    public Player(int playerId)
    {
        PlayerId = playerId;
        Frames.AddRange(Enumerable.Range(1, 10).Select(_ => new Frame()));
    }

    public void AddFrameResult(Frame frame)
    {
        Frames[frame.FrameId - 1] = frame;
    }

    public void AddTotalResult()
    {
        TotalScore = Frames.Sum(frame => frame.TotalScore);
    }

    public void CalculateEachFrame(Player player)
    {
        for (var i = 0; i < player.Frames.Count; i++)
        {
            switch (player.Frames[i].ScoringType)
            {
                // 스트라이크이고, 다음회도 스트라이크일경우
                case STRIKE when player.Frames[i + 1].ScoringType == STRIKE:
                    player.Frames[i].TotalScore = player.Frames[i].TotalScore + player.Frames[i + 1].FirstScore +
                                                  player.Frames[i + 2].FirstScore;
                    break;
                // 스트라이크 이고, 9회일때
                case STRIKE when player.Frames[i + 1].ThirdScore != 0:
                    player.Frames[i].TotalScore += player.Frames[i + 1].FirstScore + player.Frames[i + 1].SecondScore;
                    break;
                case STRIKE:
                    player.Frames[i].TotalScore += player.Frames[i + 1].TotalScore;
                    break;
                case SPARE:
                    player.Frames[i].TotalScore += player.Frames[i + 1].FirstScore;
                    break;
                default:
                    player.Frames[i].TotalScore = player.Frames[i].TotalScore;
                    break;
            }
        }
    }
}