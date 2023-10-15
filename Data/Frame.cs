﻿using static BowlingGame.Data.ScoringType;

namespace BowlingGame.Data;

public class Frame
{
    public int FrameId { get; }
    public int FirstScore { get; }
    public int SecondScore { get; set; }
    public int TotalScore { get; set; }

    public ScoringType ScoringType { get; set; }

    public Frame()
    {
        ScoringType = ScoringType.NOT_YET;
    }
    
    // 스트라이크의 경우
    public Frame(int frameId, int firstScore)
    {
        FrameId = frameId;
        FirstScore = firstScore;
        ScoringType = firstScore == 10 ? STRIKE : NONE;
    }

    // 두번째 결과 저장
    public void InputSecondResult(int secondScore)
    {
        SecondScore = secondScore;
        ScoringType = FirstScore + secondScore == 10 ? SPARE : NONE;
    }

    // 스트라이크 여부
    public bool IsStrike()
    {
        return FirstScore == 10;
    }
    
    // 스페어여부
    public bool IsSpare()
    {
        return FirstScore + SecondScore == 10;
    }
}