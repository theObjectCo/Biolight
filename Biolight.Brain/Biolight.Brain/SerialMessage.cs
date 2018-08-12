using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Biolight.Brain {

    public static class SerialMessage {
        private static SortedList<string, SerialPort> ports = new SortedList<string, SerialPort>();

        public static SortedList<string, SerialPort> Ports { get => ports; set => ports = value; }

        public static List<string> GetNames() {
            return new List<string>(Ports.Keys);
            }

        public static bool AddPort(string PortName, int BaudRate) {
            try {
                if (!Ports.ContainsKey(PortName)) {
                    SerialPort newPort = new SerialPort(PortName, BaudRate);
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
            if (thisPort == null) { return false; }
            thisPort.Write(bytes, 0, bytes.Length);
            return true;
            }

        public static byte[] Read(string PortName) {
            if (!Ports.ContainsKey(PortName)) { return null; }
            SerialPort thisPort = Ports[PortName];
            if (thisPort == null) { return null; }
            byte[] buffer = new byte[thisPort.BytesToRead];
            thisPort.Read(buffer, 0, thisPort.BytesToRead);
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