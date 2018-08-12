using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Biolight.Brain {

    public static class SerialMessage {
        private static SortedList<string, SerialPort> ports = new SortedList<string, SerialPort>();
        public static event MessageHandler MessageReceived;

        public static SortedList<string, SerialPort> Ports { get => ports; set => ports = value; }
        public static int ReadBufferSize { get => readBufferSize; set => readBufferSize = value; }
        public static int WriteBufferSize { get => writeBufferSize; set => writeBufferSize = value; }

        private static int readBufferSize;
        private static int writeBufferSize;

        public static List<string> GetNames() {
            return new List<string>(Ports.Keys);
            }
          
        public static bool AddPort(string PortName, int BaudRate) {
            try {
                if (!Ports.ContainsKey(PortName)) {
                    SerialPort newPort = new SerialPort(PortName, BaudRate);
                    newPort.DtrEnable = true;
                    newPort.RtsEnable = true;
                    newPort.ReadBufferSize = readBufferSize;
                    newPort.WriteBufferSize = writeBufferSize;
                    if (!newPort.IsOpen) { newPort.Open(); }
                    Ports.Add(PortName, newPort);
                    }
                return true;
                }
            catch (Exception) {
                return false;
                throw;
                }
            }

        public static bool Write(byte[] bytes, string PortName) {
            if (!Ports.ContainsKey(PortName)) { return false; }
            SerialPort thisPort = Ports[PortName];
            thisPort.Write(bytes, 0, bytes.Length);
            return true;
            }

        public static byte[] Read(string PortName) {
            if (!Ports.ContainsKey(PortName)) { return null; }
            SerialPort thisPort = Ports[PortName];
            if (thisPort == null) { return null; }
            byte[] buffer = new byte[thisPort.ReadBufferSize];
            thisPort.Read(buffer, 0, thisPort.ReadBufferSize);
            return buffer;
            }

        public static bool CloseAll() {
            foreach (string item in Ports.Keys) {
                Ports[item].Close();
                Ports[item].Dispose();
                }
            Ports.Clear();
            return true;
            }
        }

    }