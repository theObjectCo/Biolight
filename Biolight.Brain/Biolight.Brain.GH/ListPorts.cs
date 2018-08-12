using System;
using Grasshopper.Kernel;
using Biolight.Brain;
using System.Collections.Generic;

namespace Biolight.GH {
    public class ListPorts : GH_Component {

        public ListPorts() : base("List Ports", "List", "List Ports", "Biolight", "Serial") { }

        public override Guid ComponentGuid => new Guid("{571DD0CE-4A36-4006-8803-C64AB8C95D88}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddBooleanParameter("Refresh", "R", "Refresh", GH_ParamAccess.item, true);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddTextParameter("Ports", "P", "Ports", GH_ParamAccess.list);
            pManager.AddIntegerParameter("ReadSize", "R", "Read Buffer Size", GH_ParamAccess.list);
            pManager.AddIntegerParameter("WriteSize", "W", "Write Buffer Size", GH_ParamAccess.list);
            pManager.AddIntegerParameter("BaudRate", "B", "Baud Rate", GH_ParamAccess.list);
            }

        protected override void SolveInstance(IGH_DataAccess DA) {
            List<int> readBuffer = new List<int>();
            List<int> writeBuffer = new List<int>();
            List<int> bauds = new List<int>();

            foreach (string item in SerialMessage.Ports.Keys) {
                readBuffer.Add(SerialMessage.Ports[item].ReadBufferSize);
                writeBuffer.Add(SerialMessage.Ports[item].WriteBufferSize);
                bauds.Add(SerialMessage.Ports[item].BaudRate);
                }

            DA.SetDataList(0, SerialMessage.GetNames());
            DA.SetDataList(1, readBuffer);
            DA.SetDataList(2, writeBuffer);
            DA.SetDataList(3, bauds);

            }
        }
    }
