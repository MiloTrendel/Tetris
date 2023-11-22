using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Tetris.MainAssets;

namespace Tetris.Shapes
{
    class T : Shape
    {
        private readonly Dictionary<int, ShapeCube[]> states = new Dictionary<int, ShapeCube[]>();

        public T(int x, int y)
        {
            states.Add(0, new ShapeCube[4] {new ShapeCube(Color.Cyan, x, 1 + y), new ShapeCube(Color.Cyan,1 + x, 1 + y), new ShapeCube(Color.Cyan, 2 + x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, 2 + y)});
            states.Add(1, new ShapeCube[4] {new ShapeCube(Color.Cyan, x, 1 + y), new ShapeCube(Color.Cyan,1 + x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, y), new ShapeCube(Color.Cyan, 1 + x, 2 + y)});
            states.Add(2, new ShapeCube[4] {new ShapeCube(Color.Cyan, x, 1 + y), new ShapeCube(Color.Cyan,1 + x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, y), new ShapeCube(Color.Cyan, 2 + x, 1 + y)});
            states.Add(3, new ShapeCube[4] {new ShapeCube(Color.Cyan, 1 + x, 2 + y), new ShapeCube(Color.Cyan,1 + x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, y), new ShapeCube(Color.Cyan, 2 + x, 1 + y)});

            ShapeCubes = states[0];
            CurrentState = 0;

            ShapeX = x;
            ShapeY = y;
        }

        public override int NumberOfCubes { get { return 4; } }
        protected override int NumberOfStates { get { return 4; } }
        protected override int CurrentState { get; set; }
        public override Color Color { get { return Color.Cyan; } }
        public override int ShapeX { get; set; }
        public override int ShapeY { get; set; }
        public override ShapeCube[] ShapeCubes { get; set; }

        public override void UpdateDic()
        {
            states.Clear();

            int x = ShapeX;
            int y = ShapeY;

            states.Add(0, new ShapeCube[4] { new ShapeCube(Color.Cyan, x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, 1 + y), new ShapeCube(Color.Cyan, 2 + x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, 2 + y) });
            states.Add(1, new ShapeCube[4] { new ShapeCube(Color.Cyan, x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, y), new ShapeCube(Color.Cyan, 1 + x, 2 + y) });
            states.Add(2, new ShapeCube[4] { new ShapeCube(Color.Cyan, x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, y), new ShapeCube(Color.Cyan, 2 + x, 1 + y) });
            states.Add(3, new ShapeCube[4] { new ShapeCube(Color.Cyan, 1 + x, 2 + y), new ShapeCube(Color.Cyan, 1 + x, 1 + y), new ShapeCube(Color.Cyan, 1 + x, y), new ShapeCube(Color.Cyan, 2 + x, 1 + y) });
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
