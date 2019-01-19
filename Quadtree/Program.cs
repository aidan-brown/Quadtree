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

            list.Add(new Vector2(22, 13));
            list.Add(new Vector2(45, 15));
            list.Add(new Vector2(76, 45));
            list.Add(new Vector2(58, 82));
            list.Add(new Vector2(10, 80));
            list.Add(new Vector2(55, 12));
            list.Add(new Vector2(86, 13));
            list.Add(new Vector2(23, 70));
            list.Add(new Vector2(62, 37));
            list.Add(new Vector2(100, 26));
            //for(int i = 0; i < 10; i++)
            //{
            //    list.Add(new Vector2(rng.Next(1, 100), rng.Next(1, 100)));
            //}

            n = new Node(list, 0, 100, 0, 100);

            n.PrintNode("", "");
        }
    }
}
