using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;

namespace UseCase
{
    public class UC_UreaProductionProcess
    {
        public bool Run()
        {
            bool result = true;

            SyngasGeneration syngasGeneration = new SyngasGeneration();
            syngasGeneration.GenerateSyngas();

            AmmoniaSynthesis ammoniaSynthesis = new AmmoniaSynthesis();
            ammoniaSynthesis.ProduceAmmonia();

            UreaSynthesisAndFinishing ureaSynthesisAndFinishing = new UreaSynthesisAndFinishing();
            ureaSynthesisAndFinishing.SynthesizeAndFinishUrea();

            //result &= this.PrepareOriginalTs();
            return result;
        }
    }
}
