using System;
using Grasshopper.Kernel;
using Biolight.Brain;
using System.Collections.Generic;
using Grasshopper.Kernel.Types;

namespace Biolight.GH {
    public class ReadMessage : GH_Component {

        public ReadMessage() : base("ReadMessage", "Read", "Read Message", "Biolight", "Serial") { }

        public override Guid ComponentGuid => new Guid("{D8CC0650-2934-4749-A87F-9BFEB9E15B95}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddTextParameter("Port Name", "P", "Port Name", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Read", "R", "Read", GH_ParamAccess.item, false);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddIntegerParameter("Message", "M", "Message", GH_ParamAccess.list);
            }

        protected override void SolveInstance(IGH_DataAccess DA) {
            string name = "";
            bool read = false;

            if (!DA.GetData(0, ref name)) { return; }
            if (!DA.GetData(1, ref read)) { return; }

            if (!read) { return; }

            byte[] message = SerialMessage.Read(name);
            if (message == null) { return;  }

            List<GH_Integer> ints = new List<GH_Integer>();

            for (int i = 0; i < message.Length; i++) {
                ints.Add(new GH_Integer(message[i]));
                }

            DA.SetDataList(0, ints); 
            }
        }
    }