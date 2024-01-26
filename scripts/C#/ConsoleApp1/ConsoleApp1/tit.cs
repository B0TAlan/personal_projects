using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TILE_MANAGER
{
    public class tit
    {

        public tileType type;

        public tit(tileType type)
        {
            this.type = type;
        }
    }

    public static class tileTypes
    {
        
        public static readonly string P1;
        public static readonly string P2;
        public static readonly string BoardTileW;
        public static readonly string BoardTileB;
        public static readonly string Indacator1;
        public static readonly string Indacator2;

        static tileTypes()
        {
            Indacator1 = "<1>";
            Indacator2 = "<2>";
            P1 = " 0 ";
            P2 = " O ";
            BoardTileB = "   ";
            BoardTileW = "\u2588\u2588█";

        }
    }

    public class tileType
    {
        public string Name { get; set; }
        public string render { get; set; }

        public ConsoleColor backCol { get; set; }
        public ConsoleColor foreCol { get; set; }

        public tileType(string name,string rende, ConsoleColor backColor, ConsoleColor foreColor) 
        { 
        
            this.Name = name;
            this.render = rende;
            this.backCol = backColor;
            this.foreCol = foreColor;

        }
    }
}
