using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UreaSynthesisAndFinishing
    {
        private UreaSynthesis ureaSynthesis;
        private UreaFinishing ureaFinishing;
        private Carbamate carbamate;    // 氨基甲酸酯 (CH6N2O2)
        private CarbonDioxide carbonDioxide;
        private Ammonia ammonia;

        public Urea ProduceUrea()
        {
            // Synthesize urea from carbamate intermediate product
            Urea urea = SynthesizeUrea(ammonia, carbonDioxide);

            // Evaporate water from urea
            urea = EvaporateWater(urea);

            // Finish urea in fluidized bed granulation or prilling unit
            urea = ProduceUreaParticles(urea, ureaFinishing);

            return urea;
        }

        private Urea SynthesizeUrea(Ammonia ammonia, CarbonDioxide carbonDioxide)
        {
            // 15 MPa 和 180 °C
            // Form intermediate product of carbamate from ammonia and carbon dioxide
            carbamate = FormCarbamate(ammonia, carbonDioxide);

            // The intermediate product reacts slowly to the final product.
            Urea urea = ReactToUrea(carbamate);

            // Return unreacted components to reactor
            urea = ReturnUnreactedComponents(urea);

            return urea;
        }

        private Urea ReactToUrea(Carbamate carbamate)
        {
            // ... 
            Urea urea = new Urea();
            return urea;
        }

        private Carbamate FormCarbamate(Ammonia ammonia, CarbonDioxide carbonDioxide)
        {
            // Return of unreacted components into synthesis reactor
            // ...
            Carbamate carbamate = new Carbamate();
            return carbamate;
        }

        private Urea ReturnUnreactedComponents(Urea urea)
        {
            // Return of unreacted components into synthesis reactor
            // ...

            return urea;
        }

        private Urea EvaporateWater(Urea urea)
        {
            // Evaporation of water from urea
            // ...

            return urea;
        }

        private Urea ProduceUreaParticles(Urea urea, UreaFinishing ureaFinishing)
        {
            // Finish urea in fluidized bed granulation or prilling unit
            // ...

            return urea;
        }
    }

    internal class CarbonDioxide
    {
    }

    public class UreaSynthesis
    {
        // Urea synthesis properties
    }

    public class UreaFinishing
    {
        // Urea finishing properties (fluidized bed granulation or prilling unit)
    }

    public class Carbamate
    {
        // Carbamate intermediate product properties
    }

    /// <summary>
    /// CH4N2O
    /// </summary>
    public class Urea
    {
        // Urea properties
    }
}
