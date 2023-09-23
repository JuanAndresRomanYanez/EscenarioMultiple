using Proyecto1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_01{
    public class Escenario{
        public Punto p;
        public Cubo cubo, cubo2, cubo3, cubo4, cubo5, cubo6, cubo7, cubo8, cubo9;
        //Constructores
        public Escenario()
        {
            this.p = new Punto();

        }
        public Escenario(float x, float y, float z)
        {
            this.p = new Punto(x, y, z);
        }
        public Escenario(Punto p)
        {
            this.p = new Punto(p);
        }
        public void Construir()
        {
            //Pared
            cubo = new Cubo(new Punto(p.x + 0, p.y + 0, p.z + 0), 1, 22, 30, Color.Brown);
            //Repisa
            cubo2 = new Cubo(new Punto(p.x - 7, p.y + 10, p.z + 0), 5, 2, 15, Color.RosyBrown);
            //Chasis
            cubo3 = new Cubo(new Punto(p.x - 5, p.y + 15, p.z + 0), 3, 2, 12, Color.Blue);
            //chasis arriba
            cubo4 = new Cubo(new Punto(p.x - 5, p.y + 20, p.z + 0), 3, 3, 5, Color.Blue);
            // Ventana
            cubo5 = new Cubo(new Punto(p.x - 5, p.y + 20, p.z + 1), 2, 2, 5, Color.White);
            //Llanta izquierda
            cubo6 = new Cubo(new Punto(p.x - 5, p.y + 14, p.z + 6), 4, 2, 2, Color.Black);//profundidad x
            //Llanta derecha
            cubo7 = new Cubo(new Punto(p.x - 5, p.y + 14, p.z - 6), 4, 2, 2, Color.Black);
            // Luz derecha
            cubo8 = new Cubo(new Punto(p.x - 3, p.y + 15, p.z + 10), 1, 1, 4, Color.Yellow);
            // Luz izquierda
            cubo9 = new Cubo(new Punto(p.x - 7, p.y + 15, p.z + 10), 1, 1, 4, Color.Yellow);
        }
        public void Dibujar()
        {
            //-----------------------
            //pared
            this.cubo.Dibujar();
            //Repisa
            this.cubo2.Dibujar();
            //Parte de abajo del chasis
            this.cubo3.Dibujar();
            //Parte de arriba del chasis
            this.cubo4.Dibujar();
            //Ventana
            this.cubo5.Dibujar();
            //Llanta izquierda
            this.cubo6.Dibujar();
            //Llanta derecha
            this.cubo7.Dibujar();
            //Luz izquierda
            this.cubo8.Dibujar();
            //Luz derecha
            this.cubo9.Dibujar();
            //DrawCircle(-4,14,-2,3,100);
            //DrawCircle(-4, 14, 6, 3, 100);
            //this.cubo4.Dibujar();
            //-----------------------
        }

    }
}
