using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace Ejercicio_1_Guía_6
{
    class Arbol_Binario
    {
        public Nodo_Arbol Raiz;
        public Nodo_Arbol aux;
        public int prueba = 1;


        public Arbol_Binario()
        {
            aux = new Nodo_Arbol();
        }

        //Función para añadir un dato si en cierto caso el árbol esta vacío
        public Arbol_Binario(Nodo_Arbol nueva_raiz)
        {
            Raiz = nueva_raiz;
        }



        //Función para agregar un nuevo valor (nodo) al árbol binario
        public void Insertar(int x)
        {

            if (Raiz == null)
            {
                Raiz = new Nodo_Arbol(x, null, null, null);
                Raiz.nivel = 0;
            }
            else
                Raiz = Raiz.Insertar(x, Raiz, Raiz.nivel);


        }

        //Función para eliminar un valor (nodo) del árbol binario
        public void Eliminar(int x)
        {
            if (Raiz == null)
                Raiz = new Nodo_Arbol(x, null, null, null);
            else
                Raiz.Eliminar(x, ref Raiz);

        }

        //Función para buscar
        public void Buscar(int x)
        {
            if (Raiz != null)
            {
                Raiz.buscar(x, Raiz);
            }
        }


        //==================================================================//
        //      Funciones para dibujar el árbol en el formulario
        //==================================================================//
        public void DibujarArbol(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro)
        {
            int x = 200; //Posición inicial de la raíz del árbol
            int y = 220;
            if (Raiz == null)
                return;
            Raiz.PosicionNodo(ref x, y); //Posición de cada nodo
            Raiz.DibujarRamas(grafo, Lapiz); //Dibuja las líneas entre los nodos

            //Para dibujar todos los nodos
            Raiz.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
        }

        //Posiciones iniciales de la raíz del árbol
        public int x1 = 200;
        public int y2 = 220;

        //Función para colorear los nodos
        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Nodo_Arbol Raiz, bool post, bool inor, bool preor)
        {
            //Inor==>Inorden
            //Preor==>Preorden
            //Pos==>Postorden
            Brush entorno = Brushes.Red;
            if (inor == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, Relleno, Lapiz);
                    Thread.Sleep(1000); //Pausa la ejecución 1000 milisegundos

                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor, preor);

                }

            }
            else
                if (preor == true)
            {
                if (Raiz != null)
                {
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000); //Pausa la ejecución 1000 milisegundos

                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor, preor)
; }
            }
            else
                if (post == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000);//Pausa la ejecución 1000 milisegundos
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                }
            }

        }
    





    }
}
