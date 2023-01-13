using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;

namespace UseCase
{
    public class UC_TransformationCaseA
    {
        public MillGasMgr gasMgr;

        public UC_TransformationCaseA()
        {
            gasMgr = new MillGasMgr();
        }

        public bool Run()
        {
            bool result = true;
            
            gasMgr.DistributeGasStreams();



            //MillGasMgr.GetVolFlowFor

            //// 建立新的 PSA 物件，並將 Coke Oven Gas 設為輸入氣體流
            //GasStream cokeOvenGas = MillGasMgr.GasStreams[0];
            //PSA psa = new PSA(cokeOvenGas);

            //// 執行分離
            //psa.Separate();

            //// 取得分離後的兩個輸出氣體流
            //GasStream output1 = psa.OutputStream1;
            //GasStream output2 = psa.OutputStream2;



            //SynthesisGasGeneration();

            //SyngasGeneration syngasGeneration = new SyngasGeneration();
            //Syngas syngas = syngasGeneration.GenerateSyngas();

            //AmmoniaSynthesis ammoniaSynthesis = new AmmoniaSynthesis();
            //Ammonia ammonia = ammoniaSynthesis.SynthesizeAmmonia(syngas);

            //UreaSynthesisAndFinishing ureaSynthesisAndFinishing = new UreaSynthesisAndFinishing();
            //Urea urea = ureaSynthesisAndFinishing.ProduceUrea(ammonia);

            //result &= this.PrepareOriginalTs();
            return result;
        }
    }
}
