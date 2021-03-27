using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_cSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "inputfile.txt";
            Maze maze = new Maze(path, new Point(1,1), new Point(6, 1));
            Dijkstra dejkstra = new Dijkstra(maze);
            dejkstra.Go();
            maze.GetResult("outputfile.txt");
        }
    }
}
