using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_cSharp
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool ifBorder { get; set; }
        public int Number { get; set; }
        public bool Mark { get; set; }
        public bool isWay {get;set;}

        public Node(int x, int y, char element)
        {
            X = x;
            Y = y;

            if (element == 'X')
                ifBorder = true;
            else
                ifBorder = false;
        }
    }
}
