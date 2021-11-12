using System;
using System.Configuration;
using System.IO;

namespace PruebaTecnica1
{
    public class ClsData
    {
        public int x1 = 0;
        public int y1 = 0;
        public string file = ConfigurationManager.AppSettings["fileroute"];
        public int[,] arraydata = new int[0, 0];
        string route = "";

        public ClsData()
        {
            arraydata = createdata();
        }

        public int[,] BiggernumberMap()
        {
            int[,] highest_area_map = new int[1, 4];
            int bigger_number = 0;
            int positionx = 0;
            int positiony = 0;

            for (int x = 0; x < x1; x++)
            {
                for (int y = 0; y < y1; y++)
                {
                    var number1 = arraydata[x, y];
                    if (validationnumber(number1))
                    {
                        if (bigger_number < number1)
                        {
                            bigger_number = number1;
                            positionx = x;
                            positiony = y;
                        }
                    }
                }
            }

            highest_area_map[0, 0] = positionx;
            highest_area_map[0, 1] = positiony;
            highest_area_map[0, 2] = bigger_number;
            highest_area_map[0, 3] = y1;
            return highest_area_map;

        }

        private bool validationnumber(int number)
        {
            bool rpt = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int numberstart = arraydata[i, j];
                    if (number > numberstart)
                    {
                        rpt = true;
                    }
                    else
                    {
                        rpt = false;
                    }

                }
            }
            return rpt;
        }

        public int [,] nextposition(int x, int y, int numerostart)
        {
            int[,] coordinates = new int[1, 3];
            if (x > 0  && y > 0)
            {
                int[,] arrayposition = new int[5, 2] { { x, y - 1 }, { x, y + 1 }, { x + 1, y - 1 }, { x + 1, y }, { x + 1, y + 1 } };
                int[] numbernextposition = new int[5];
                numbernextposition[0] = arraydata[arrayposition[0, 0], arrayposition[0, 1]];
                numbernextposition[1] = arraydata[arrayposition[1, 0], arrayposition[1, 1]];
                numbernextposition[2] = arraydata[arrayposition[2, 0], arrayposition[2, 1]];
                numbernextposition[3] = arraydata[arrayposition[3, 0], arrayposition[3, 1]];
                numbernextposition[4] = arraydata[arrayposition[4, 0], arrayposition[4, 1]];
                if (numbernextposition[3] < numerostart)
                {
                    for (int i = 0; i < numbernextposition.Length; i++)
                    {
                        if (numbernextposition[3] > numbernextposition[i])
                        {
                            coordinates[0, 0] = arrayposition[3, 0];
                            coordinates[0, 1] = arrayposition[3, 1];
                            coordinates[0, 2] = numbernextposition[3];
                            break;
                        }
                        else
                        {
                            coordinates[0, 0] = arrayposition[0, 0];
                            coordinates[0, 1] = arrayposition[0, 1];
                            coordinates[0, 2] = numbernextposition[i];
                            break;
                        }
                    }
                }
            }
            return coordinates;
        }

        private int[,] createdata()
        {
            int line1 = 0;
            int line2 = 0;
            string[] lines = File.ReadAllLines(file);

            foreach (var lineText in lines)
            {
                var temparraystart = lineText.Split(' ');
                if (temparraystart.Length == 2)
                {
                    x1 = Convert.ToInt32(temparraystart[0]);
                    y1 = Convert.ToInt32(temparraystart[1]);
                }
                break;
            }

            int[,] arraydatatemp = new int[x1, y1];

            for (int i = 1; i < lines.Length; i++)
            {
                var temparraystart = lines[i].Split(' ');
                if (temparraystart.Length > 2)
                {
                    foreach (var item2 in temparraystart)
                    {
                        arraydatatemp[line1, line2] = Convert.ToInt32(item2);
                        line2++;
                    }
                    line1++;
                    line2 = 0;
                }
            }
            return arraydatatemp;
        }
    }
}
