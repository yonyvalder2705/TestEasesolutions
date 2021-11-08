using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica1
{
    class Program
    {
        static void Main(string[] args)
        {
            int allroute = 0;
            string route = "";
            int[,] arraystart = new int[1, 4];
            int[,] nextposition = new int[1, 3];
            ClsData data = new ClsData();

            arraystart = data.BiggernumberMap();
            allroute = arraystart[0, 3];
            route = arraystart[0, 2].ToString();
            var Secondcoordenate = data.nextposition(arraystart[0, 0], arraystart[0, 1], arraystart[0, 2]);
            nextposition = Secondcoordenate;

            for (int i = 0; i < allroute; i++)
            {
                nextposition = data.nextposition(nextposition[0, 0], nextposition[0, 1], nextposition[0, 2]);
                route = route + ";" + nextposition[0,2].ToString();
            }

            Console.WriteLine(route);
            Console.ReadLine();

        }
    }
}
