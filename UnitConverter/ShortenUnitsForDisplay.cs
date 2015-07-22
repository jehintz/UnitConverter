using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class ShortenUnitsForDisplay
    {
        private string unitFull;
        private string unitAbbreviation;

        public ShortenUnitsForDisplay(string unitFullName)
        {
            unitFull = unitFullName;
            unitAbbreviation = Abbreviate(unitFull);
        }

        public override string ToString()
        {
            return unitAbbreviation;
        }

        private string Abbreviate(string fullUnitName)
        {
            switch(fullUnitName)
            {
                case "Pounds":
                    return "lb";

                case "Grams":
                    return "g";

                case "Tons":
                    return "t";

                case "Milligrams":
                    return "mg";

                case "Ounces":
                case "Fluid Ounces":
                    return "oz";

                case "Kilograms":
                    return "kg";

                case "Cups":
                case "Celsius":
                    return "C";

                case "Liters":
                    return "l";

                case "Milliliters":
                    return "ml";

                case "Tablespoons":
                    return "Tb";

                case "Teaspoons":
                    return "tsp";

                case "Quarts":
                    return "qrt";

                case "Fahrenheit":
                    return "F";

                case "Gallons":
                    return "gal";

                case "Pints":
                    return "p";

                case "Miles":
                    return "mi";

                case "Feet":
                    return "ft";

                case "Inches":
                    return "in";

                case "Kilometers":
                    return "km";

                case "Kelvin":
                    return "K";

                case "Kilometers/Hour":
                    return "kph";

                case "Miles/Hour":
                    return "mph";

                case "Feet/Second":
                    return "fps";

                case "Meters/Second":
                    return "mps";
                  
                default:
                    return "";
            }
        }
    }
}
