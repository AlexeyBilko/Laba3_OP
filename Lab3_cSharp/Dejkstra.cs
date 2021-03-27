using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_cSharp
{
    public class Dejkstra
    {
        public Maze maze;
        public MyQueue<Node> queue;
        public List<Node> Way;

        public Dejkstra(Maze _maze)
        {
            maze = _maze;
        }

        public void Go()
        {
            Info();
            GetCost();
            ShowMatrix();
            GetWay();
            ShowTrueMatrix();
        }

        private void GetWay()
        {
            if (maze.nodes[maze.end.X][maze.end.Y].Mark == true)
            {
                queue = new MyQueue<Node>();
                int x = maze.end.X;
                int y = maze.end.Y;
                do
                {
                    if (maze.nodes[x + 1][y].Number == maze.nodes[x][y].Number - 1)
                    {
                        maze.nodes[x + 1][y].isWay = true;
                        queue.Enqueue(maze.nodes[x + 1][y]);
                        x = x + 1;
                    }
                    else if (maze.nodes[x - 1][y].Number == maze.nodes[x][y].Number - 1)
                    {
                        maze.nodes[x + 1][y].isWay = true;
                        queue.Enqueue(maze.nodes[x - 1][y]);
                        x = x - 1;
                    }
                    else if (maze.nodes[x][y + 1].Number == maze.nodes[x][y].Number - 1)
                    {
                        maze.nodes[x][y + 1].isWay = true;
                        queue.Enqueue(maze.nodes[x][y + 1]);
                        y = y + 1;
                    }
                    else if (maze.nodes[x][y - 1].Number == maze.nodes[x][y].Number - 1)
                    {
                        maze.nodes[x + 1][y].isWay = true;
                        queue.Enqueue(maze.nodes[x][y - 1]);
                        y = y - 1;
                    }
                    else if (maze.nodes[x + 1][y] == maze.nodes[maze.start.X][maze.start.Y] ||
                       maze.nodes[x - 1][y] == maze.nodes[maze.start.X][maze.start.Y] ||
                       maze.nodes[x][y + 1] == maze.nodes[maze.start.X][maze.start.Y] ||
                       maze.nodes[x][y - 1] == maze.nodes[maze.start.X][maze.start.Y])
                    {
                        break;
                    }
                }
                while (maze.nodes[x][y] != maze.nodes[maze.start.X][maze.start.Y]);

                Way = new List<Node>();
                int tmp = queue.Count;
                for (int i = 0; i < tmp; i++)
                {
                    Node n = queue.Dequeue();
                    Console.WriteLine($"X - {n.X.ToString()} Y - {n.Y.ToString()} N - {n.Number}");
                    Way.Add(n);
                }
            }
            else Console.WriteLine("No way");
        }

        private void ShowTrueMatrix()
        {
            for (int i = 0; i < maze.nodes.Length; i++)
            {
                for (int j = 0; j < maze.nodes.Length; j++)
                {
                    if (maze.nodes[i][j] == maze.end || maze.nodes[i][j].isWay == true)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(maze.nodes[i][j].Number + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }

        private void ShowMatrix()
        {
            for (int i = 0; i < maze.nodes.Length; i++)
            {
                for (int j = 0; j < maze.nodes.Length; j++)
                {
                    if (maze.nodes[i][j].ifBorder == false)
                    {
                        if (maze.nodes[i][j] == maze.start)
                            Console.Write("S");
                        else if (maze.nodes[i][j] == maze.end)
                            Console.Write("F");
                        else
                            Console.Write(" ");
                    }

                    else Console.Write("#");
                }
                Console.WriteLine();
            }
        }

        private void GetCost()
        {
            int cost = 0;
            maze.nodes[maze.start.X][maze.start.Y].Number = 99;
            maze.nodes[maze.start.X][maze.start.Y].Mark = true;

            bool STOP = false;
            for (int i = 0; i < maze.nodes.Length; i++)
            {
                if (STOP != true)
                {
                    for (int j = 0; j < maze.nodes.Length; j++)
                    {
                        if (maze.nodes[maze.end.X][maze.end.Y].Mark == true)
                        {
                            maze.nodes[maze.end.X][maze.end.Y].Number = cost;
                            maze.nodes[maze.end.X][maze.end.Y].Mark = true;
                            STOP = true;
                            break;
                        }
                        else
                        {
                            if (maze.nodes[i][j].Mark == true)
                            {
                                bool isCost = false;
                                if (i + 1 < maze.nodes.Length && maze.nodes[i + 1][j].Mark == false && maze.nodes[i + 1][j].ifBorder == false)
                                {
                                    cost = cost + 1;
                                    isCost = true;
                                    maze.nodes[i + 1][j].Number = cost;
                                    maze.nodes[i + 1][j].Mark = true;
                                }
                                if (i-1 < maze.nodes.Length && i -1 >= 0 && maze.nodes[i - 1][j].Mark == false && maze.nodes[i - 1][j].ifBorder == false)
                                {
                                    if (isCost == true)
                                    {
                                        maze.nodes[i - 1][j].Number = cost;
                                        maze.nodes[i - 1][j].Mark = true;
                                    }
                                    else
                                    {
                                        cost = cost + 1;
                                        maze.nodes[i - 1][j].Number = cost;
                                        maze.nodes[i - 1][j].Mark = true;
                                    }
                                }
                                if (j + 1 < maze.nodes.Length && maze.nodes[i][j+1].Mark == false && maze.nodes[i][j+1].ifBorder == false)
                                {
                                    if (isCost == true)
                                    {
                                        maze.nodes[i][j + 1].Number = cost;
                                        maze.nodes[i][j + 1].Mark = true;
                                    }
                                    else
                                    {
                                        cost = cost + 1;
                                        maze.nodes[i][j + 1].Number = cost;
                                        maze.nodes[i][j + 1].Mark = true;
                                    }
                                }
                                if (j - 1 < maze.nodes.Length && j - 1 >= 0 && maze.nodes[i][j - 1].Mark == false && maze.nodes[i][j - 1].ifBorder == false)
                                {
                                    if (isCost == true)
                                    {
                                        maze.nodes[i][j - 1].Number = cost;
                                        maze.nodes[i][j - 1].Mark = true;
                                    }
                                    else
                                    {
                                        cost = cost + 1;
                                        maze.nodes[i][j - 1].Number = cost;
                                        maze.nodes[i][j - 1].Mark = true;
                                    }
                                }
                            }

                        }

                    }

                }
                else break;
            }
        }

        private void Info()
        {
            Console.WriteLine("Info: ");
            Console.WriteLine($"start X = {maze.start.X} Y = {maze.start.Y}");
            Console.WriteLine($"end X = {maze.end.X} Y = {maze.end.Y}");
        }
    }
}
