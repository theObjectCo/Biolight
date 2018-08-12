using System;
using Grasshopper.Kernel;
using Biolight.Brain;

namespace Biolight.GH {
    public class SetBuffers : GH_Component {

        public SetBuffers() : base("Set Buffers", "SetBuff", "Set Buffers", "Biolight", "Serial") { }

        public override Guid ComponentGuid => new Guid("{8DE6EE99-7C0B-463D-8270-3D4457E0ED79}");

        protected override void RegisterInputParams(GH_InputParamManager pManager) {
            pManager.AddIntegerParameter("ReadSize", "R", "Read Buffer Size", GH_ParamAccess.item, 4096);
            pManager.AddIntegerParameter("WriteSize", "W", "Write Buffer Size", GH_ParamAccess.item, 4096);
            pManager.AddBooleanParameter("Run", "R", "Run", GH_ParamAccess.item, false);
            }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager) {
            pManager.AddBooleanParameter("Success", "V", "Success", GH_ParamAccess.item);
            }

        protected override void SolveInstance(IGH_DataAccess DA) {
            int writesize = 100;
            int readsize = 100;
            bool run = false;
             
            if (!DA.GetData(0, ref readsize)) { return; }
            if (!DA.GetData(1, ref writesize)) { return; }
            if (!DA.GetData(2, ref run)) { return; }

            if (run) {
                SerialMessage.ReadBufferSize = readsize;
                SerialMessage.WriteBufferSize = writesize;
                }
            }
        }
    }
