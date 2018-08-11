using System;
using Grasshopper.Kernel;
using Biolight.Brain;

namespace Biolight.GH {
    public class ReleasePorts : GH_Component {

        public ReleasePorts() : base("Release Ports", "Release", "ReleasePorts", "Biolight", "Serial") { }

        public override Guid ComponentGuid => new Guid("{047A1701-9763-45CF-BDBF-BDB4FC7786DA}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddBooleanParameter("Run", "R", "Run", GH_ParamAccess.item, true);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            }

        protected override void SolveInstance(IGH_DataAccess DA) {
            bool run = false;
            if (!DA.GetData(0, ref run)) { return; }
            if (run) { SerialMessage.CloseAll(); }
            }
        }
    }
