using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Proyecto1_01;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class Game : GameWindow
    {
        private Camera camera;
        Punto p = new Punto();
        Escenario a = new Escenario(30,15,-15);//derecha arriba fondo
        Escenario b = new Escenario(30,-40,15);//derecha abajo frente
        Escenario c = new Escenario(-30,-40,15);//izquierda abajo frente
        Escenario d = new Escenario(-30,15,-15);//izquierda arriba fondo
        
        //-----------------------------------------------------------------------------------------------------------------
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            camera.Update(e);
            base.OnUpdateFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.SeaGreen);

            // Configura la cámara con la posición inicial y velocidad
            Vector3 initialPosition = new Vector3(0, 0, 3); // Posición inicial
            Vector3 initialFront = new Vector3(0, 0, -1);  // Dirección hacia donde mira
            Vector3 initialUp = Vector3.UnitY; // Vector "arriba"
            float cameraSpeed = 0.08f; // Velocidad de movimiento
            /////////////////////////////////

            // Coordenada x,y,z
            // ancho, alto, profundidad, color
            a.Construir();
            b.Construir();
            c.Construir();
            d.Construir();
            ///
            camera = new Camera(initialPosition, initialFront, initialUp, cameraSpeed);
            //////////////////////////////////////////////////////////////////////////
            base.OnLoad(e);     
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            //
            /////CAMARA//////////////////////////
            // Configura la matriz de vista (View Matrix) para cambiar la vista
            Matrix4 viewMatrix = camera.GetViewMatrix();
            // Configura la matriz de vista
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref viewMatrix);
            /////CAMARA//////////////////////////
            //---------------------
            
            /////////////////////////////////////////////////

            a.Dibujar();
            b.Dibujar();
            c.Dibujar();
            d.Dibujar();
            //
            // Dibuja los ejes de coordenadas
            GL.LineWidth(2.0f); // Cambia 2.0f al grosor deseado
            GL.Begin(PrimitiveType.Lines);

            // Eje X (rojo)
            GL.Color3(Color.Red); // Rojo
            GL.Vertex3(0.0f, 0.0f, 0.0f); // Origen
            GL.Vertex3(80f, 0.0f, 0.0f); // Punto en X positivo

            // Eje Y (verde)
            GL.Color3(Color.Green); // Verde
            GL.Vertex3(0.0f, 0.0f, 0.0f); // Origen
            GL.Vertex3(0.0f, 80f, 0.0f); // Punto en Y positivo

            // Eje Z (azul)
            GL.Color3(Color.Blue); // Azul
            GL.Vertex3(0.0f, 0.0f, 0.0f); // Origen
            GL.Vertex3(0.0f, 0.0f, 80f); // Punto en Z positivo

            GL.End();
            ///////////////////////////////////////////////
            //

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            float d = 80;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -45, 45, -d, d);//16:9
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }
        private void DrawCircle(float x, float y, float z, float radius, int segments)
        {
            //GL.Rotate(-5, 1, 1, 0);
            GL.Color4(Color4.Pink);
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Vertex3(x, y, z);

            for (int i = 0; i <= segments; i++)
            {
                float angle = 2.0f * MathHelper.Pi * i / segments;
                float xVertex = x + radius * (float)Math.Cos(angle);
                float yVertex = y + radius * (float)Math.Sin(angle);
                GL.Vertex3(xVertex, yVertex, z);
            }

            GL.End();
        }


    }
}
