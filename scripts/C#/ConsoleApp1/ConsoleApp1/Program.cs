using TILE_MANAGER;
using BORAD_CONFIG;
using ErrorHandling;

namespace HelloWorld
{
    class Hello
    {
        public static Borad borad = new Borad();
        public static debugManager debugManager = new debugManager();

        static void Main(string[] args)
        {
            
            //Menu();
            newG();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Checkers!");
            Console.WriteLine("\n");
            Console.WriteLine("would you like to: ");
            Console.WriteLine("1. New game ");
            Console.WriteLine("2. Exit ");
            Console.WriteLine("\n");
            Console.Write("=> ");
            int ui = Convert.ToInt32(Console.Read());
            if (ui == 1) newG();
        }

        private static void newG()
        {
           
            borad.newB();
            borad.placeP();
            borad.printB();
            borad.turn();
           
        }

        
        
    }
}