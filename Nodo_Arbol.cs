using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Ejercicio_1_Guía_6
{
    class Nodo_Arbol
    {
        public int info; //Objeto para almacenar la información de cada nodo
        public Nodo_Arbol Izquierdo; //Nodo izquiero del árbol
        public Nodo_Arbol Derecho; //Nodo derecho del árbol
        public Nodo_Arbol Padre; //Nodo padre o nodo raíz del árbol
        public int altura;
        public int nivel;
        public Rectangle nodo; //Objeto para dibujar el nodo del árbol


        //Variable para definir el tamaño de los circulos que van a representar los nodos del árbol
        private const int Radio = 30;

        //Variable para manejar la distancia horizontal
        private const int DistanciaH = 80;

        //Variable para manerjar la distancia vertical
        private const int DistanciaV = 10;

        //Variable que maneja la posición en X
        private int CoordenadaX;

        //Variable que maneja la posición en Y
        private int CoordenadaY;

        Graphics col;
        private Arbol_Binario arbol;

        //Constructor por defecto
        public Nodo_Arbol() { }
        
        //Constructor por defecto para el objeto de tipo arbol
        public Arbol_Binario Arbol
        {
            get { return arbol; }
            set { arbol = value; }
        }
        //=================================================================//
        // Constructor que toma 4 parámetros, es el más importante de todos
        //=================================================================//
        public Nodo_Arbol (int nueva_info,Nodo_Arbol izquierdo,Nodo_Arbol derecho, Nodo_Arbol padre)
        {
            info = nueva_info;
            Izquierdo = izquierdo;
            Derecho = derecho;
            Padre = padre;
            altura = 0;
        }

        //============================================================
        //Cambios hechos:
        
        public List<int> listaPreorden = new List<int>();
        public List<int> listaInorden = new List<int>();
        public List<int> listaPostorden = new List<int>();

        public void preorden(Nodo_Arbol nodo)
        {

            if(nodo != null)
            {
                listaPreorden.Add(nodo.info);
                preorden(nodo.Izquierdo);
                preorden(nodo.Derecho);
            }

        }

        public void inorden(Nodo_Arbol nodo)
        {

            if(nodo != null)
            {
                inorden(nodo.Izquierdo);
                listaInorden.Add(nodo.info);
                inorden(nodo.Derecho);
            }
        }

        public void postorden(Nodo_Arbol nodo)
        {

            if(nodo != null)
            {
                postorden(nodo.Izquierdo);
                postorden(nodo.Derecho);
                listaPostorden.Add(nodo.info);
            }
        }

        //=============================================================

        //===========================================//
        // Método para insertar un nodo en el árbol
        //===========================================//
        public Nodo_Arbol Insertar(int x, Nodo_Arbol t, int Level)
        {
            // "x" Es el nuevo dato a ingresar
            // "t" es la raíz
            if (t == null) 
            {
                t = new Nodo_Arbol(x, null, null, null);
                t.nivel = Level;
            }
            else if (x < t.info) //Si el valor que se desea insertar es menor que la raíz
            {
                Level++;
                t.Izquierdo = Insertar(x, t.Izquierdo, Level);
            }
            else if(x > t.info) //Si el valor que se desea insertar es mayor que la raíz
            {
                Level++;
                t.Derecho = Insertar(x, t.Derecho, Level);
            }
            else
            {
                MessageBox.Show("Hola Rey ese dato ya existe en el árbol, pruebe con otro","Error de Ingreso");
            }
            return t;
        }

        //Método para verificar la altura del árbol
        public static int Alturas(Nodo_Arbol t)
        {
            return t == null ? -1 : t.altura;
        }

        public void encontrado(Nodo_Arbol t)
        {
            Rectangle rec = new Rectangle(t.CoordenadaX, t.CoordenadaY, 40, 40);
        }


        //====================================================//
        // Función para eliminar un nodo en el árbol binario
        //====================================================//
        public void Eliminar(int x, ref Nodo_Arbol t)
        {
            listaInorden.Clear();
            listaPostorden.Clear();
            listaPreorden.Clear();

            if(t != null) //Si la raíz es diferente de null
            {
                if( x < t.info) // Si el valor a eliminar es menor que la raíz
                {
                    Eliminar(x, ref t.Izquierdo);

                }

                else
                {
                    if (x > t.info)  //Si el valor a eliminar es mayor que la raíz
                    {
                        Eliminar(x, ref t.Derecho);
                    }
                    else
                    {
                        Nodo_Arbol NodoEliminar = t; // Se ubica el nodo a eliminar

                        //Se verifica si tiene hijo derecho
                        if(NodoEliminar.Derecho == null)
                        {
                            t = NodoEliminar.Izquierdo;
                        }
                        else
                        {
                            //Verificando si tiene hijo izquierdo
                            if(NodoEliminar.Izquierdo == null)
                            {
                                t = NodoEliminar.Derecho;
                            }
                            else
                            {
                                //Para verificar que hijo va a pasara ser nueva raíz del subárbol
                                if (Alturas(t.Izquierdo) - Alturas(t.Derecho) > 0) 
                                {
                                    Nodo_Arbol AuxiliarNodo = null;
                                    Nodo_Arbol Auxiliar = t.Izquierdo;
                                    bool bandera = false;

                                    while(Auxiliar.Derecho != null)
                                    {
                                        AuxiliarNodo = Auxiliar;
                                        Auxiliar = Auxiliar.Derecho;
                                        bandera = true;
                                    }
                                    //Se crea un nodo temporal
                                    t.info = Auxiliar.info;
                                    NodoEliminar = Auxiliar;

                                    if (bandera == true) 
                                    {
                                        AuxiliarNodo.Derecho = Auxiliar.Izquierdo;
                                    }
                                    else
                                    {
                                        t.Izquierdo = Auxiliar.Izquierdo;
                                    }

                                }
                                else
                                {
                                    if (Alturas(t.Derecho) - Alturas(t.Izquierdo) > 0)
                                    {
                                        Nodo_Arbol AuxiliarNodo = null;
                                        Nodo_Arbol Auxiliar = t.Derecho;
                                        bool bandera = false;
                                        
                                        while(Auxiliar.Izquierdo != null)
                                        {
                                            AuxiliarNodo = Auxiliar;
                                            Auxiliar = Auxiliar.Izquierdo;
                                            bandera = true;
                                        }

                                        t.info = Auxiliar.info;
                                        NodoEliminar = Auxiliar;

                                        if(bandera == true)
                                        {
                                            AuxiliarNodo.Izquierdo = Auxiliar.Derecho;
                                        }
                                        else
                                        {
                                            t.Derecho = Auxiliar.Derecho;
                                        }

                                    }
                                    else
                                    {
                                        if (Alturas(t.Derecho) - Alturas(t.Izquierdo) == 0)
                                        {
                                            Nodo_Arbol AuxiliarNodo = null;
                                            Nodo_Arbol Auxiliar = t.Izquierdo;
                                            bool bandera = false;

                                            while(Auxiliar.Derecho != null)
                                            {
                                                AuxiliarNodo = Auxiliar;
                                                Auxiliar = Auxiliar.Derecho;
                                                bandera = true;
                                            }

                                            t.info = Auxiliar.info;
                                            NodoEliminar = Auxiliar;

                                            if(bandera == true)
                                            {
                                                AuxiliarNodo.Derecho = Auxiliar.Izquierdo;
                                            }

                                            else
                                            {
                                                t.Izquierdo = Auxiliar.Izquierdo;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("El Nodo no existe en el árbol","Error de Eliminación");
            }
        }

        //========================================//
        //      Función buscar a un nodo
        //========================================//
        public void buscar(int x, Nodo_Arbol t)
        {
            if (t != null)
            {
                if (x == t.info)
                {
                    MessageBox.Show("Nodo encontrado en la posición X: " + t.CoordenadaX + "Y:" + t.CoordenadaY );
                    encontrado(t);
                }
                else
                {
                    if (x < t.info) //Buscando en el subárbol izquierdo
                    {
                        buscar(x, t.Izquierdo);
                    }
                    else //Buscando en el subárbol derecho
                    {
                        if (x > t.info)
                        {
                            buscar(x, t.Derecho);
                        }
                    }

                }
            }

            else
            {
                MessageBox.Show("Mi rey el nodo NO ha sido encontrado","Error de búsqueda");
            }

        }

        //======================================================//
        // Funciones para dibujar el arbol binario en el form
        //======================================================//

        //Función Posicion Nodo
        public void PosicionNodo(ref int xmin, int ymin)
        {
            int aux1, aux2;
            CoordenadaY = (int)(ymin + Radio / 2);

            //Obteniendo la posición del sub-árbol izquierdo
            if(Izquierdo != null)
            {
                Izquierdo.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);
            }

            if((Izquierdo != null) && (Derecho != null))
            {
                xmin += DistanciaH;
            }

            //Si existe un nodo derecho y un nodo izquiedo deja un espacio entre ellos

            if(Derecho != null)
            {
                Derecho.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);
            }

            if (Izquierdo != null && Derecho != null)
                CoordenadaX = (int)((Izquierdo.CoordenadaX + Derecho.CoordenadaX) / 2);
            else
                if (Izquierdo != null)
            {
                aux1 = Izquierdo.CoordenadaX;
                Izquierdo.CoordenadaX = CoordenadaX - 80;
                CoordenadaX = aux1;
            }
            else
                if(Derecho != null)
                {
                    aux2 = Derecho.CoordenadaX;
                    //Si no hay nodo Izquierdo centra en el nodo derecho
                    Derecho.CoordenadaX = CoordenadaX + 80;
                    CoordenadaX = aux2;
            }
                else
                {
                    CoordenadaX = (int)(xmin + Radio / 2);
                    xmin += Radio;
                }
        }

        //Función para dibujar las rammas de los nodos izquierdo y derecho
        public void DibujarRamas(Graphics grafo, Pen Lapiz)
        {
            if( Izquierdo != null)//Para dibujar la rama izquierda
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY, Izquierdo.CoordenadaX, Izquierdo.CoordenadaY);
                Izquierdo.DibujarRamas(grafo, Lapiz);
            }

            if(Derecho != null) //Para dibujar la rama derecha
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY, Derecho.CoordenadaX, Derecho.CoordenadaY);
                Derecho.DibujarRamas(grafo, Lapiz);
            }

        }

        //Función para dibujar los respectivos nodos en la posición especificada
        public void DibujarNodo(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro)
        {
            col = grafo;
            //Dibujando el contorno del nodo
            Rectangle rect = new Rectangle((int)(CoordenadaX - Radio / 2), (int)(CoordenadaY - Radio / 2), Radio, Radio);
            Rectangle prueba = new Rectangle((int)(CoordenadaX - Radio / 2), (int)(CoordenadaY - Radio / 2), Radio, Radio);
            grafo.FillEllipse(encuentro, rect);
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);

            //Para dibujar el contenido del nodo
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(info.ToString(), fuente, RellenoFuente, CoordenadaX, CoordenadaY, formato);

            //Para dibujar los nodos hijos derecho e izquierdo
            if(Izquierdo != null)
            {
                Izquierdo.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }

            if(Derecho != null)
            {
                Derecho.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }
        }

        //Función para colorear
        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente,Pen Lapiz)
        {
            //Dibuja el contorno del nodo
            Rectangle rect = new Rectangle((int)(CoordenadaX - Radio / 2), (int)(CoordenadaY - Radio / 2), Radio, Radio);
            Rectangle prueba = new Rectangle((int)(CoordenadaX - Radio / 2), (int)(CoordenadaY - Radio / 2), Radio, Radio);
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);

            //Dibuja el nombre
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(info.ToString(), fuente, RellenoFuente, CoordenadaX, CoordenadaY, formato);

        }


    }
}
