using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    // 定義 UreaPlant 類別
    public class UreaPlant
    {
        // 定義屬性
        public string? Name { get; set; }
        public string? Process { get; set; }
        public int ProductionCapacity { get; set; }
        public Dictionary<string, int>? Feedstocks { get; set; }
        public Dictionary<string, int>? ProductionOutput { get; set; }

        public UreaPlant(string? name, string? process, int productionCapacity, Dictionary<string, int>? feedstocks)
        {
            Name = name;
            Process = process;
            ProductionCapacity = productionCapacity;
            Feedstocks = feedstocks;
        }

        //public int UreaProduction { get; set; }
        //public int CO2Emission { get; set; }
        //public int HydrogenRequirement { get; set; }

        public void Produce()
        {
            // 進行生產過程，計算生產產出
            // ...
        }
    }
}
