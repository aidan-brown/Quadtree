using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadtree
{
    class Node
    {
        /// <summary>
        /// These nodes correspond to each of the four quarters of the node we are currently in
        /// </summary>
        public Node nw, ne, sw, se;

        /// <summary>
        /// Holds the list of all points within this node
        /// </summary>
        private List<Vector2> p;

        /// <summary>
        /// Each of these list contains the points within each of the four quarters of this node 
        /// </summary>
        private List<Vector2> listNW, listNE, listSW, listSE;

        /// <summary>
        /// These doubles give the bounds of the node (x1, y1) and (x2, y2)
        /// </summary>
        private double x1, x2, y1, y2;

        public Node(List<Vector2> list, double _x1, double _y1, double _x2, double _y2)
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

            //Checks to see if the the number of points within this node is higher than the target value
            if (p.Count > 2)
            {
                //Loops through the entire list of points and checks if they're within the bounds of each of the four quarters and then adds the point to that quarter's list
                foreach (Vector2 v in p)
                {
                    //Bounding box for northwest (x1, y1) and (x1 + (x2-x1)/2, y1 + (y2-y1)/2)
                    if(v.X >= x1 && v.Y >= y1)
                    {
                        if (v.X <= x1 + (x2 - x1) / 2 && v.Y <= y1 + (y2 - y1) / 2)
                        {
                            listNW.Add(v);
                        }
                    }
                    //Bounding box for northeast (x1 + (x2-x1)/2, y1) and (x2, y1 + (y2-y1)/2)
                    if (v.X >= x1 + (x2 - x1) / 2 && v.Y >= y1)
                    {
                        if (v.X <= x2 && v.Y <= y1 + (y2 - y1) / 2)
                        {
                            listNE.Add(v);
                        }
                    }
                    //Bounding box for southwest (x1, y1 + (y2-y1)/2) and (x1 + (x2-x1)/2, y2)
                    if (v.X >= x1 && v.Y >= y1 + (y2 - y1) / 2)
                    {
                        if (v.X <= x1 + (x2 - x1) / 2 && v.Y <= y2)
                        {
                            listSW.Add(v);
                        }
                    }
                    //Bounding box for southeast (x1 + (x2-x1)/2, y1 + (y2-y1)/2) and (x2, y2)
                    if (v.X >= x1 + (x2 - x1) / 2 && v.Y >= y1 + (y2 - y1) / 2)
                    {
                        if (v.X <= x2 && v.Y <= y2)
                        {
                            listSE.Add(v);
                        }
                    }
                }

                //Recursively calls the the node constructor for each of the list of points
                nw = new Node(listNW, x1, y1, x1 + (x2 - x1) / 2, y1 + (y2 - y1) / 2);
                ne = new Node(listNE, x1 + (x2 - x1) / 2, y1, x2, y1 + (y2 - y1) / 2);
                sw = new Node(listSW, x1, y1 + (y2 - y1) / 2, x1 + (x2 - x1) / 2, y2);
                se = new Node(listSE, x1 + (x2 - x1) / 2, y1 + (y2 - y1) / 2, x2, y2);
            }
        }

        //Recursively travels through the quadtree and prints out the points within each node
        public void PrintNode(String _s, String dir)
        {
            //Keeps track of where we are in the quadtree
            String s = _s;
            if (_s.Length > 0)
            {
                s += "-";
            }
             s += dir;

            //If the nw list is null then the target node has been reached and we no longer have to recursively call PrintNode
            if(nw != null)
            {
                nw.PrintNode(s, "NW");
                ne.PrintNode(s, "NE");
                sw.PrintNode(s, "SW");
                se.PrintNode(s, "SE");
            }
            //If the list in the node contains something the list will be printed out
            else if(p.Count > 0)
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
