using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.MainAssets;

namespace Tetris.Shapes
{
    abstract class Shape
    {
        public abstract int NumberOfCubes { get; }
        protected abstract int NumberOfStates { get; }
        protected abstract int CurrentState { get; set; }
        public abstract Color Color { get; }
        public abstract int ShapeX { get; set; }
        public abstract int ShapeY { get; set; }
        public abstract ShapeCube[] ShapeCubes { get; set; }
        public abstract void Rotate90();
        public abstract void RotateMin90();
        public abstract void UpdateDic();

        public ShapeCube[] TransformCubesLoc(ShapeCube[] shapeCubes)
        {
            for (int i = 0; i < ShapeCubes.Length; i++)
            {
                shapeCubes[i].x += ShapeX;
                shapeCubes[i].y += ShapeY;
            }

            return shapeCubes;
        }
    }
}
