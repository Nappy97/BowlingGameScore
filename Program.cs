namespace BowlingGame;

// 실행
class Program
{
    static void Main(string[] args)
    {
        const int TotalFrames = 10;
        Console.WriteLine("게임을 시작합니다.");
        var p1 = new Player();
        var p2 = new Player();

        for (var frame = 1; frame <= TotalFrames; frame++)
        {
            p1.PlayFrame(frame);
            p1.CalculateScore(frame);
            DisplayScore(p1, p2);
            p2.PlayFrame(frame);
            p2.CalculateScore(frame);
            DisplayScore(p1, p2);
        }
    }

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
            $"|  1P   ||   {firstP._scores[0]._fisrtScore}/{firstP._scores[0]._secondScore}    |   {firstP._scores[1]._fisrtScore}/{firstP._scores[1]._secondScore}    |   {firstP._scores[2]._fisrtScore}/{firstP._scores[2]._secondScore}    |   {firstP._scores[3]._fisrtScore}/{firstP._scores[3]._secondScore}    |   {firstP._scores[4]._fisrtScore}/{firstP._scores[4]._secondScore}    |   {firstP._scores[5]._fisrtScore}/{firstP._scores[5]._secondScore}    |   {firstP._scores[6]._fisrtScore}/{firstP._scores[6]._secondScore}    |   {firstP._scores[7]._fisrtScore}/{firstP._scores[7]._secondScore}    |   {firstP._scores[8]._fisrtScore}/{firstP._scores[8]._secondScore}    |   {firstP._scores[9]._fisrtScore}/{firstP._scores[9]._secondScore}    |");
        Console.WriteLine(
            $"|       ||    {firstP._totalScore}     |    {firstP._totalScore}     |    {firstP._totalScore}     |    {firstP._totalScore}     |    {firstP._totalScore}     |    {firstP._totalScore}     |    {firstP._totalScore}     |    {firstP._totalScore}     |    {firstP._totalScore}     |    {firstP._totalScore}     |");
        Console.WriteLine(
            $"|  1P   ||   {secondP._scores[0]._fisrtScore}/{secondP._scores[0]._secondScore}    |   {secondP._scores[1]._fisrtScore}/{secondP._scores[1]._secondScore}    |   {secondP._scores[2]._fisrtScore}/{secondP._scores[2]._secondScore}    |   {secondP._scores[3]._fisrtScore}/{secondP._scores[3]._secondScore}    |   {secondP._scores[4]._fisrtScore}/{secondP._scores[4]._secondScore}    |   {secondP._scores[5]._fisrtScore}/{secondP._scores[5]._secondScore}    |   {secondP._scores[6]._fisrtScore}/{secondP._scores[6]._secondScore}    |   {secondP._scores[7]._fisrtScore}/{secondP._scores[7]._secondScore}    |   {secondP._scores[8]._fisrtScore}/{secondP._scores[8]._secondScore}    |   {secondP._scores[9]._fisrtScore}/{secondP._scores[9]._secondScore}    |");
        Console.WriteLine(
            $"|       ||    {secondP._totalScore}     |    {secondP._totalScore}     |    {secondP._totalScore}     |    {secondP._totalScore}     |    {secondP._totalScore}     |    {secondP._totalScore}     |    {secondP._totalScore}     |    {secondP._totalScore}     |    {secondP._totalScore}     |    {secondP._totalScore}     |");
        Console.WriteLine(
            "==================================================================================================================================");
    }
}


// Console.WriteLine("==================================================================================================================================");
// Console.WriteLine("|   G   ||     1     |     1     |     1     |     1     |     1     |     1     |     1     |     1     |     1     |     1     |");
// Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");
// Console.WriteLine("|  1P   ||   10/2    |   3       |  3        |  4        |  5        |  6        |  7        |  8        |  9        |  10       |");
// Console.WriteLine("|       ||    10     |   3       |  3        |  4        |  5        |  6        |  7        |  8        |  9        |  10       |");
// Console.WriteLine("|  2P   ||   1/2     |   3       |  3        |  4        |  5        |  6        |  7        |  8        |  9        |  10       |");
// Console.WriteLine("|       ||    10     |   3       |  3        |  4        |  5        |  6        |  7        |  8        |  9        |  10       |");
// Console.WriteLine("==================================================================================================================================");