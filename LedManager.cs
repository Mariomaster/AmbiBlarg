using System;
using System.Drawing;
using System.IO.Ports;

namespace AmbiBlarg
{
    public static class LedManager
    {
        private static Color[] ledColors;
        public static byte ledCount { get; set; }

        public static bool enabled { get; set; }
        public static bool direction { get; set; }

        public static double dim { get; set; }
        public static double rCorrection { get; set; }
        public static double gCorrection { get; set; }
        public static double bCorrection { get; set; }

        public static void init()
        {
            enabled = true;
            direction = false;

            dim = 1.0;

            rCorrection = 1.0;
            gCorrection = 1.0;
            bCorrection = 1.0;

            setLedCount(Properties.Settings.Default.ledCount);
        }

        public static void writeBuffer(SerialPort port)
        {
            byte[] buffer = new byte[ledCount * 3 + 2];
            Array.Clear(buffer, 0, buffer.Length);

            buffer[0] = ledCount;

            if (enabled)
            {
                if (!direction)
                {
                    for (int i = 0; i < ledCount; i++)
                    {
                        buffer[i * 3 + 1] = (byte)(rCorrection * ledColors[i].R * dim);
                        buffer[i * 3 + 2] = (byte)(gCorrection * ledColors[i].G * dim);
                        buffer[i * 3 + 3] = (byte)(bCorrection * ledColors[i].B * dim);
                    }
                }
                else
                {
                    for (int i = ledCount - 1; i >= 0; i--)
                    {
                        buffer[i * 3 + 1] = (byte)(rCorrection * ledColors[ledCount - i - 1].R * dim);
                        buffer[i * 3 + 2] = (byte)(gCorrection * ledColors[ledCount - i - 1].G * dim);
                        buffer[i * 3 + 3] = (byte)(bCorrection * ledColors[ledCount - i - 1].B * dim);
                    }
                }
            }

            port.Write(buffer, 0, buffer.Length);
        }

        public static void setLedCount(byte count)
        {
            ledCount = count;
            ledColors = new Color[count];
        }

        public static void setLed(int index, Color color)
        {
            if (index >= ledCount) return;
            ledColors[index] = color;
        }

        public static void setColor(Color color)
        {
            for (int i = 0; i < ledCount; i++)
                ledColors[i] = color;
        }
    }
}
