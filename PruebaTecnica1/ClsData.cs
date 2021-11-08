using System;
using System.Configuration;
using System.IO;

namespace PruebaTecnica1
{
    public class ClsData
    {
        public int x1 = Convert.ToInt32(ConfigurationManager.AppSettings["x"]);
        public int y1 = Convert.ToInt32(ConfigurationManager.AppSettings["x"]);
        public string file = ConfigurationManager.AppSettings["fileroute"];
        public int[,] arraydata = new int[0, 0];

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

        public int[,] nextposition(int x, int y, int numerostart)
        {
            int[,] arrayposition = new int[5, 2] { { x, y - 1 }, { x, y + 1 }, { x + 1, y - 1 }, { x + 1, y }, { x + 1, y + 1 } };
            int[,] arrayminornumber = new int[5, 3];
            int[,] coordinates = new int[1, 3];
            for (int a = 0; a < 5; a++)
            {
                int numbervalidate = arraydata[arrayposition[a, 0], arrayposition[a, 1]];
                if(arrayposition[a, 0] >= 0 && arrayposition[a, 1] >= 0)
                {
                    if (x +1 == arrayposition[a, 0] && y == arrayposition[a, 1] && numbervalidate < numerostart)
                    {
                        coordinates[0, 0] = arrayposition[a, 0];
                        coordinates[0, 1] = arrayposition[a, 1];
                        coordinates[0, 2] = numbervalidate;
                        break;
                    }
                    else
                    {
                        if (numbervalidate < numerostart)
                        {
                            coordinates[0, 0] = arrayposition[a, 0];
                            coordinates[0, 1] = arrayposition[a, 1];
                            coordinates[0, 2] = numbervalidate;
                            break;
                        }
                    }
                }
                
            }
            return coordinates;
        }

        private int[,] createdata()
        {
            int[,] arraydatacreate = new int[x1, y1];
            string line = "";
            StreamReader readfile = new StreamReader(file);
            line = readfile.ReadLine();
            while (line != null)
            {
                for (int x2 = 0; x2 < 1000; x2++)
                {
                    line = readfile.ReadLine();
                    if (line != null)
                    {
                        string[] arrayline = line.Split(' ');
                        if (arrayline.Length <= 2)
                        {
                            x1 = Convert.ToInt32(arrayline[0]);
                            y1 = Convert.ToInt32(arrayline[1]);
                        }
                        else
                        {
                            for (int i = 0; i < arrayline.Length; i++)
                            {
                                arraydatacreate[x2, i] = Convert.ToInt32(arrayline[i]);
                            }
                        }

                    }
                }
            }


            readfile.Close();


            return arraydatacreate;
        }
    }
}
