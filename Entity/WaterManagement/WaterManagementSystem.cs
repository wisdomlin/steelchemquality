using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
public class WaterManagementSystem
{
    // Primary water source: Tap water
    private WaterSource primarySource;
    // Secondary water sources: Recycled water, reclaimed water, desalinated water
    private List<WaterSource> secondarySources;

    // Tap water demand
    public double TapWaterDemand { get; set; }
    // Process water recovery rate
    public double ProcessWaterRecoveryRate { get; set; }
    // Number of uses of circulating water in the factory
    public int NumberOfUsesOfCirculatingWater { get; set; }

    // The overall water consumption
    public double OverallWaterDemand { get; set; }

    /// <summary>
    /// Constructor for the WaterManagementSystem class
    /// </summary>
    /// <param name="primarySource">The primary water source</param>
    /// <param name="secondarySources">The list of secondary water sources</param>
    public WaterManagementSystem(WaterSource primarySource, List<WaterSource> secondarySources)
    {
        this.primarySource = primarySource;
        this.secondarySources = secondarySources;
        OverallWaterDemand = 122000;
    }

    /// <summary>
    /// Deploys water saving strategies to reduce water consumption
    /// </summary>
    public void DeployWaterSavingStrategies()
    {
        // Implement strategies to reduce water consumption, such as recycling and reusing water,
        // updating equipment to use less water, and so on: 

        // 1. Widely set up rainwater collection and recycling facilities on the roof of the factory building, 
        // 2. self-built industrial wastewater purification plant to recycle and discharge water, 
        // 3. RO concentrated water recycling and reuse, 
        // 4. blowers are updated to high-efficiency rotors to reduce cooling water consumption
    }

    /// <summary>
    /// Use multiple water sources to meet the plant's water needs
    /// </summary>
    public void UseMultipleWaterSources()
    {
        // Import reclaimed water from the Fengshanxi Reclaimed Water Plant
        // Import reclaimed water from the Linhai Resource Center
        // Evaluate the feasibility of using seawater desalination
        // Other measures...
    }

    // Reclaimed water consumption (in tons)
    private double reclaimedWaterConsumption;

    /// <summary>
    /// Calculates the reclaimed water consumption for a given date
    /// </summary>
    /// <param name="date">The given date</param>
    /// <returns>The reclaimed water consumption for the given date</returns>
    public double CalculateReclaimedWaterConsumption(DateTime date)
    {
        double consumption = 0;
        foreach (WaterSource source in secondarySources)
        {
            if (source.WaterSourceTag == WaterSourceTag.Reclaimed && source.AvailableDate < date)
            {
                consumption += source.Capacity;
            }
        }
        return consumption;
    }

    /// <summary>
    /// Calculates the ratio of the second water source supply to the overall water demand
    /// </summary>
    /// <param name="date">The given date</param>
    /// <returns>The ratio of the second water source supply to the overall water demand</returns>
    public double CalculateSecondSourceRatio(DateTime date)
    {
        double secondSourceConsumption = 0;

        foreach (WaterSource source in secondarySources)
        {
            if (source.AvailableDate < date)
            {
                secondSourceConsumption += source.Capacity;
            }
        }

        return secondSourceConsumption / OverallWaterDemand;
    }

    //private List<Equipment> _equipmentList;
    //private Database _database;

    //public void MonitorWaterUsage()
    //{
    //    // 監測各個設備的水資源使用情況，並將資訊記錄在資料庫中
    //    foreach (var equipment in _equipmentList)
    //    {
    //        var waterUsage = equipment.GetWaterUsage();
    //        _database.RecordWaterUsage(equipment.Id, waterUsage);
    //    }
    //}

    //public void OptimizeWaterAllocation()
    //{
    //    // 讀取各個設備的水資源使用情況
    //    var waterUsageData = _database.GetWaterUsageData();

    //    // 優化水資源的配置，以最大化水資源的使用效率
    //    foreach (var data in waterUsageData)
    //    {
    //        var equipment = _equipmentList.Find(x => x.Id == data.EquipmentId);
    //        equipment.OptimizeWaterAllocation(data.WaterUsage);
    //    }
    //}

    //public void ImplementWaterConservationMeasures()
    //{
    //    // 實施水資源保育措施，以降低水資源的消耗
    //    foreach (var equipment in _equipmentList)
    //    {
    //        equipment.ImplementWaterConservationMeasures();
    //    }
    //}
}

    //internal class Equipment
    //{
    //    internal object Id;

    //    internal object GetWaterUsage()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    internal void ImplementWaterConservationMeasures()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    internal void OptimizeWaterAllocation(object waterUsage)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //internal class Database
    //{
    //    internal object GetWaterUsageData()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    internal void RecordWaterUsage(object id, object waterUsage)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
