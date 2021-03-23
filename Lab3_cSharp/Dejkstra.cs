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
            int cost = 0;
            maze.grids[maze.start.X][maze.start.Y].Number = 99;
            maze.grids[maze.start.X][maze.start.Y].Mark = true;

            bool STOP = false;
            for (int i = 0; i < maze.grids.Length; i++)
            {
                if (STOP != true)
                {
                    for (int j = 0; j < maze.grids.Length; j++)
                    {
                        if (maze.grids[maze.end.X][maze.end.Y].Mark == true)
                        {
                            maze.grids[maze.end.X][maze.end.Y].Number = cost;
                            STOP = true;
                            break;
                        }
                        else
                        {
                            if (maze.grids[i][j].Mark == true)
                            {
                                bool isCost = false;
                                if (i + 1 < maze.grids.Length && maze.grids[i + 1][j].Mark == false && maze.grids[i + 1][j].ifBorder == false)
                                {
                                    cost = cost + 1;
                                    isCost = true;
                                    maze.grids[i + 1][j].Number = cost;
                                    maze.grids[i + 1][j].Mark = true;
                                }
                                if (i-1 < maze.grids.Length && i -1 >= 0 && maze.grids[i - 1][j].Mark == false && maze.grids[i - 1][j].ifBorder == false)
                                {
                                    if (isCost == true)
                                    {
                                        maze.grids[i - 1][j].Number = cost;
                                        maze.grids[i - 1][j].Mark = true;
                                    }
                                    else
                                    {
                                        cost = cost + 1;
                                        maze.grids[i - 1][j].Number = cost;
                                        maze.grids[i - 1][j].Mark = true;
                                    }
                                }
                                if (j + 1 < maze.grids.Length && maze.grids[i][j+1].Mark == false && maze.grids[i][j+1].ifBorder == false)
                                {
                                    if (isCost == true)
                                    {
                                        maze.grids[i][j + 1].Number = cost;
                                        maze.grids[i][j + 1].Mark = true;
                                    }
                                    else
                                    {
                                        cost = cost + 1;
                                        maze.grids[i][j + 1].Number = cost;
                                        maze.grids[i][j + 1].Mark = true;
                                    }
                                }
                                if (j - 1 < maze.grids.Length && j - 1 >= 0 && maze.grids[i][j - 1].Mark == false && maze.grids[i][j - 1].ifBorder == false)
                                {
                                    if (isCost == true)
                                    {
                                        maze.grids[i][j - 1].Number = cost;
                                        maze.grids[i][j - 1].Mark = true;
                                    }
                                    else
                                    {
                                        cost = cost + 1;
                                        maze.grids[i][j - 1].Number = cost;
                                        maze.grids[i][j - 1].Mark = true;
                                    }
                                }
                            }

                        }

                    }
 
                }
                else break;
            }
            for (int i = 0; i < maze.grids.Length; i++)
            {
                for (int j = 0; j < maze.grids.Length; j++)
                {
                    if(maze.grids[i][j].ifBorder == false)
                    {
                        if (maze.grids[i][j] == maze.start)
                            Console.Write("S");
                        else if (maze.grids[i][j] == maze.end)
                            Console.Write("F");
                        else
                            Console.Write(" ");
                    }
                    
                    else Console.Write("#");
                }
                Console.WriteLine();
            }


            for (int i = 0; i < maze.grids.Length; i++)
            {
                for (int j = 0; j < maze.grids.Length; j++)
                {
                    if (maze.grids[i][j] == maze.end)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(maze.grids[i][j].Number + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }

            if (maze.grids[maze.end.X][maze.end.Y].Mark == true)
            {
                queue = new MyQueue<Node>();
                int x = maze.end.X;
                int y = maze.end.Y;
                do
                {
                    if (maze.grids[x + 1][y].Number == maze.grids[x][y].Number - 1)
                    {
                        x = x + 1;
                        queue.Enqueue(maze.grids[x + 1][y]);
                    }
                    else if (maze.grids[x - 1][y].Number == maze.grids[x][y].Number - 1)
                    {
                        x = x - 1;
                        queue.Enqueue(maze.grids[x - 1][y]);
                    }
                    else if (maze.grids[x][y + 1].Number == maze.grids[x][y].Number - 1)
                    {
                        y = y + 1;
                        queue.Enqueue(maze.grids[x][y + 1]);
                    }
                    else if (maze.grids[x][y - 1].Number == maze.grids[x][y].Number - 1)
                    {
                        y = y - 1;
                        queue.Enqueue(maze.grids[x][y - 1]);
                    }
                    else if (maze.grids[x + 1][y] == maze.grids[maze.start.X][maze.start.Y] ||
                       maze.grids[x - 1][y] == maze.grids[maze.start.X][maze.start.Y] ||
                       maze.grids[x][y + 1] == maze.grids[maze.start.X][maze.start.Y] ||
                       maze.grids[x][y - 1] == maze.grids[maze.start.X][maze.start.Y])
                    {
                        break;
                    }

                }
                while (maze.grids[x][y] != maze.grids[maze.start.X][maze.start.Y]);

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
    }
}
