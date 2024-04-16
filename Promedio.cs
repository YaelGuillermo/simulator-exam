using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulacionExamenAdmision
{
    //González Hernández Yael Guillermo #20211785
    public partial class Promedio : Form
    {
        public Promedio()
        {
            InitializeComponent();
        }

        public int n = Variables.n;
        private void btnGenerador_Click_1(object sender, EventArgs e)
        {
            List<float> numerosAleatorios = new List<float>();
            float A = Variables.a;
            float C = Variables.c;
            float x0 = Variables.x0;
            float M = Variables.M;
            float N = Variables.N;
            float sumatoria = 0;
            numerosAleatorios.Add((float)Math.Round(((A * x0 + C) % M) / M, 5));
            for (int i = 1; i < N; i++)
                numerosAleatorios.Add((float)Math.Round(((A * numerosAleatorios[i - 1] * M + C) % M) / M, 5));
            for (int i = 0; i < N; i++)
            {
                n = dgv_Promedio.Rows.Add();
                dgv_Promedio.Rows[n].Cells[0].Value = i + 1;
                dgv_Promedio.Rows[n].Cells[1].Value = numerosAleatorios[i];
                sumatoria = numerosAleatorios[i] + sumatoria;
                dgv_Promedio.Rows[n].Cells[2].Value = sumatoria / (i + 1);
            }
            float promedio = (float)Math.Abs(((numerosAleatorios.Average() - 0.5) * Math.Sqrt(N) / (1 / (2 * Math.Sqrt(3)))));
            if (promedio <= 1.96)
            {
                label1.Text = promedio + " <= 1.96";
                label2.Text = "Los numeros estan uniformemente distribuidos";
                MessageBox.Show("Prueba realizada con exito");
            }
            else
            {
                label1.Text = promedio + " > 1.96";
                label2.Text = "Los numeros no estan uniformemente distribuidos";
                MessageBox.Show("Prueba realizada con exito");
            }

        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            dgv_Promedio.Rows.Clear();
        }
    }
}
