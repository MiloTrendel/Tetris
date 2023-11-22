using Tetris.MainAssets;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Tetris.Shapes
{
    class I : Shape
    {
        private readonly Dictionary<int, ShapeCube[]> states = new Dictionary<int, ShapeCube[]>();

        public override ShapeCube[] ShapeCubes { get; set; }
        public I(int x, int y)
        {
            CurrentState = 0;

            states.Add(0, new ShapeCube[] { new ShapeCube(Color.Red, x, 1 + y), new ShapeCube(Color.Red, 1 + x, 1 + y), new ShapeCube(Color.Red, 2 + x, 1 + y), new ShapeCube(Color.Red, 3 + x, 1 + y) });
            states.Add(1, new ShapeCube[] { new ShapeCube(Color.Red, 2 + x, y), new ShapeCube(Color.Red, 2 + x, 1 + y), new ShapeCube(Color.Red, 2 + x, 2 + y), new ShapeCube(Color.Red, 2 + x, 3 + y) });

            ShapeCubes = states[0];

            ShapeX = x;
            ShapeY = y;
        }

        public override int NumberOfCubes { get { return 4; } }
        protected override int NumberOfStates { get { return 2; } }
        protected override int CurrentState { get; set; }
        public override Color Color{ get { return Color.Red; } }
        public override int ShapeX { get; set; }
        public override int ShapeY { get; set; }

        public override void UpdateDic()
        {
            states.Clear();

            int x = ShapeX;
            int y = ShapeY;
            states.Add(0, new ShapeCube[] { new ShapeCube(Color.Red, x, 1 + y), new ShapeCube(Color.Red, 1 + x, 1 + y), new ShapeCube(Color.Red, 2 + x, 1 + y), new ShapeCube(Color.Red, 3 + x, 1 + y) });
            states.Add(1, new ShapeCube[] { new ShapeCube(Color.Red, 2 + x, y), new ShapeCube(Color.Red, 2 + x, 1 + y), new ShapeCube(Color.Red, 2 + x, 2 + y), new ShapeCube(Color.Red, 2 + x, 3 + y) });
        }

        public override void Rotate90()
        {
            if (CurrentState + 1 == NumberOfStates)
            {
                ShapeCubes = states[0];
                CurrentState = 0;
            }
            else
            {
                ShapeCubes = states[CurrentState + 1];
                CurrentState++;
            }
        }

        public override void RotateMin90()
        {
            if (CurrentState - 1 < 0)
            {
                ShapeCubes = states[0];
                CurrentState = NumberOfStates;
            }
            else
            {
                ShapeCubes = states[CurrentState - 1];
                CurrentState--;
            }
        }
    }
}
