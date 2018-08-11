using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel;

namespace Biolight.GH
{
    //komponent musi dziedziczyć po GH_Component (to znaczy, będzie posiadał wszystkie właściwości GH_Component + to co poniżej) 
    public class SimpleComponent : Grasshopper.Kernel.GH_Component {

        public SimpleComponent() : base("Simple Component","Simple","Simple Component","Biolight","Test"){
            //pusty konstruktor implementujący metodę z klasy bazowej 
        }

        //GUID - po tym numerze GH rozpoznaje komponenty
        public override Guid ComponentGuid => new Guid("{0E5A0D11-DC47-4E77-927A-5196EF460228}");

        // dodawanie parametrów wejściowych 
        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddNumberParameter("A", "A", "Value A", GH_ParamAccess.item, 1);
            pManager.AddNumberParameter("B", "B", "Value B", GH_ParamAccess.item, 1);
        }

        //dodawanie parametrów wyjściowych 
        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddNumberParameter("C", "C", "Value C", GH_ParamAccess.item);
        }

        //to jest to co "robi" komponent 
        protected override void SolveInstance(IGH_DataAccess DA) {
            
            //deklaracja zmiennych 
            double valueA = 0;
            double valueB = 0;
            double valueC = 0; 

            //w ten sposób "pobieramy" wartości z parametrów wejściowych 
            DA.GetData(0, ref valueA);
            DA.GetData(1, ref valueB);
             
            //jakaś akcja
            valueC = valueA + valueB; 

            //ładowanie wyniku do parametru wyjściowego
            DA.SetData(0, valueC); 
        }
    }
}
