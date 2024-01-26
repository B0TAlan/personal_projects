using TILE_MANAGER;
using ErrorHandling;

namespace BORAD_CONFIG
{
    public class Borad
    {
        public const int Size = 8;
        public tit[] tiles = new tit[Size * Size];
        public string[] tile = new string[10000];
        public bool p2Turn = false;
        public static debugManager db = new debugManager();
        public static errorManager check = new errorManager();
        public int p1p = 8;
        public int p2p = 8;

        public Borad()
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                //tiles[i] = new tileTypes.BoardTileW;
            }
        }

        public tit GetTile(int x, int y)
        {
            int index = x * (Size + y);
            return tiles[index];
        }

        public void setTile(int x, string t)
        {
            tile[x] = t;
        }

        public void wipe(string a)
        {
            for (int i = 0; i <= (Size*Size)+1; i++)
            {
                tile[i] = a;
            }
        }

        public void newB()
        {
            wipe(tileTypes.BoardTileW);
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    int pos = (y * 8) + x;
                    if ((x + y) % 2 == 0) tile[(y * Size) + x] = tileTypes.BoardTileB;
                    //Console.Write(tit[pos]);
                }
            }

        }

        public void placeP()
        {
            setTile(0, tileTypes.P1);setTile(9, tileTypes.P1);setTile(2, tileTypes.P1); setTile(11, tileTypes.P1);
            setTile(4, tileTypes.P1); setTile(13, tileTypes.P1); setTile(6, tileTypes.P1);  setTile(15, tileTypes.P1);
            //
            setTile(48, tileTypes.P2); setTile(50, tileTypes.P2); setTile(52, tileTypes.P2); setTile(54, tileTypes.P2);
            setTile(57, tileTypes.P2); setTile(59, tileTypes.P2); setTile(61, tileTypes.P2); setTile(63, tileTypes.P2);
        }

        public void Move(int current, int next)
        {
            //int current = (y * 8) + x;
            //int next = (nextY * 8) + nextX;

            bool inRange = false;
            bool empty = false;

            if (tile[next] != null) inRange = true;
            if (tile[next] != tileTypes.P1 || tile[next] != tileTypes.P2) empty = true;
            if (inRange == true && empty == true)
            {
                tile[next] = tile[current];
                tile[current] = tileTypes.BoardTileB;
            }

            printB();

        }

        public void printB()
        {
            Console.Clear();
            Console.WriteLine(" 0  1  2  3  4  5  6  7 \n");
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    int pos = (y * 8) + x;
                    Console.Write(tile[pos]);
                }
                Console.Write(" {0} \n", y);
            }
            //Console.Write("player 1 taken: {0}", (8 - p2p)); Console.Write("| player 2 taken: {0}\n", (8 - p1p));
            //Console.WriteLine("");
        }

        public bool canJump( int current, int next)
        {
            if (tile[next] == tileTypes.BoardTileB) return false;
            else if (tile[current] != tile[next] && tile[next] != tileTypes.BoardTileB) return true;
            else return false;
            
        }

        public bool allowJump = false;

        public void checkJump(int cur, int L, int R)
        {
            if (p2Turn)
            {
                if (canJump(cur, L)) { L += 7; indacate(cur, L, R); allowJump = true; }
                else if (canJump(cur, R)) { R += 9; indacate(cur, L, R); allowJump = true; }
                else indacate(cur, L, R); allowJump = false;
            }
            else
            {
                if (canJump(cur, L)) { L -= 7; indacate(cur, L, R); allowJump = true; }
                else if (canJump(cur, R)) { R -= 9; indacate(cur, L, R); allowJump = true; }
                else indacate(cur, L, R); allowJump = false;
            }
        }

        public int[]  select(int x, int y)
        {
            int[] pos = new int[3];
            pos[0] = (y * 8) + x;

            if (p2Turn)
            {
                pos[1] = pos[0] + 7;
                pos[2] = pos[0] + 9;
            }
            else
            {
                pos[1] = pos[0] - 7;
                pos[2] = pos[0] - 9;
            }

            return pos;

        }
        public void indacate(int cur, int L, int R, int bL, int bR)
        {
            /*if (tile[R] == tileTypes.BoardTileB) tile[R] = tileTypes.Indacator1;
            if (tile[L] == tileTypes.BoardTileB) tile[L] = tileTypes.Indacator2;
            if (tile[bR] == tileTypes.BoardTileB && bR != 200) tile[bR] = "<3>";
            if (tile[bL] == tileTypes.BoardTileB && bL != 200) tile[bL] = "<4>";*/

            int[] pos = {L,R,bL,bR };
            string[] indi = {tileTypes.Indacator1, tileTypes.Indacator2, "<3>","<4>"};
            int side = cur % 8;
            for (int i = 0; i < 4; i++)
            {
                if (pos[i] != 200 && !check.onEnd(cur)) tile[pos[i]] = indi[i];
            }

            if (check.onEnd(cur))
            {
                tile[pos[0]] = indi[0]; 
                if (pos[2] != 200) tile[pos[2]] = indi[2];
            }

            printB();

            if (check.onEnd(cur))
            {
                tile[pos[0]] = tileTypes.BoardTileB;
                if (pos[2] != 200) tile[pos[2]] = tileTypes.BoardTileB;
            }

            else
            {
                tile[R] = tileTypes.BoardTileB;
                tile[L] = tileTypes.BoardTileB;
                tile[bR] = tileTypes.BoardTileB;
                tile[bL] = tileTypes.BoardTileB;
            }
        }

        public void indacate(int cur, int L, int R)
        {

            indacate(cur,L,R,200,200);

        }

        public void turn()
        {

            if (p2Turn == false)
            {
                Console.WriteLine("p1 select a peace X cordanite");
                Console.Write("=>");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("p1 select a peace Y cordanite");
                Console.Write("=>");
                int y = Convert.ToInt32(Console.ReadLine());
                if (!check.inRange(x, y))
                {
                    Console.WriteLine("ERROR: invalid cords");
                    Console.WriteLine("p1 select a peace X cordanite");
                    Console.Write("=>");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("p1 select a peace Y cordanite");
                    Console.Write("=>");
                    y = Convert.ToInt32(Console.ReadLine());
                }

                int current = select(x, y)[0];

                int nextR = select(x, y)[1];
                int nextL = select(x, y)[2];

                checkJump(current, nextR, nextL);

                if (canJump(current, nextL) && allowJump == true) { tile[nextL] = tileTypes.BoardTileB; nextL -= 9; }
                if (canJump(current, nextR) && allowJump == true) { tile[nextR] = tileTypes.BoardTileB; nextR -= 7; }
                else { nextR = select(x, y)[1]; nextL = select(x, y)[2];}

                Console.WriteLine("please pick a tile: ");
                Console.Write("=>");
                int opt = Convert.ToInt32(Console.ReadLine());
                /*switch (opt) 
                {
                    case 1: Move(current, nextR); if (select(x, y)[1] != nextR) p1p -= 1; /*tile[nextR] = tile[current]; tile[current] = tileTypes.BoardTileB; break;
                    case 2: Move(current, nextL); if (select(x, y)[2] !=nextL) p1p -= 1;/*tile[nextL] = tile[current]; tile[current] = tileTypes.BoardTileB; break;
                }*/

                switch (opt)
                {
                    case 1:
                        if (canJump(current, nextR)) { Move(current, nextR - 7); p1p -= 1; }/*tile[nextR] = tile[current]; tile[current] = tileTypes.BoardTileB;*/
                        else Move(current, nextR);
                        break;
                    case 2:
                        if (canJump(current, nextL)) { Move(current, nextL - 9); p1p -= 1; }/*tile[nextL] = tile[current]; tile[current] = tileTypes.BoardTileB;*/
                        else Move(current, nextL);
                        break;
                }

                p2Turn = true;
                //select();
            }
            if (p2Turn == true)
            {
                Console.WriteLine("p2 select a peace X cordanite");
                Console.Write("=>");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("p2 select a peace Y cordanite");
                int y = Convert.ToInt32(Console.ReadLine());

                if (!check.inRange(x, y))
                {
                    Console.WriteLine("ERROR: invalid cords");
                    Console.WriteLine("p1 select a peace X cordanite");
                    Console.Write("=>");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("p1 select a peace Y cordanite");
                    Console.Write("=>");
                    y = Convert.ToInt32(Console.ReadLine());
                }

                int current = select(x, y)[0];

                int nextR = select(x, y)[1];
                int nextL = select(x, y)[2];

                checkJump(current, nextR, nextL);

                int jR = 0;
                int jL = 0;

                if (canJump(current, nextL)) jL = nextL + 7;
                if (canJump(current, nextR)) jR = nextR + 9;

                Console.WriteLine("please pick a tile (1 or 2)");
                Console.Write("=>");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1: if (canJump(current, nextR)) { Move(current, jR); p2p -= 1; tile[nextL] = tile[current]; tile[current] = tileTypes.BoardTileB; }
                        else Move(current, nextR);
                        break;
                    case 2: if (canJump(current, nextL)) { Move(current, jL); p2p -= 1; tile[nextR]= tile[current]; tile[current] = tileTypes.BoardTileB; }
                        else Move(current, nextL);
                        break;
                }

                p2Turn = false;
            }

            turn();
        }
    }
    
}

