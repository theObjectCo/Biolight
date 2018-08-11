using System;
using Grasshopper.Kernel;
using Biolight.Brain;

namespace Biolight.GH {
    public class ListPorts : GH_Component {

        public ListPorts() : base("List Ports", "List", "List Ports", "Biolight", "Serial") { }

        public override Guid ComponentGuid => new Guid("{571DD0CE-4A36-4006-8803-C64AB8C95D88}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddBooleanParameter("Refresh", "R", "Refresh", GH_ParamAccess.item, true);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddTextParameter("Ports", "P", "Ports", GH_ParamAccess.list);
            }

        protected override void SolveInstance(IGH_DataAccess DA) {
            DA.SetDataList(0, SerialMessage.GetNames());
            }
        }
    }
