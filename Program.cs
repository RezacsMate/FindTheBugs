namespace FindTheBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DiceGame game = new DiceGame();
            Console.WriteLine("Choose the difficulty:\nEasy - 1\nNormal - 3\nHard - 3");
            switch (Console.ReadLine())
            {
                case "1": game.SetUpGame(1); break;
                case "2": game.SetUpGame(2); break;
                case "3": game.SetUpGame(2); break;
                default: game.SetUpGame(2); break;
            }
            game.Play();

            Console.WriteLine("Game over");
            Console.ReadLine();


        }
    }
}
