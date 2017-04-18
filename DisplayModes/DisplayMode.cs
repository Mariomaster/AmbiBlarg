using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmbiBlarg.DisplayModes
{
    public partial class DisplayMode : UserControl
    {
        protected bool active;
        protected string name;  // Should be set in constructor

        public DisplayMode()
        {
            InitializeComponent();
        }

        public virtual void cleanUp() { }

        public void activate()
        {
            if (active)
                return;

            active = true;
            _activate();

            Console.WriteLine("Activated " + name);
        }

        public void deactivate()
        {
            if (!active)
                return;

            _deactivate();
            active = false;

            Console.WriteLine("Deactivated " + name);
        }

        public virtual void _activate() { }
        public virtual void _deactivate() { }

        public string getName() { return name; }
        public bool isActive() { return active; }
    }
}
