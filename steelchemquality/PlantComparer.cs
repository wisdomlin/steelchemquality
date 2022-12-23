using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PlantComparer
    {
        public void Compare(UreaPlant plant1, UreaPlant plant2)
        {
            Console.WriteLine("Comparing production output between plant 1 and plant 2:");
            Console.WriteLine($"Plant 1: " +
                $"Urea = {plant1.ProductionOutput.Urea}, " +
                $"CO2 = {plant1.ProductionOutput.CO2}, " +
                $"Hydrogen = {plant1.ProductionOutput.Hydrogen}");
            Console.WriteLine($"Plant 2: " +
                $"Urea = {plant2.ProductionOutput.Urea}, " +
                $"CO2 = {plant2.ProductionOutput.CO2}, " +
                $"Hydrogen = {plant2.ProductionOutput.Hydrogen}");
        }
    }
}
