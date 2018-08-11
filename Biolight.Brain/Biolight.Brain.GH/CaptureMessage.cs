using System;
using Grasshopper.Kernel;
using Biolight.Brain;
using System.Collections.Generic;

namespace Biolight.GH {
    public class CaptureMessage : GH_Component {

        public CaptureMessage() : base("CaptureMessage", "Capture", "Capture Message", "Biolight", "Serial") {
            SerialMessage.MessageReceived += OnMessageReceived;
            }

        public override Guid ComponentGuid => new Guid("{FBF1CF61-07B2-49E8-9B95-86B44472F160}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddTextParameter("Port Name", "P", "Port Name", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Run", "R", "Run", GH_ParamAccess.item, false);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddTextParameter("Message", "M", "Message", GH_ParamAccess.item);
            }

        private SortedList<string, string> mess = new SortedList<string, string>(); 

        protected override void SolveInstance(IGH_DataAccess DA) {
            string name = "";
            bool read = false;

            if (!DA.GetData(0, ref name)) { return; }
            if (!DA.GetData(1, ref read)) { return; }

            if (read) { DA.SetData(0, SerialMessage.Read(name)); }

            }

        private void OnMessageReceived(object sender, MessageEventArgs e) {
            mess[e.PortName] = SerialMessage.Read(e.PortName);
            }

        }

    }