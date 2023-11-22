using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris.MainAssets
{
    class MainGrid : PictureBox
    {
        public MainGrid(Size size, Point loc)
        {
            Size = size;
            BackColor = Color.Black;
            Location = loc;
        }
    }
}
