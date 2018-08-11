using System;

namespace Biolight.Brain {

    public delegate void MessageHandler(object source, MessageEventArgs e);

    public class MessageEventArgs : EventArgs {
        private string _portName = "";

        public MessageEventArgs(string PortName) {
            this.PortName = PortName;
            }

        public string PortName { get => _portName; set => _portName = value; }
        }

    }
