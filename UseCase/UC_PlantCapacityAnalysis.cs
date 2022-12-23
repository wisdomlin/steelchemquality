
using System.Collections.Generic;

namespace steelchemquality
{
    public class UC_PlantCapacityAnalysis
    {
        /// <summary>
        /// Use Case' Standard Interface
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            bool result = true;

            // 建立傳統尿素廠
            UreaPlant traditionalPlant = new UreaPlant
            (
                "Traditional Plant",
                "Ammonia production before urea production",
                10000,
                new Dictionary<string, int>
                {
                { "Natural Gas", 1000 },
                { "Water", 500 },
                { "Air", 100 }
                }
            );

            // 建立轉型尿素廠
            UreaPlant transformedPlant = new UreaPlant
            (
                "Transformed Plant",
                "Gas treatment before urea production",
                5000,
                new Dictionary<string, int>
                {
                { "鋼廠氣體", 1000 }
                }
            );

            // 呼叫傳統尿素廠的Produce方法
            traditionalPlant.Produce();

            // 呼叫轉型尿素廠的Produce方法
            transformedPlant.Produce();

            // 初始化產能比較器
            PlantComparer plantComparer = new PlantComparer();

            // 呼叫產能比較器的Compare方法進行產能比較
            plantComparer.Compare(traditionalPlant, transformedPlant);

            //result &= this.PrepareOriginalTs();
            return result;
        }
    }
}