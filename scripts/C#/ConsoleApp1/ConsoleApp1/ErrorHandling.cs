using TILE_MANAGER;
using BORAD_CONFIG;

namespace ErrorHandling
{
    
    public class errorManager
    {
        public static Borad borad = new Borad();

        public bool inRange(int x, int y)
        {
            int current = (y * 8) + x;

            if (current > 64) { return false; }
            if (borad.tile[current] != tileTypes.BoardTileB && borad.tile[current] != tileTypes.BoardTileW) { return true; }
            else return false;
        }

        public bool onEnd(int pos)
        {
            int current = (pos % 8);
            if (current == 0 || current == 7) return true;
            else return false;

        }

        public void didWin()
        {

        }

    }

    public class debugManager
    {
        public static Borad borad = new Borad();
        public string[] player = { tileTypes.P1, tileTypes.P2} ;
        public int[] pos = new int[100];
        public bool curTurn = borad.p2Turn;
        public int i = 0;

        public void storeP()
        {
            for( i = 0; i < 63; i++)
            {
                
                if (borad.tile[i] == player[1]) pos[i] = 1;
                else if (borad.tile[i] == player[2]) pos[i] = 2;
                else pos[i] = 0;
            }
        }

        public void loadP(bool print)
        {
            for (int i = 0; i < 63; i++)
            {
                if (pos[i] == 1) borad.tile[i] = player[1];
                else if (pos[i] == 2) borad.tile[i] = player[2];
                else borad.tile[i] = borad.tile[i];
            }
            borad.p2Turn = curTurn;
            if (print) borad.printB();
        }
                
    }
}
