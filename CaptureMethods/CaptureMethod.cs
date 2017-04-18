using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbiBlarg.CaptureMethods
{
    public class CaptureMethod
    {
        protected bool _isRunning;
        protected int c_monitor;
        protected int c_width;
        protected int c_height;

        protected int c_speed;

        public byte[] c_array;

        public virtual void start() { _isRunning = true; }
        public virtual void stop() { _isRunning = false; }
        public bool isRunning() { return _isRunning; }

        public virtual void setMonitor(int c_monitor) { this.c_monitor = c_monitor; }
    }
}
