//  Hreceniuc Larisa
//  3131A
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Input;

using ClearBufferMask = OpenTK.Graphics.OpenGL.ClearBufferMask;
using GL = OpenTK.Graphics.OpenGL.GL;
using MatrixMode = OpenTK.Graphics.OpenGL.MatrixMode;
using PrimitiveType = OpenTK.Graphics.OpenGL.PrimitiveType;


namespace EGC_Proiect
{
    class SimpleWindow : GameWindow
    {
        private int xpixeli = 0, ypixeli = 0;
        private int previousMouseX, previousMouseY;
        // Constructor.
        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
        }
        // Laborator 2 - Exercitiul 2
        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
            // La apasarea sagetii spre stanga (LEFT) imaginea se va deplasa cu 100 de pixeli spre stanga
            if (e.Key == Key.Left)
            {
                xpixeli = xpixeli - 100;
                GL.Viewport(xpixeli, 0, Width, Height);

            }
            // La apasarea sagetii spre dreapta (RIGHT) imaginea se va deplasa cu 100 de pixeli spre dreapta
            if (e.Key == Key.Right)
            {
                xpixeli = xpixeli + 100;
                GL.Viewport(xpixeli, 0, Width, Height);
            }

            MouseState mouse = Mouse.GetState();
            if (mouse[MouseButton.Left])
            {
                base.OnResize(e);
                GL.Viewport(0, 0, Width, Height);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
            previousMouseX = Mouse.GetCursorState().X; ;
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            // Laborator 2 - Exercitiul 1
            GL.MatrixMode(MatrixMode.Texture);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }
        protected void Move_with_Mouse()
        {
            // Obține poziția curentă a mouse-ului
            int currentMouseX = Mouse.GetCursorState().X;
            int currentMouseY = Mouse.GetCursorState().Y;
            // Calculează schimbarea poziției mouse-ului
            int diferenceX = currentMouseX - previousMouseX;
            int diferenceY = currentMouseY - previousMouseY;
            // Verifică direcția mișcării
            if (currentMouseX == previousMouseX)
            {
                GL.Viewport(xpixeli, ypixeli, Width, Height);
            }
            else
            {
                if (diferenceX > 10)
                {
                    xpixeli = xpixeli + 10;
                    GL.Viewport(xpixeli, ypixeli, Width, Height);
                    previousMouseX = currentMouseX;
                }
                if (diferenceX < 0)
                {
                    xpixeli = xpixeli - 10;
                    GL.Viewport(xpixeli, ypixeli, Width, Height);
                    previousMouseX = currentMouseX;
                }
            }
            if (currentMouseY == previousMouseY)
            {
                GL.Viewport(xpixeli, ypixeli, Width, Height);
            }
            else
            {
                if (diferenceY > 10)
                {
                    ypixeli = ypixeli + 10;
                    GL.Viewport(xpixeli, ypixeli, Width, Height);
                    previousMouseY = currentMouseY;
                }
                if (diferenceX < 0)
                {
                    ypixeli = ypixeli - 10;
                    GL.Viewport(xpixeli, ypixeli, Width, Height);
                    previousMouseY = currentMouseY;
                }
            }

        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            Move_with_Mouse();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {


            using (SimpleWindow example = new SimpleWindow())
            {

                example.Run(30.0, 0.0);
            }
        }
    }
}
