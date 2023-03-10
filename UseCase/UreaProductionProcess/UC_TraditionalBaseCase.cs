using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;

namespace UseCase
{
    public class UC_TraditionalBaseCase
    {
        public bool Run()
        {
            bool result = true;

            SyngasGeneration syngasGeneration = new SyngasGeneration();
            Syngas syngas = syngasGeneration.GenerateSyngas();

            AmmoniaSynthesis ammoniaSynthesis = new AmmoniaSynthesis();
            Ammonia ammonia = ammoniaSynthesis.SynthesizeAmmonia(syngas);

            UreaSynthesisAndFinishing ureaSynthesisAndFinishing = new UreaSynthesisAndFinishing();
            Urea urea = ureaSynthesisAndFinishing.ProduceUrea(ammonia);

            //result &= this.PrepareOriginalTs();
            return result;
        }
    }
}
