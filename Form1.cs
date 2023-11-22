using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tetris.MainAssets;
using Tetris.Shapes;
using Timer = System.Windows.Forms.Timer;

namespace Tetris
{
    public partial class Form1 : Form
    {
        MainGrid mnGrid;

        Shape currentShape;
        List<ShapeCube> cubeList;


        Timer timer;
        public Form1()
        {
            InitializeComponent();

            cubeList = new List<ShapeCube>() { new ShapeCube(Color.Blue, 2, 19)};

            timer = new Timer();
            timer.Interval = 600;
            timer.Tick += new EventHandler(TimerUpdate);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(1000, 830);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            mnGrid = new MainGrid(new Size(350, 700), new Point(325, 80));
            mnGrid.Paint += new PaintEventHandler(PaintShapes);

            currentShape = new L(3, -1);

            timer.Start();

            this.KeyDown += new KeyEventHandler(Key_Press);
            this.KeyUp += new KeyEventHandler(Key_Up);

            Controls.Add(mnGrid);
        }

        private void TimerUpdate(object sender, EventArgs e)
        {
            if (!CheckCollisionsDown(0, 1)) MoveCurrentShape(0, 1);
            else
            {
                AddShapeToList();
                NextShape();
            }

            this.Refresh();
        }

        private void Key_Press(object sender, KeyEventArgs e)
        {
            currentShape.UpdateDic();
            if (e.KeyCode == Keys.Right)
            {
                if (!CheckCollisionsSide(1, 0))
                {
                    MoveCurrentShape(1, 0);
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (!CheckCollisionsSide(-1, 0))
                {
                    MoveCurrentShape(-1, 0);
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                timer.Interval = 150;
            }
            else if (e.KeyCode == Keys.Up)
            {
                currentShape.Rotate90();
            }

            this.Refresh();
        }

        private void Key_Up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                timer.Interval = 600;
            }
        }

        private void NextShape()
        {
            Random rand = new Random();

            switch (rand.Next(0, 7))
            {
                case 0:
                    currentShape = new I(3, 0);
                    break;

                case 1:
                    currentShape = new O(4, 0);
                    break;

                case 2:
                    currentShape = new J(3, -1);
                    break;

                case 3:
                    currentShape = new L(3, -1);
                    break;

                case 4:
                    currentShape = new S(3, -1);
                    break;

                case 5:
                    currentShape = new Z(3, -1);
                    break;

                case 6:
                    currentShape = new T(3, -1);
                    break;
            }
                 
        }

        private void PaintShapes(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            for (int i = 0; i < currentShape.NumberOfCubes; i++)
            {
                g.FillRectangle(new SolidBrush(currentShape.Color), currentShape.ShapeCubes[i].x * GlobalData.cubeSize, currentShape.ShapeCubes[i].y * GlobalData.cubeSize, GlobalData.cubeSize, GlobalData.cubeSize);
            }

            for (int i = 0; i < cubeList.Count; i++)
            {
                g.FillRectangle(new SolidBrush(cubeList[i].color), cubeList[i].x * GlobalData.cubeSize, cubeList[i].y * GlobalData.cubeSize, GlobalData.cubeSize, GlobalData.cubeSize);
            }
        }

        private void MoveCurrentShape(int directionX, int directionY)
        {
            for (int i = 0; i < currentShape.NumberOfCubes; i++)
            {
                currentShape.ShapeCubes[i].x += directionX;
                currentShape.ShapeCubes[i].y += directionY;
            }
            currentShape.ShapeX += directionX;
            currentShape.ShapeY += directionY;
        }

        private bool CheckCollisionsDown(int directionX, int directionY)
        {
            for (int i = 0; i < currentShape.NumberOfCubes; i++)
            {
                if (currentShape.ShapeCubes[i].y + directionY >= GlobalData.row)
                    return true;
               
                for(int j = 0; j < cubeList.Count; j++)
                {
                    if (currentShape.ShapeCubes[i].x + directionX == cubeList[j].x && currentShape.ShapeCubes[i].y + directionY == cubeList[j].y)
                        return true;
                }
            }

            return false;
        }

        private bool CheckCollisionsSide(int directionX, int directionY)
        {
            for (int i = 0; i < currentShape.NumberOfCubes; i++)
            {
                if (currentShape.ShapeCubes[i].x + directionX >= GlobalData.column || currentShape.ShapeCubes[i].x + directionX < 0)
                    return true;
            }

            return false;
        }

        private void AddShapeToList()
        {
            for (int i = 0; i < currentShape.NumberOfCubes; i++)
            {
                cubeList.Add(currentShape.ShapeCubes[i]);
            }
        }

        private void Tetris()
        {
            int[][] cubeCoords = new int[20][];
            foreach (ShapeCube cube in cubeList)
            {
                //cubeCoords[cube.y][cubeCoords.Length - 1] = cube;
            }
        }
    }
}
