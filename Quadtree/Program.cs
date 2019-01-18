using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadtree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            List<Vector2> list = new List<Vector2>();
            Node n;

            for(int i = 0; i < 10; i++)
            {
                list.Add(new Vector2(rng.Next(1, 100), rng.Next(1, 100)));
            }

            n = new Node(list, 0, 100, 0, 100);

            n.PrintNode("", "");
        }
    }
}
