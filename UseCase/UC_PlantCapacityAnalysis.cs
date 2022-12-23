using Entity;

namespace UseCase
{
    public class UC_PlantCapacityAnalysis
    {
        // 建立傳統尿素廠
        UreaPlant traditionalPlant = new UreaPlant
        (
            "Traditional Plant",
            "Ammonia production followed by urea production",
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
        {
            Process = "Gas treatment followed by urea production",
            ProductionCapacity = 5000,
            Feedstocks = transformedFeedstock
        };

        // 設定鋼廠的資訊
        plant.SteelMillGasAmount = 100;
        plant.SteelMillGasComposition = "CO2, H2, N2";

        // 計算基於鋼廠氣體生產尿素所需的資訊
        plant.CalculateUreaProduction();

        // 比較傳統廠和基於鋼廠氣體的尿素廠的產能
        plant.ComparePlantCapacities();
    }
}