using System;
using System.Collections.Generic;
using Entity;

namespace UseCase
{
    public class UC_WaterManagementMultiSource
    {

        public WaterManagementSystem system;
        private DateTime AssessDate;

        public double ReclaimedWaterConsumption;
        public double SecondSourceRatio;

        public UC_WaterManagementMultiSource(DateTime date)
        {
            AssessDate = date;

            // Create a primary water source
            WaterSource primarySource = new WaterSource("Taishui Tap Water", 0, WaterSourceTag.Tap, new DateTime(2000, 1, 1));

            // Create a list of secondary water sources
            List<WaterSource> secondarySources = new List<WaterSource>
            {
                // 鳳山溪再生水廠
                new WaterSource("Fengshanxi Reclaimed Water Plant", 41000, WaterSourceTag.Reclaimed, new DateTime(2019, 9,1)),
                new WaterSource("Linhai Resource Center", 20000, WaterSourceTag.Reclaimed, new DateTime(2021,12,9)),
                new WaterSource("Fengshanxi Reclaimed Water Plant (Expand)", 9700, WaterSourceTag.Reclaimed, new DateTime(2024, 1,1)),
                new WaterSource("Seawater Desalination Plant", 13000, WaterSourceTag.Desalinated, new DateTime(2099,1,1))
            };

            // Create a water management system with the primary source as tap water and the secondary sources as the list above
            system = new WaterManagementSystem(primarySource, secondarySources);
        }

        /// <summary>
        /// Use Case' Standard Interface
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            bool result = true;

            // Internal: Deploy water saving strategies to reduce water consumption
            system.DeployWaterSavingStrategies();

            // External: Use multiple water sources to meet the plant's water needs
            system.UseMultipleWaterSources();

            // Assessment: the sustainable water management's indicators
            ReclaimedWaterConsumption = system.CalculateReclaimedWaterConsumption(AssessDate);
            SecondSourceRatio = system.CalculateSecondSourceRatio(AssessDate);

            return result;
        }
    }
}