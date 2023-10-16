using static BowlingGame.Data.ScoringType;

namespace BowlingGame.Data;

public class Frame
{
    public int FrameId { get; }
    public int FirstScore { get; }
    public int SecondScore { get; set; }

    // 10회에만 -> 10회에 2번던져서 스페어 혹은 스트라이크 처리시에 마지막 보너스를 던질 기회가 생김
    public int ThirdScore { get; set; }
    public int TotalScore { get; set; }

    public ScoringType ScoringType { get; set; }

    public Frame()
    {
        ScoringType = NotYet;
    }

    // 스트라이크의 경우
    public Frame(int frameId, int firstScore)
    {
        FrameId = frameId;
        FirstScore = firstScore;
        ScoringType = firstScore == 10 ? Strike : None;
    }

    // 두번째 결과 저장
    public void InputSecondResult(int secondScore)
    {
        SecondScore = secondScore;
        ScoringType = FirstScore + secondScore == 10 ? Spare : None;
    }

    public void CalculateFrameResult()
    {
        TotalScore = FirstScore + SecondScore + ThirdScore;
    }
}