﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris.MainAssets
{
    class ShapeCube : Panel
    {
        public int x;
        public int y;
        public Color color { get; }
        public ShapeCube(Color color, int x, int y)
        {
            this.color = color;
            BackColor = color;
            Size = new Size(GlobalData.cubeSize, GlobalData.cubeSize);
            this.x = x;
            this.y = y;
        }
    }
}
