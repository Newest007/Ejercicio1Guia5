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
        Graphics g;


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
            mi_Arbol.DibujarArbol(g, this.Font, Brushes.IndianRed, Brushes.White, Pens.Black, Brushes.White);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dato = Convert.ToInt32(nmUpDown.Value);
            mi_Arbol.Insertar(Dato);
            nmUpDown.Value = 1;
            nmUpDown.Focus();
            cont++;
            Refresh();
            Refresh();

            label2.Text = "";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Dato = Convert.ToInt32(nmUpDown.Value);
            mi_Arbol.Eliminar(Dato);
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
            bool inor = false;
            bool preor = false;
            bool post = false;


            if(comboBox1.SelectedItem.Equals("Inorden"))
            {
                inor = true;
                mi_Arbol.colorear(g, this.Font, Brushes.Green, Brushes.White, Pens.Black, mi_Arbol.Raiz,post, inor, preor);
            }

            if(comboBox1.SelectedItem.Equals("Preorden"))
            {
                preor = true;
                mi_Arbol.colorear(g, this.Font, Brushes.Green, Brushes.White, Pens.Black, mi_Arbol.Raiz, post, inor, preor);
            }

            if (comboBox1.SelectedItem.Equals("Postorden"))
            {
                preor = true;
                mi_Arbol.colorear(g, this.Font, Brushes.Green, Brushes.White, Pens.Black, mi_Arbol.Raiz, post, inor, preor);
            }


        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }
    }
}
