using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_1_Guía_6
{
    //Arian M
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Declarando variables que se utilizaran
        int Dato = 0;
        int cont = 0;
        Arbol_Binario mi_Arbol = new Arbol_Binario(null);
        Nodo_Arbol nodo_DelArbol = new Nodo_Arbol();
        Graphics g;


        //Lista usada para calcular la suma de todos los valores del árbol binario //
        public List<int> valoresNodos = new List<int>();
        //=========================================================================//

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //Evento para dibujar el árbol binario dentro del form
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = e.Graphics;
            mi_Arbol.DibujarArbol(g, this.Font, Brushes.LightGreen, Brushes.Black, Pens.Black, Brushes.White);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            Dato = Convert.ToInt32(nmUpDown.Value);
            mi_Arbol.Insertar(Dato);
            //===============================================//
            valoresNodos.Add(Dato);//Se usa para añadir los datos que se desean a la lista para sumar todos los valores
            //===============================================//
            nmUpDown.Value = 1;
            nmUpDown.Focus();
            cont++;
            Refresh();
            Refresh();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Dato = Convert.ToInt32(nmUpDown.Value);
            mi_Arbol.Eliminar(Dato);
            //===============================================//
            valoresNodos.Remove(Dato); //Se usa para eliminar los datos que se desean a la lista para sumar todos los valores
            //===============================================//
            nmUpDown.Value = 1;
            nmUpDown.Focus();
            cont--;
            Refresh();
            Refresh();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Dato = Convert.ToInt32(nmUpDown.Value);
            mi_Arbol.Buscar(Dato);
            nmUpDown.Value = 1;
            nmUpDown.Focus();
            Refresh();
            Refresh();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.Equals("Inorden"))
            {
                //InOrden o EnOrden
                listBox1.Items.Clear();
                nodo_DelArbol.listaInorden.Clear();

                nodo_DelArbol.inorden(mi_Arbol.Raiz);
                foreach (var valores in nodo_DelArbol.listaInorden)
                {
                    listBox1.Items.Add(valores);
                }


            }

            if (comboBox1.SelectedItem.Equals("Preorden"))
            {
                //PreOrden
                listBox1.Items.Clear();
                nodo_DelArbol.listaPreorden.Clear();

                nodo_DelArbol.preorden(mi_Arbol.Raiz);
                foreach (var valores in nodo_DelArbol.listaPreorden)
                {
                    listBox1.Items.Add(valores);
                }

            }

            if (comboBox1.SelectedItem.Equals("Postorden"))
            {
                //PostOrden
                listBox1.Items.Clear();
                nodo_DelArbol.listaPostorden.Clear();

                nodo_DelArbol.postorden(mi_Arbol.Raiz);
                foreach (var valores in nodo_DelArbol.listaPostorden)
                {
                    listBox1.Items.Add(valores);
                }

            }


        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) { }
    
        

        private void button1_Click_2(object sender, EventArgs e)
        {
            //Boton para sumar todos los valores que hay dentro de cada nodo del arbol binario 
            int suma = valoresNodos.Sum();
            label2.Text = "" + suma;
            label5.Text = "" + cont;

            if (mi_Arbol.Raiz != null)
            {
                label6.Text = "" + nodo_DelArbol.calcular_Altura(mi_Arbol.Raiz);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
