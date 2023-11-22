﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.MainAssets;

namespace Tetris.Shapes
{
    class Z: Shape
    {
        private readonly Dictionary<int, ShapeCube[]> states = new Dictionary<int, ShapeCube[]>();

        public Z(int x, int y)
        {
            states.Add(0, new ShapeCube[4] { new ShapeCube(Color.Green, x, 1 +y), new ShapeCube(Color.Green, 1 + x, 1 + y), new ShapeCube(Color.Green, 1 + x, 2 + y), new ShapeCube(Color.Green, 2 + x, 2 + y)});
            states.Add(1, new ShapeCube[4] { new ShapeCube(Color.Green, 2 + x, y), new ShapeCube(Color.Green, 2 + x, 1 + y), new ShapeCube(Color.Green, 1 + x, 1 + y), new ShapeCube(Color.Green, 1 + x, 2 + y)});

            ShapeCubes = states[0];
            CurrentState = 0;

            ShapeX = x;
            ShapeY = y;
        }

        public override int NumberOfCubes { get { return 4; } }
        protected override int NumberOfStates { get { return 2; } }
        protected override int CurrentState { get; set; }
        public override Color Color { get { return Color.Green; } }
        public override int ShapeX { get; set; }
        public override int ShapeY { get; set; }
        public override ShapeCube[] ShapeCubes { get; set; }

        public override void UpdateDic()
        {
            states.Clear();

            int x = ShapeX;
            int y = ShapeY;

            states.Add(0, new ShapeCube[4] { new ShapeCube(Color.Green, x, 1 + y), new ShapeCube(Color.Green, 1 + x, 1 + y), new ShapeCube(Color.Green, 1 + x, 2 + y), new ShapeCube(Color.Green, 2 + x, 2 + y) });
            states.Add(1, new ShapeCube[4] { new ShapeCube(Color.Green, 2 + x, y), new ShapeCube(Color.Green, 2 + x, 1 + y), new ShapeCube(Color.Green, 1 + x, 1 + y), new ShapeCube(Color.Green, 1 + x, 2 + y) });
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

            for (int i = 0; i < NumberOfCubes; i++)
            {
                if (ShapeCubes[i].x >= GlobalData.row)
                {
                    for (int j = 0; j < NumberOfCubes; j++)
                    {
                        ShapeCubes[j].x--;
                    }
                    break;
                }
                else if (ShapeCubes[i].x < 0)
                {
                    for (int j = 0; j < NumberOfCubes; j++)
                    {
                        ShapeCubes[j].x++;
                    }
                }
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
