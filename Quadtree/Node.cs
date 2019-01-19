using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadtree
{
    class Node
    {
        public Node nw, ne, sw, se;
        private List<Vector2> p, listNW, listNE, listSW, listSE;
        private double x1, x2, y1, y2;

        public Node(List<Vector2> list, double _x1, double _x2, double _y1, double _y2)
        {
            p = list;
            x1 = _x1;
            x2 = _x2;
            y1 = _y1;
            y2 = _y2;
            listNW = new List<Vector2>();
            listNE = new List<Vector2>();
            listSW = new List<Vector2>();
            listSE = new List<Vector2>();

            Console.WriteLine("x1: {0}, y1: {1}, x2: {2}, y2: {3}", x1, y1, x2, y2);
            if (list.Count > 1)
            {
                foreach (Vector2 v in p)
                {
                    if(((v.X >= x1) && (v.X <= (x1 + x2 / 2))) && ((v.Y >= y1) && (v.Y <= (y1 + y2 / 2))))
                    {
                        listNW.Add(v);
                        Console.WriteLine("ADDED TO NW");
                    }
                    if (((v.X <= x2) && (v.X >= (x1 + x2 / 2))) && ((v.Y >= y1) && (v.Y <= (y1 + y2 / 2))))
                    {
                        listNE.Add(v);
                        Console.WriteLine("ADDED TO NE");
                    }
                    if (((v.X >= x1) && (v.X <= (x1 + x2 / 2))) && ((v.Y <= y2) && (v.Y >= (y1 + y2 / 2))))
                    {
                        listSW.Add(v);
                        Console.WriteLine("ADDED TO SW");
                    }
                    if (((v.X <= x2) && (v.X >= (x1 + x2 / 2))) && ((v.Y <= y2) && (v.Y >= (y1 + y2 / 2))))
                    {
                        listSE.Add(v);
                        Console.WriteLine("ADDED TO SE");
                    }
                }

                

                Console.WriteLine("POOPING OUR CHILDREN");
                nw = new Node(listNW, x1, x1 + x2 / 2, y1, y1 + y2 / 2);
                ne = new Node(listNE, x1 + x2 / 2, x2, y1, y1 + y2 / 2);
                sw = new Node(listSW, x1, x1 + x2 / 2, y1 + y2 / 2, y2);
                se = new Node(listSE, x1 + x2 / 2, x2, y1 + y2 / 2, y2);
            }
        }

        public void PrintNode(String _s, String dir)
        {
            String s = _s + "-" + dir;
            if(nw != null)
            {
                nw.PrintNode(s, "NW");
                ne.PrintNode(s, "NE");
                sw.PrintNode(s, "SW");
                se.PrintNode(s, "SE");
            }
            else
            {
                Console.WriteLine("==========={0}===========", s);
                foreach (Vector2 v in p)
                {
                    Console.WriteLine(" ({0}, {1})", v.X, v.Y);
                }
            }
        }
    }
}
