using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SyngasGeneration
    {
        private NaturalGas naturalGas;
        private Steam steam;
        private Air air;
        private Oxygen oxygen;
        private Nitrogen nitrogen;
        private NickelCatalyst nickelCatalyst;

        //private Reformer reformer;
        //private WaterGasShift waterGasShift;
        //private CO2Removal? co2Removal;
        //private Methanation? methanation;

        /// <summary>
        /// The synthesis gas production by steam reforming of natural gas
        /// </summary>
        /// <returns></returns>
        public Syngas GenerateSyngas()
        {
            // Steam upgrading of natural gas
            Syngas syngas = SteamReforming(naturalGas, steam, air, nickelCatalyst);

            // Perform water-gas shift to reduce CO content
            syngas = WaterGasShift(syngas);

            // Remove CO2 through process of absorption and desorption
            syngas = CO2Removal(syngas);

            // Perform methanation to remove remaining CO and CO2
            syngas = Methanation(syngas);

            return syngas;
        }

        private Syngas SteamReforming(NaturalGas naturalGas, Steam steam, Air air, NickelCatalyst nickelCatalyst)
        {
            Syngas syngas = new Syngas();

            // Conversion of hydrocarbons in natural gas to a mixture of H2, CO, CO2 and CH4
            // over a nickel catalyst
            // ...

            // By adding air, nitrogen is introduced in the amount needed for ammonia production.
            // ...

            // Introduction of oxygen from air to partially oxidize methane
            // ...

            return syngas;
        }

        private Syngas WaterGasShift(Syngas syngas)
        {
            // Conversion of CO and steam to H2 and CO2 using a catalyst
            // to reduce CO content in the gas
            // ...

            return syngas;
        }

        private Syngas CO2Removal(Syngas syngas)
        {
            // The syngas now consists mostly of H2, N2 and CO2

            // Syngas Cooling Down
            // ...

            // CO2 is captured by absorption into an amine solution or potassium carbonate solution
            // ...

            // Removal of CO2 from the gas and making it available in conditions
            // and purity suitable for urea production
            return syngas;
        }

        private Syngas Methanation(Syngas syngas)
        {
            // Conversion of remaining CO and CO2 to methane and water
            // over a nickel catalyst to remove oxygenates and clean the gas
            // ...

            // Water, the only remaining oxygen carrier, 
            // is removed by condensation in the synthesis gas compression
            // ...

            return syngas;
        }
    }
}
