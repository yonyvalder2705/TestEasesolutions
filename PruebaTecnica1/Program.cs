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
            int ciclefor = 0;
            int[,] arraystart = new int[1, 4];
            int[,] nextposition = new int[1, 3];
            int[,] routestring = new int[1, 3];
            ClsData data = new ClsData();

            arraystart = data.BiggernumberMap();
            allroute = arraystart[0, 3];
            route = arraystart[0, 2].ToString();
            routestring = data.nextposition(arraystart[0, 0], arraystart[0, 1], arraystart[0, 2]);
            ciclefor = allroute - Convert.ToInt32(routestring[0, 0]);
            route = route +','+ routestring[0,2].ToString();
        

            for (int i = 0; i < ciclefor; i++)
            {
                if(routestring[0,0] > 0 && routestring[0, 1] > 0)
                {
                    routestring = data.nextposition(routestring[0, 0], routestring[0, 1], routestring[0, 2]);
                    route = route + ',' + routestring[0, 2].ToString();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("the following is the descent route :");
            Console.WriteLine(route);
            Console.ReadLine();

        }
    }
}
