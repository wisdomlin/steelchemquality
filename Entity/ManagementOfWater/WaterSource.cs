using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class WaterSource
    {
        public string Name { get; set; }
        public double Capacity { get; set; }
        public WaterSourceTag WaterSourceTag { get; set; }
        public DateTime AvailableDate { get; set; }

        public WaterSource(string name, double capacity, WaterSourceTag tag, DateTime available)
        {
            Name = name;
            Capacity = capacity;
            WaterSourceTag = tag;
            AvailableDate = available;
        }
    }

    public enum WaterSourceTag
    {
        Tap,
        Reclaimed,
        Desalinated
    }
}
