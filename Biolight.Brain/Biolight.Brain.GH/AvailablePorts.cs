using System;
using Grasshopper.Kernel;
using Biolight.Brain;

namespace Biolight.GH {
    public class AvailablePorts : GH_Component {

        public AvailablePorts() : base("Available Ports", "Available", "Available Ports", "Biolight", "Serial") { }

        public override Guid ComponentGuid => new Guid("{3D8890DF-474C-4FFF-B34C-C141F5D76C9F}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddBooleanParameter("Refresh", "R", "Refresh", GH_ParamAccess.item, true);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddTextParameter("Ports", "P", "Ports", GH_ParamAccess.list);
            }

        protected override void SolveInstance(IGH_DataAccess DA) {
            DA.SetDataList(0, System.IO.Ports.SerialPort.GetPortNames());
            }
        }
    }
