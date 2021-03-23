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
            Maze maze = new Maze(path, new Point(1,1), new Point(3,3));
            Dejkstra dejkstra = new Dejkstra(maze);
            dejkstra.Go();
            if(maze.FindWay(dejkstra.Way))
                maze.GetResult("outputfile.txt");
            
        }
    }
}
