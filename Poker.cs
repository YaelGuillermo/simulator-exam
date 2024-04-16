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
    public partial class Poker : Form
    {
        public Poker()
        {
            InitializeComponent();
        }

        public int n = Variables.n;
        private void btnGenerador_Click(object sender, EventArgs e)
        {
            float a = Variables.a;
            float c = Variables.c;
            float x0 = Variables.x0;
            float M = Variables.M;
            float N = Variables.N;
            int[] cero = new int[(int)N];
            int[] uno = new int[(int)N];
            int[] dos = new int[(int)N];
            int[] tres = new int[(int)N];
            int[] cuatro = new int[(int)N];
            int[] cinco = new int[(int)N];
            int[] seis = new int[(int)N];
            int[] siete = new int[(int)N];
            int[] ocho = new int[(int)N];
            int[] nueve = new int[(int)N];
            char[] primera = new char[(int)N];
            char[] segunda = new char[(int)N];
            char[] tercera = new char[(int)N];
            char[] cuarta = new char[(int)N];
            char[] quinta = new char[(int)N];
            float[] xN = new float[(int)N];
            double[] Ri = new double[(int)N];
            string[] Resultado = new string[(int)N];
            string[] Mensaje = new string[(int)N];
            string[] Eventos = { "TD", "P1", "P2", "I3", "TP", "I4", "TI" };
            float[] FE = new float[7];
            int[] FO = new int[7];
            float[] PEventos = { 0.3024F, 0.504F, 0.108F, 0.072F, 0.009F, 0.0045F, 0.0001F };
            xN[0] = (a * x0 + c) % M;
            for (int i = 1; i < N; i++)
            {
                xN[i] = (a * xN[i - 1] + c) % M;
            }
            for (int i = 0; i < N; i++)
            {
                Ri[i] = Math.Round(xN[i] / M, 5);
            }
            for (int i = 0; i < N; i++)
            {
                try
                {
                    primera[i] = Ri[i].ToString()[2];
                }
                catch (IndexOutOfRangeException ie)
                {
                    primera[i] = '0';
                }
                try
                {
                    segunda[i] = Ri[i].ToString()[3];
                }
                catch (IndexOutOfRangeException ie)
                {
                    segunda[i] = '0';
                }
                try
                {
                    tercera[i] = Ri[i].ToString()[4];
                }
                catch (IndexOutOfRangeException ie)
                {
                    tercera[i] = '0';
                }
                try
                {
                    cuarta[i] = Ri[i].ToString()[5];
                }
                catch (IndexOutOfRangeException ie)
                {
                    cuarta[i] = '0';
                }
                try
                {
                    quinta[i] = Ri[i].ToString()[6];
                }
                catch (IndexOutOfRangeException ie)
                {
                    quinta[i] = '0';
                }
            }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '0')
                        cero[i]++;
                    if (segunda[i] == '0')
                        cero[i]++;
                    if (tercera[i] == '0')
                        cero[i]++;
                    if (cuarta[i] == '0')
                        cero[i]++;
                    if (quinta[i] == '0')
                        cero[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '1')
                        uno[i]++;
                    if (segunda[i] == '1')
                        uno[i]++;
                    if (tercera[i] == '1')
                        uno[i]++;
                    if (cuarta[i] == '1')
                        uno[i]++;
                    if (quinta[i] == '1')
                        uno[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '2')
                        dos[i]++;
                    if (segunda[i] == '2')
                        dos[i]++;
                    if (tercera[i] == '2')
                        dos[i]++;
                    if (cuarta[i] == '2')
                        dos[i]++;
                    if (quinta[i] == '2')
                        dos[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '3')
                        tres[i]++;
                    if (segunda[i] == '3')
                        tres[i]++;
                    if (tercera[i] == '3')
                        tres[i]++;
                    if (cuarta[i] == '3')
                        tres[i]++;
                    if (quinta[i] == '3')
                        tres[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '4')
                        cuatro[i]++;
                    if (segunda[i] == '4')
                        cuatro[i]++;
                    if (tercera[i] == '4')
                        cuatro[i]++;
                    if (cuarta[i] == '4')
                        cuatro[i]++;
                    if (quinta[i] == '4')
                        cuatro[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '5')
                        cinco[i]++;
                    if (segunda[i] == '5')
                        cinco[i]++;
                    if (tercera[i] == '5')
                        cinco[i]++;
                    if (cuarta[i] == '5')
                        cinco[i]++;
                    if (quinta[i] == '5')
                        cinco[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '6')
                        seis[i]++;
                    if (segunda[i] == '6')
                        seis[i]++;
                    if (tercera[i] == '6')
                        seis[i]++;
                    if (cuarta[i] == '6')
                        seis[i]++;
                    if (quinta[i] == '6')
                        seis[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '7')
                        siete[i]++;
                    if (segunda[i] == '7')
                        siete[i]++;
                    if (tercera[i] == '7')
                        siete[i]++;
                    if (cuarta[i] == '7')
                        siete[i]++;
                    if (quinta[i] == '7')
                        siete[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '8')
                        ocho[i]++;
                    if (segunda[i] == '8')
                        ocho[i]++;
                    if (tercera[i] == '8')
                        ocho[i]++;
                    if (cuarta[i] == '8')
                        ocho[i]++;
                    if (quinta[i] == '8')
                        ocho[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (primera[i] == '9')
                        nueve[i]++;
                    if (segunda[i] == '9')
                        nueve[i]++;
                    if (tercera[i] == '9')
                        nueve[i]++;
                    if (cuarta[i] == '9')
                        nueve[i]++;
                    if (quinta[i] == '9')
                        nueve[i]++;
                }
                for (int i = 0; i < N; i++)
                {
                    if (uno[i] == 5 || dos[i] == 5 || tres[i] == 5 || cuatro[i] == 5 || cinco[i] == 5
                        || seis[i] == 5 || siete[i] == 5 || ocho[i] == 5 || cero[i] == 5 || nueve[i] == 5)
                    {
                        Resultado[i] = "TI";
                        Mensaje[i] = "Todos iguales";
                        FO[6]++;
                    }
                    else if (uno[i] == 4 || dos[i] == 4 || tres[i] == 4 || cuatro[i] == 4 || cinco[i] == 4
                        || seis[i] == 4 || siete[i] == 4 || ocho[i] == 4 || cero[i] == 4 || nueve[i] == 4)
                    {
                        Resultado[i] = "4I";
                        Mensaje[i] = "Cuatro iguales";
                        FO[5]++;
                    }
                    else if ((uno[i] == 3 || dos[i] == 3 || tres[i] == 3 || cuatro[i] == 3 || cinco[i] == 3
                        || seis[i] == 3 || siete[i] == 3 || ocho[i] == 3 || cero[i] == 3 || nueve[i] == 3)
                        && (uno[i] == 2 || dos[i] == 2 || tres[i] == 2 || cuatro[i] == 2 || cinco[i] == 2
                        || seis[i] == 2 || siete[i] == 2 || ocho[i] == 2 || cero[i] == 2 || nueve[i] == 2))
                    {
                        Resultado[i] = "TP";
                        Mensaje[i] = "Tres iguales y un par";
                        FO[4]++;
                    }
                    else if (uno[i] == 3 || dos[i] == 3 || tres[i] == 3 || cuatro[i] == 3 || cinco[i] == 3
                        || seis[i] == 3 || siete[i] == 3 || ocho[i] == 3 || cero[i] == 3 || nueve[i] == 3)
                    {
                        Resultado[i] = "3I";
                        Mensaje[i] = "Tres iguales";
                        FO[3]++;
                    }
                    else if (Math.Floor((double)(uno[i] / 2 + dos[i] / 2 + tres[i] / 2 + cuatro[i] / 2 + cinco[i] / 2
                        + seis[i] / 2 + siete[i] / 2 + ocho[i] / 2 + nueve[i] / 2 + cero[i] / 2)) == 2)
                    {
                        Resultado[i] = "2P";
                        Mensaje[i] = "Dos pares";
                        FO[2]++;
                    }
                    else if (uno[i] == 2 || dos[i] == 2 || tres[i] == 2 || cuatro[i] == 2 || cinco[i] == 2
                        || seis[i] == 2 || siete[i] == 2 || ocho[i] == 2 || cero[i] == 2 || nueve[i] == 2)
                    {
                        Resultado[i] = "1P";
                        Mensaje[i] = "Un par";
                        FO[1]++;
                    }
                    else
                    {
                        Resultado[i] = "TD";
                        Mensaje[i] = "Todos distintos";
                        FO[0]++;
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    n = dgv_Poker1.Rows.Add();
                    dgv_Poker1.Rows[n].Cells[0].Value = i + 1;
                    dgv_Poker1.Rows[n].Cells[1].Value = Ri[i];
                    dgv_Poker1.Rows[n].Cells[2].Value = Resultado[i];
                    dgv_Poker1.Rows[n].Cells[3].Value = Mensaje[i];
                }
                for (int i = 0; i < 7; i++)
                {
                    FE[i] = PEventos[i] * N;
                }
                float chicuadrada = 0;
                for (int i = 0; i < 7; i++)
                {
                    n = dgv_Poker2.Rows.Add();
                    dgv_Poker2.Rows[n].Cells[0].Value = Eventos[i];
                    dgv_Poker2.Rows[n].Cells[1].Value = FO[i];
                    dgv_Poker2.Rows[n].Cells[2].Value = PEventos[i];
                    dgv_Poker2.Rows[n].Cells[3].Value = FE[i];
                    dgv_Poker2.Rows[n].Cells[4].Value = Math.Pow((FO[i] - FE[i]), 2) / FE[i];
                    chicuadrada = (float)Math.Pow((FO[i] - FE[i]), 2) / FE[i] + chicuadrada;
                }
                if (chicuadrada <= 316.9194)
                {
                    label1.Text = chicuadrada + " <= 316.9194";
                    label2.Text = "Los numeros estan uniformemente distribuidos";
                MessageBox.Show("Prueba realizada con exito");
            }
                else
                {
                    label1.Text = chicuadrada + " > 316.9194";
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
                    dgv_Poker1.Rows.Clear();
                    dgv_Poker2.Rows.Clear();
                }
    }
}
