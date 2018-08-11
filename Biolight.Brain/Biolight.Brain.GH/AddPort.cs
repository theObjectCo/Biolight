using System;
using Grasshopper.Kernel;
using Biolight.Brain;

namespace Biolight.GH {
    public class AddPort : GH_Component {

        public AddPort() : base("Add Port", "AddPort", "Add Port", "Biolight", "Serial") { }

        public override Guid ComponentGuid => new Guid("{8C6484A6-6050-4D3A-AB14-1A51CDD15953}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddTextParameter("Port Name", "P", "Port Name", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Baud Rate", "B", "Baud Rate", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Run", "R", "Run", GH_ParamAccess.item, false);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddBooleanParameter("Success", "V", "Success", GH_ParamAccess.item);
            }

        protected override void SolveInstance(IGH_DataAccess DA) {
            string name = "";
            int baud = 100;
            bool run = false;

            if (!DA.GetData(0, ref name)) { return; }
            if (!DA.GetData(1, ref baud)) { return; }
            if (!DA.GetData(2, ref run)) { return; }

            if (run) {
                DA.SetData(0, SerialMessage.AddPort(name, baud));
                }
            }
        }
    }
