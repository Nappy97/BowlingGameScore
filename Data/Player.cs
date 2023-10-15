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
}