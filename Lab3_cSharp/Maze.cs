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
        public Node[][] nodes;
        public Node start;
        public Node end;
        public List<string> lines { get; set; }

        public Maze(string path, Point startElement, Point endElement)
        {
            lines = File.ReadAllLines(path).ToList();

            nodes = new Node[lines.Count][];

            for (int i = 0; i < lines.Count; i++)
            {
                nodes[i] = new Node[lines[i].Length];
                for (int j = 0; j < lines[i].Length; j++)
                {
                    nodes[i][j] = new Node(j, i, lines[i][j]);
                }
            }

            start = nodes[startElement.Y][startElement.X];
            end = nodes[endElement.Y][endElement.X];
        }

        public void GetResult(string path)
        {
            List<string> list = new List<string>();// nodes.Length);

            File.WriteAllText(path, "");

            for (int i = 0; i < lines.Count; i++)
            {
                list.Add("");
                for (int j = 0; j < lines.Count; j++)
                {
                    if (nodes[i][j].Number > 0)
                        list[i] += "\t" + nodes[i][j].Number;
                    else
                        list[i] += "\t" + lines[i][j];
                }
            }

            File.AppendAllLines(path, list);
        }
    }
}
