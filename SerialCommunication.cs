using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace WpfBklApp
{
    static class SerialCommunication
    {
        private static string result;
        private static List<char> vs = new List<char>();
        private static SerialPort _serialPort;
        private static string comNr;
        private static bool comPortIsSet;
        

        public static string ComNr
        {
            get { return comNr; }
            set { comNr = value; }
        }

        public static bool ComPortIsSet
        {
            get { return comPortIsSet; }
        }

        public static string HentVaegt()
        {
            result = "";

            _serialPort = new SerialPort
            {
                BaudRate = 19200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.RequestToSend
            };

            _serialPort.PortName = comNr;
            comPortIsSet = true;
            _serialPort.Open();
            _serialPort.Write("p");
            System.Threading.Thread.Sleep(200);
            _serialPort.Write("0");
            System.Threading.Thread.Sleep(200);
            string s = _serialPort.ReadExisting();
            _serialPort.Close();

            foreach (char c in s)
            {
                vs.Add(c);
            }

            vs.RemoveRange(0, vs.LastIndexOf('K') - 7); //Fjern alt undtagen de sidste 8 characters plus det løse. 7 er en arbitrær konstant.

            int a = vs.LastIndexOf('K'); //Find nyt index
            vs.RemoveRange(a, vs.Count - a); //Fjerner alt fra KG og derefter

            foreach (char c in vs)
            {
                result += c;
            }
            result = result.Trim(); //Fjern whitespace
            return result;
        }
    }
}
