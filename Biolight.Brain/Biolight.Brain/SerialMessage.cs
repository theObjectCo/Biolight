using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Biolight.Brain {

    public static class SerialMessage {
        private static SortedList<string, SerialPort> ports = new SortedList<string, SerialPort>();

        public static event MessageHandler MessageReceived; 

        public static List<string> GetNames() {
            return new List<string>(ports.Keys);
            }

        public static bool AddPort(string PortName, int BaudRate) {
            try {
                if (!ports.ContainsKey(PortName)) {
                    ports.Add(PortName, new SerialPort(PortName, BaudRate));
                    ports[PortName].DataReceived += OnDataReceived;
                    }

                return true;
                }
            catch (Exception) {
                return false;
                throw;
                }
            }

        private static void OnDataReceived(object sender, SerialDataReceivedEventArgs e) {
            SerialPort thisPort = (SerialPort)sender;  
            MessageReceived?.Invoke(sender, new MessageEventArgs(thisPort.PortName));
            }

        public static bool Write(byte[] bytes, string PortName) {

           if (!ports.ContainsKey(PortName)) { return false; }
            SerialPort thisPort = ports[PortName];
            if (!thisPort.IsOpen) { thisPort.Open(); }
            thisPort.Write(bytes, 0, bytes.Length);
            return true;
            }

        public static string Read(string PortName) {
            if (!ports.ContainsKey(PortName)) { return ""; }
            SerialPort thisPort = ports[PortName];
            if (thisPort == null) { return ""; }
            string inData = thisPort.ReadExisting();
            return inData;
            }

        public static bool CloseAll() {
            foreach (string item in ports.Keys) {
                ports[item].DataReceived -= OnDataReceived; 
                ports[item].Close();
                ports[item].Dispose();
                }
            ports.Clear();
            return true;
            }
        }

    } 