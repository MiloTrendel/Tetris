using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.MainAssets;

namespace Tetris.Shapes
{
    class O : Shape
    {
        public O(int x, int y)
        {
            ShapeCubes = new ShapeCube[4] { new ShapeCube(Color.Yellow, x, y), new ShapeCube(Color.Yellow, 1 + x, y), new ShapeCube(Color.Yellow, x, 1 + y), new ShapeCube(Color.Yellow, 1 + x, 1 + y) };

            ShapeX = x;
            ShapeY = y;
        }
        public override int NumberOfCubes { get { return 4; } }
        protected override int NumberOfStates { get { return 1; } }
        protected override int CurrentState { get; set; }
        public override Color Color { get { return Color.Yellow; } }
        public override int ShapeX { get; set; }
        public override int ShapeY { get; set; }
        public override ShapeCube[] ShapeCubes { get; set; }
        public override void UpdateDic() { }

        public override void Rotate90(){ }

        public override void RotateMin90() { }
    }
}
