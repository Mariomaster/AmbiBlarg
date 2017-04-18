using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace AmbiBlarg
{
    public static class ArduinoCommunication
    {
        private static SerialPort port;
        private static Thread looper;
        private static bool quit = false;

        private static SetTextDelegate sdsDelegate;

        static bool connected = false;

        public static void init(SetTextDelegate sdsDelegate)
        {
            ArduinoCommunication.sdsDelegate = sdsDelegate;
            looper = new Thread(new ThreadStart(loop));
            looper.Start();
        }

        public static void cleanUp()
        {
            quit = true;
            while (looper.IsAlive) { Application.DoEvents(); }
        }

        private static void loop()
        {
            // Looking over this again makes me think if it's really that smart to push as many data through the sereal port as possible :P
            // Who cares though. *shrug*
            while (true)
            {
                if (connected)
                {
                    try
                    {
                        port.Write("BLed");

                        byte[] cmd = { 0x00 };               // Cmd
                        port.Write(cmd, 0, cmd.Length);

                        LedManager.writeBuffer(port);

                        if (quit)
                        {
                            byte[] bufferAbort = { 0x01 };
                            port.Write(bufferAbort, 0, 1);
                            port.Close();
                            break;
                        }

                        while (port.BytesToWrite != 0 || port.BytesToRead != 13) { }

                        string ret = getSerialString();
                        if (ret == "BLed_accepted") continue;
                        else
                        {
                            connected = false;
                            port.Close();
                        }
                    }
                    catch (Exception) { port.Close(); connected = false; }
                }
                else
                {
                    sdsDelegate("Scanning...");
                    if (quit) break;
                    if (!getComPort()) Thread.Sleep(10);
                    else sdsDelegate("Connected (" + port.PortName + ")");
                }
            }
        }

        private static bool getComPort()
        {
            connected = false;

            string[] ports = SerialPort.GetPortNames();

            foreach (string portName in ports)
            {
                SerialPort testPort = new SerialPort(portName, 115200);

                if (detectArduino(testPort))
                {
                    port = testPort;
                    connected = true;
                    return true;
                }
            }

            return false;
        }

        private static bool detectArduino(SerialPort testPort)
        {
            try
            {
                int intReturnASCII = 0;
                char charReturnValue = (Char)intReturnASCII;

                testPort.Open();

                testPort.Write("BLed_init");
                Thread.Sleep(10);

                int count = testPort.BytesToRead;
                string returnMessage = "";
                while (count > 0)
                {
                    intReturnASCII = testPort.ReadByte();
                    returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                    count--;
                }

                if (returnMessage == "BLed_handshake") return true;
                testPort.Close();
            }
            catch (Exception) { }
            return false;
        }

        private static String getSerialString()
        {
            int intReturnASCII = 0;
            char charReturnValue = (Char)intReturnASCII;

            int count = port.BytesToRead;
            string returnMessage = "";
            while (count > 0)
            {
                intReturnASCII = port.ReadByte();
                returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                count--;
            }

            return returnMessage;
        }
    }
}
