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
                Console.WriteLine("스페어!");
            }

            // 스페어처리 실패시
            playerFrame.TotalScore = totalScore;
        }

        // 10회에 스트라이크 혹은 스페어 처리시 보너스 기회가 생김
        if (frameIdx == 10)
        {
            Console.WriteLine($"{frameIdx}프레임에서 첫 두번의 투구에서 스페어 혹은 스트라이크 처리시 보너스를 칠 수 있는 기회가 있습니다. ");
            Console.WriteLine($"{player.PlayerId}번 플레이어의 두번째 결과를 입력해주세요");
            var secondScore = int.Parse(Console.ReadLine());

            // 두번째 결과 저장
            playerFrame.InputSecondResult(secondScore);

            // 두결과 합계
            var totalScore = firstScore + secondScore;

            if (totalScore >= 10)
            {
                Console.WriteLine("Bonus!");
                Console.WriteLine($"{player.PlayerId}번 플레이어의 세번째 결과를 입력해주세요");
                var thirdScore = int.Parse(Console.ReadLine());
                playerFrame.ThirdScore = thirdScore;
            }

            playerFrame.TotalScore = firstScore + secondScore + playerFrame.ThirdScore;
        }

        playerFrame.CalculateFrameResult();
        player.AddFrameResult(playerFrame);
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

    // 보드 총괄계산
    public (Player winner, int scoreDiff) CalculateScoreBoard(List<Player> players)
    {
        foreach (var player in players)
        {
            player.CalculateEachFrame(player);
            player.AddTotalResult();
        }

        var winner = players[0].TotalScore > players[1].TotalScore ? players[0] : players[1];
        var loser = players[0].TotalScore > players[1].TotalScore ? players[1] : players[0];
        var scoreDiff = Math.Abs(winner.TotalScore - loser.TotalScore);

        return (winner, scoreDiff);
    }
}