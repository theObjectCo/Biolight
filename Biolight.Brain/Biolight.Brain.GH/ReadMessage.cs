using System;
using Grasshopper.Kernel;
using Biolight.Brain;

namespace Biolight.GH {
    public class ReadMessage : GH_Component {

        public ReadMessage() : base("ReadMessage", "Read", "Read Message", "Biolight", "Serial") { }

        public override Guid ComponentGuid => new Guid("{D8CC0650-2934-4749-A87F-9BFEB9E15B95}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddTextParameter("Port Name", "P", "Port Name", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Read", "R", "Read", GH_ParamAccess.item, false);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddTextParameter("Message", "M", "Message", GH_ParamAccess.item);
            }

        protected override void SolveInstance(IGH_DataAccess DA) {
            string name = "";
            bool read = false;

            if (!DA.GetData(0, ref name)) { return; }
            if (!DA.GetData(1, ref read)) { return;  }

            if (read) { DA.SetData(0, SerialMessage.Read(name)); } 
            }
        }
    }