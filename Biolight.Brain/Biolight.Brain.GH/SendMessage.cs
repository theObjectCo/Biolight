using System;
using Grasshopper.Kernel;
using Biolight.Brain;
using System.Collections.Generic;

namespace Biolight.GH {
    public  class WriteMessage : GH_Component {

        public WriteMessage() : base("WriteMessage", "Write", "Write Message", "Biolight", "Serial") { }

        public override Guid ComponentGuid => new Guid("{7E822213-F4D9-459B-B45A-EC534F8DB776}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddTextParameter("Port Name", "P", "Port Name", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Bytes", "B", "Bytes", GH_ParamAccess.list);
            pManager.AddBooleanParameter("Send", "S", "Send", GH_ParamAccess.item, false);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddBooleanParameter("Success", "V", "Success", GH_ParamAccess.item);
            }

        protected override void SolveInstance(IGH_DataAccess DA) {
            string name = "";
            List<int> values = new List<int>();
            bool run = false; 

            if (!DA.GetData(0, ref name)) { return; }
            if (!DA.GetDataList(1, values)) { return; }
            if (!DA.GetData(2, ref run)) { return; }

            byte[] bytes = new byte[values.Count];

            for (int i = 0; i < values.Count; i++) {
                bytes[i] = (byte)Math.Max(0, Math.Min(255, values[i]));
                }

            if (run) { DA.SetData(0, SerialMessage.Write(bytes, name)); } 
            }
        }
    }