using BowlingGame.Data;
using BowlingGame.Services;

namespace BowlingGame;

// 실행
class Program
{
    static void Main(string[] args)
    {
        var bowlingService = new BowlingService();
        const int TotalFrames = 10;
        Console.WriteLine("게임을 시작합니다.");
        var players = new List<Player>
        {
            new(1),
            new(2)
        };


        for (var frameIdx = 1; frameIdx <= TotalFrames; frameIdx++)
        {
            foreach (var player in players)
            {
                bowlingService.InputGameScore(player, frameIdx);
            }
        }

        var calculateScoreBoard = bowlingService.CalculateScoreBoard(players);

        DisplayScore(players[0], players[1]);
        Console.WriteLine(
            $"승자는 {calculateScoreBoard.winner.PlayerId}번 플레이어 이며, 점수차이는 {calculateScoreBoard.scoreDiff}점 입니다.");
    }

    // 점수판을 표시하는 메소드 
    // 점수판을 표시하는 메소드 
    static void DisplayScore(Player firstP, Player secondP)
    {
        Console.WriteLine(
            "==================================================================================================================================");
        Console.WriteLine(
            "|   G   ||     1     |     2     |     3     |     4     |     5     |     6     |     7     |     8     |     9     |     10     |");
        Console.WriteLine(
            "----------------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine(
            $"|  1P   ||   {firstP._Frames[0].FirstScore}/{firstP._Frames[0].SecondScore}    |   {firstP._Frames[1].FirstScore}/{firstP._Frames[1].SecondScore}    |   {firstP._Frames[2].FirstScore}/{firstP._Frames[2].SecondScore}    |   {firstP._Frames[3].FirstScore}/{firstP._Frames[3].SecondScore}    |   {firstP._Frames[4].FirstScore}/{firstP._Frames[4].SecondScore}    |   {firstP._Frames[5].FirstScore}/{firstP._Frames[5].SecondScore}    |   {firstP._Frames[6].FirstScore}/{firstP._Frames[6].SecondScore}    |   {firstP._Frames[7].FirstScore}/{firstP._Frames[7].SecondScore}    |   {firstP._Frames[8].FirstScore}/{firstP._Frames[8].SecondScore}    |   {firstP._Frames[9].FirstScore}/{firstP._Frames[9].SecondScore}/{firstP._Frames[9].ThirdScore}    |    합계    |");
        Console.WriteLine(
            $"|       ||    {firstP._Frames[0].TotalScore}     |    {firstP._Frames[1].TotalScore}     |    {firstP._Frames[2].TotalScore}     |    {firstP._Frames[3].TotalScore}     |    {firstP._Frames[4].TotalScore}     |    {firstP._Frames[5].TotalScore}     |    {firstP._Frames[6].TotalScore}     |    {firstP._Frames[7].TotalScore}     |     {firstP._Frames[8].TotalScore}     |     {firstP._Frames[9].TotalScore}     |    {firstP.TotalScore}    |");
        Console.WriteLine(
            $"|  2P   ||   {secondP._Frames[0].FirstScore}/{secondP._Frames[0].SecondScore}    |   {secondP._Frames[1].FirstScore}/{secondP._Frames[1].SecondScore}    |   {secondP._Frames[2].FirstScore}/{secondP._Frames[2].SecondScore}    |   {secondP._Frames[3].FirstScore}/{secondP._Frames[3].SecondScore}    |   {secondP._Frames[4].FirstScore}/{secondP._Frames[4].SecondScore}    |   {secondP._Frames[5].FirstScore}/{secondP._Frames[5].SecondScore}    |   {secondP._Frames[6].FirstScore}/{secondP._Frames[6].SecondScore}    |   {secondP._Frames[7].FirstScore}/{secondP._Frames[7].SecondScore}    |   {secondP._Frames[8].FirstScore}/{secondP._Frames[8].SecondScore}    |   {secondP._Frames[9].FirstScore}/{secondP._Frames[9].SecondScore}/{secondP._Frames[9].ThirdScore}    |    합계    |");
        Console.WriteLine(
            $"|       ||    {secondP._Frames[0].TotalScore}     |    {secondP._Frames[1].TotalScore}     |    {secondP._Frames[2].TotalScore}     |    {secondP._Frames[3].TotalScore}     |    {secondP._Frames[4].TotalScore}     |    {secondP._Frames[5].TotalScore}     |    {secondP._Frames[6].TotalScore}     |    {secondP._Frames[7].TotalScore}     |     {secondP._Frames[8].TotalScore}     |     {secondP._Frames[9].TotalScore}     |    {secondP.TotalScore}    |");
        Console.WriteLine(
            "==================================================================================================================================");
    }
}