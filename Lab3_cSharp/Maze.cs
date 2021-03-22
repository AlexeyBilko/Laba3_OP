using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_cSharp
{
    public class Maze
    {
        Node[][] grids;
        public Node start;
        public Node end;

        public Maze(string path, Point startElement, Point endElement)
        {
            List<string> lines = File.ReadAllLines(path).ToList();

            grids = new Node[lines.Count][];

            for (int i = 0; i < lines.Count; i++)
            {
                grids[i] = new Node[lines[i].Length];
                for (int j = 0; j < lines[i].Length; j++)
                {
                    grids[i][j] = new Node(j, i, lines[i][j]);
                }
            }

            start = grids[startElement.X][startElement.Y];
            end = grids[endElement.X][endElement.Y];
        }

        public void GetResult(string path)
        {
            List<string> list = new List<string>(grids.Length);

            for (int i = 0; i < grids.Length; i++)
            {
                list[i] = "";
                for (int j = 0; j < grids[0].Length; j++)
                {
                    list[i] += grids[i][j];
                }
            }

            File.AppendAllLines(path, list);
        }
    }
}
