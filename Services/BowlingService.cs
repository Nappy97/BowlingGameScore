using BowlingGame.Data;
using static BowlingGame.Data.ScoringType;

namespace BowlingGame.Services;

public class BowlingService
{
    public void InputGameScore(Player player, int frameIdx)
    {
        Console.WriteLine($"{frameIdx}번 프레임입니다.");
        Console.WriteLine($"{player.PlayerId}번 플레이어의 첫번째 결과를 입력해주세요");


        var firstScore = int.Parse(Console.ReadLine());
        // var playerFrame = player.Frames[frameIdx - 1];

        // 첫번째 결과저장
        var playerFrame = new Frame(frameIdx, firstScore);
        if (playerFrame.ScoringType == STRIKE)
        {
            Console.WriteLine("스트라이크!");
        }
        else
        {
            Console.WriteLine($"{player.PlayerId}번 플레이어의 두번째 결과를 입력해주세요");
            var secondScore = int.Parse(Console.ReadLine());

            // 두번째 결과 저장
            playerFrame.InputSecondResult(secondScore);

            // 두결과 합계
            var totalScore = firstScore + secondScore;

            if (playerFrame.ScoringType == SPARE)
            {
                Console.WriteLine("스페어");
            }

            // 스페어처리 실패시
            playerFrame.TotalScore = totalScore;
        }

        player.AddFrameResult(playerFrame);

        // 이전에 스트라이크 친 기록이 있는지, 있다면 현재는 점수를 낼 수 있는지 판단 후 저장
        var hasStrikeBefore = HasStrikeBefore(player, frameIdx, out var totalResult, out var resultFrameIdx);

        if (!hasStrikeBefore) return;

        var frame = PlayerFrame(player, resultFrameIdx + 1);
        frame.TotalScore = totalResult;
        Console.WriteLine($"{player.PlayerId}의 {frameIdx}까지의 점수합계는 {frame.TotalScore}");
    }

    // 총합을 낼 수 있는지를 계산
    private bool HasStrikeBefore(Player player, int frameIdx, out int totalResult, out int resultFrameIdx)
    {
        totalResult = 0;
        resultFrameIdx = 0;

        // 프레임이 1회면 무시 
        if (frameIdx <= 1)
            return false;

        // 검사할 프레임의 이전 프레임부터 역순으로 찾으면서 스트라이크가 있는지 확인
        for (var i = frameIdx - 2; i >= 0; i--)
        {
            var currentFrame = PlayerFrame(player, i + 1);
            resultFrameIdx = i;

            // 해당 프레임이 스트라이크라면
            // 아직 2번굴리기전이라면 무시하는 로직
            if (currentFrame.ScoringType == STRIKE && IsGameInProgress(player, i))
            {
                // 해당 프레임 + 1 회도 스트라이크인 경우, 다음회 첫타를 가져온다
                var currentFrameAndNextFrameFirstScore =
                    currentFrame.FirstScore + PlayerFrame(player, i + 1).FirstScore;
                if (PlayerFrame(player, i + 1).ScoringType == STRIKE)
                {
                    totalResult = currentFrameAndNextFrameFirstScore + PlayerFrame(player, i + 2).FirstScore;
                }
                // 해당 프레임 +1 회가 스트라이크가 아닌 경우 그 회의 첫타와 두번째 타 결과 저장

                totalResult = currentFrameAndNextFrameFirstScore + PlayerFrame(player, i + 1).SecondScore;

                // totalResult가 0이 아니면 루프를 종료하고 true를 반환
                if (totalResult != 0)
                    return true;
            }

            // 스페어라면 
            else if (currentFrame.ScoringType == SPARE)
            {
                totalResult = 10 + PlayerFrame(player, i).FirstScore;

                // totalResult가 0이 아니면 루프를 종료하고 true를 반환
                if (totalResult != 0)
                    return true;
            }
        }

        return false;
    }

    // 스트라이크 가 있는 프레임의 점수를 계산할만큼 게임이 진행되었는지 판단하는 메소드
    private bool IsGameInProgress(Player player, int frameIdx)
    {
        if (frameIdx <= 0)
        {
            return PlayerFrame(player, frameIdx + 2).FirstScore != 10;
        }

        // TODO 전제조건이 뭔가 잘못됨 
        return PlayerFrame(player, frameIdx + 1).ScoringType != NOT_YET ||
               PlayerFrame(player, frameIdx).SecondScore != 0;
    }

    // 프레임 내역을 얻는법
    private Frame PlayerFrame(Player player, int frameIdx)
    {
        return player.Frames[frameIdx - 1];
    }

    public (Player winner, int scoreDiff) CalculateScoreBoard(List<Player> players)
    {
        foreach (var player in players)
        {
            player.AddTotalResult();
        }

        var winner = players[0].TotalScore > players[1].TotalScore ? players[0] : players[1];
        var loser = players[0].TotalScore > players[1].TotalScore ? players[1] : players[0];
        var scoreDiff = Math.Abs(winner.TotalScore - loser.TotalScore);

        return (winner, scoreDiff);
    }
}