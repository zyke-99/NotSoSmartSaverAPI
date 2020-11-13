using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSmartSaverWFA
{
    public static class ExtensionMethods
    {
        public static List<double> ToDoubleListWithoutNegatives(this List<string> list)
        {
            List<double> listOfDoubles = new List<double>();
            double temp;
            foreach (var element in list)
            {
                try
                {
                    temp = double.Parse(element);
                    if (temp < 0)
                        listOfDoubles.Add(Math.Abs(temp));
                    else
                        listOfDoubles.Add(temp);
                }
                catch (FormatException)
                {
                    listOfDoubles.Add(0);
                }
                
            }
            return listOfDoubles;
        }
        public static double ToDoubleWithoutNegatives(this string stringToConvert)
        {
            double temp;
            try
            {
                temp = double.Parse(stringToConvert);
                if (temp < 0)
                    temp = Math.Abs(temp);
            }
            catch(FormatException)
            {
                temp = 0;
            }
            return temp;
        }
    }
}
