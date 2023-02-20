namespace LangtonAnt
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Langton Ant game.");

            LangtonAnt ant = new LangtonAnt(100, 100);

            while (!ant.OutOfBounds)
            {
                ant.Step();
            }

            for (int row = 0; row < 100; row++)
            {
                for (int col = 0; col < 100; col++)
                {
                    Console.Write(ant.IsBlack[col, row] ? "#" : "-");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Thanks for playing our game.");
        }
    }
}



