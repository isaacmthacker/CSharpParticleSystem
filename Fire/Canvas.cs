using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fire
{
    /*
    https://stackoverflow.com/questions/27764913/graphics-flickering-when-using-panel-paint-event
    */
    public class Canvas : Control
    {
        public Canvas() { 
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
        public void Canvas_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
