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
    public partial class Aplicacion : Form
    {
        //González Hernández Yael Guillermo #20211785
        public Aplicacion()
        {
            InitializeComponent();
        }

        Metodos metodos = new Metodos();
        public int n;
        public List<float> pseudoAleatorios;

        private void txtEnter(object sender, EventArgs e)
        {
            metodos.textBox_Enter(sender, e);
        }

        private void txtLeave(object sender, EventArgs e)
        {
            metodos.textBox_Leave(sender, e);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            List<float> numerosAleatorios = new List<float>();
            float A = Variables.a;
            float C = Variables.c;
            float x0 = Variables.x0;
            float M = Variables.M;
            float N = Variables.N;
            numerosAleatorios.Add((float)Math.Round(((A * x0 + C) % M) / M, 5));
            for (int i = 1; i < N; i++)
                numerosAleatorios.Add((float)Math.Round(((A * numerosAleatorios[i - 1] * M + C) % M) / M, 5));
            float Z = N - (N % 4);
            List<float> ejeW = new List<float>();
            List<float> ejeX = new List<float>();
            List<float> ejeY = new List<float>();
            List<float> ejeZ = new List<float>();
            for (int i = 0; i < N; i++)
            {
                if (i < Z / 4)
                    ejeW.Add(numerosAleatorios[i]);
                else if (i < (Z / 4) * 2)
                    ejeX.Add(numerosAleatorios[i]);
                else if (i < (Z / 4) * 3)
                    ejeY.Add(numerosAleatorios[i]);
                else if (i < Z)
                    ejeZ.Add(numerosAleatorios[i]);
            }
            try
            {
                int Español = Convert.ToInt32(txtEspañol.Text);
                int Matematicas = Convert.ToInt32(txtMatematicas.Text);
                int Ingles = Convert.ToInt32(txtIngles.Text);
                float a = Convert.ToInt32(txtA.Text);
                float b = Convert.ToInt32(txtB.Text);
                float c = Convert.ToInt32(txtC.Text);
                int Aceptados = Convert.ToInt32(txtAceptados.Text);
                if (a < 0 || b < 0 || c < 0 || Español < 0 || Matematicas < 0 || Ingles < 0 || Aceptados < 0)
                    throw new ExceptionNegativos();
                if ((a < 0 || a > 100) || (b < 0 || b > 100) || (c < 0 || c > 100))
                    throw new ExceptionRango();
                MessageBox.Show("Simulacion realizada con exito");
                float Preguntas = Español + Matematicas + Ingles;
                float[] Frecuencia_Español = new float[Español + 1];
                float sumaFrecuencia_Español = 0;
                float[] frecuenciaRelativa_Español = new float[Español + 1];
                float[] frecuenciaAcumulada_Español = new float[Español + 1];
                float[] limInferior_Español = new float[Español + 1];
                float[] limSuperior_Español = new float[Español + 1];
                for (int i = 0; i < Español + 1; i++)
                {
                    Frecuencia_Español[i] = (Español + 1) - i;
                    sumaFrecuencia_Español += Frecuencia_Español[i];
                }
                for (int i = 0; i < Español + 1; i++)
                {
                    n = dgv_Español.Rows.Add();
                    frecuenciaRelativa_Español[i] = (float) Math.Round((Frecuencia_Español[i] / sumaFrecuencia_Español), 5);
                    frecuenciaAcumulada_Español[i] += frecuenciaRelativa_Español[i];
                    if (i == 0)
                        limInferior_Español[0] = 0;
                    else
                        limInferior_Español[i] = limSuperior_Español[i - 1];
                    limSuperior_Español[i] = frecuenciaRelativa_Español[i] + limInferior_Español[i];
                    limSuperior_Español[Español] = 1;
                    dgv_Español.Rows[n].Cells[0].Value = i;
                    dgv_Español.Rows[n].Cells[1].Value = limInferior_Español[i] + " - " + limSuperior_Español[i];
                }
                float[] Frecuencia_Matematicas = new float[Matematicas + 1];
                float sumaFrecuencia_Matematicas = 0;
                float[] frecuenciaRelativa_Matematicas = new float[Matematicas + 1];
                float[] frecuenciaAcumulada_Matematicas = new float[Matematicas + 1];
                float[] limInferior_Matematicas = new float[Matematicas + 1];
                float[] limSuperior_Matematicas = new float[Matematicas + 1];
                for (int i = 0; i < Matematicas + 1; i++)
                {
                    Frecuencia_Matematicas[i] = (Matematicas + 1) - i;
                    sumaFrecuencia_Matematicas += Frecuencia_Matematicas[i];
                }
                for (int i = 0; i < Matematicas + 1; i++)
                {
                    n = dgv_Matematicas.Rows.Add();
                    frecuenciaRelativa_Matematicas[i] = (float)Math.Round((Frecuencia_Matematicas[i] / sumaFrecuencia_Matematicas), 5);
                    frecuenciaAcumulada_Matematicas[i] += frecuenciaRelativa_Matematicas[i];
                    if (i == 0)
                        limInferior_Matematicas[0] = 0;
                    else
                        limInferior_Matematicas[i] = limSuperior_Matematicas[i - 1];
                    limSuperior_Matematicas[i] = frecuenciaRelativa_Matematicas[i] + limInferior_Matematicas[i];
                    limSuperior_Matematicas[Matematicas] = 1;
                    dgv_Matematicas.Rows[n].Cells[0].Value = i;
                    dgv_Matematicas.Rows[n].Cells[1].Value = limInferior_Matematicas[i] + " - " + limSuperior_Matematicas[i];
                }
                float[] Frecuencia_Ingles = new float[Ingles + 1];
                float sumaFrecuencia_Ingles = 0;
                float[] frecuenciaRelativa_Ingles = new float[Ingles + 1];
                float[] frecuenciaAcumulada_Ingles = new float[Ingles + 1];
                float[] limInferior_Ingles = new float[Ingles + 1];
                float[] limSuperior_Ingles = new float[Ingles + 1];
                for (int i = 0; i < Ingles + 1; i++)
                {
                    Frecuencia_Ingles[i] = (Ingles + 1) - i;
                    sumaFrecuencia_Ingles += Frecuencia_Ingles[i];
                }
                for (int i = 0; i < Ingles + 1; i++)
                {
                    n = dgv_Ingles.Rows.Add();
                    frecuenciaRelativa_Ingles[i] = (float)Math.Round((Frecuencia_Ingles[i] / sumaFrecuencia_Ingles), 5);
                    frecuenciaAcumulada_Ingles[i] += frecuenciaRelativa_Ingles[i];
                    if (i == 0)
                        limInferior_Ingles[0] = 0;
                    else
                        limInferior_Ingles[i] = limSuperior_Ingles[i - 1];
                    limSuperior_Ingles[i] = frecuenciaRelativa_Ingles[i] + limInferior_Ingles[i];
                    limSuperior_Ingles[Ingles] = 1;
                    dgv_Ingles.Rows[n].Cells[0].Value = i;
                    dgv_Ingles.Rows[n].Cells[1].Value = limInferior_Ingles[i] + " - " + limSuperior_Ingles[i];
                }
                float[] calificacion_Español = new float[(int)Z / 4];
                float[] calificacion_Matematicas = new float[(int)Z / 4];
                float[] calificacion_Ingles = new float[(int)Z / 4];
                float[] calificacion_Prepa = new float[(int)Z / 4];
                List<float> auxiliar = new List<float>();
                List<float> promedio = new List<float>();
                for (int j = 0; j < Z / 4; j++)
                {
                    for (int i = 0; i < Español + 1; i++)
                        if (ejeW[j] > limInferior_Español[i] && ejeW[j] < limSuperior_Español[i])
                            calificacion_Español[j] = (Español + 1) - Frecuencia_Español[i];
                    for (int i = 0; i < Matematicas + 1; i++)
                        if (ejeX[j] > limInferior_Matematicas[i] && ejeX[j] < limSuperior_Matematicas[i])
                            calificacion_Matematicas[j] = (Matematicas + 1) - Frecuencia_Matematicas[i];
                    for (int i = 0; i < Ingles + 1; i++)
                        if (ejeY[j] > limInferior_Ingles[i] && ejeY[j] < limSuperior_Ingles[i])
                            calificacion_Ingles[j] = (Ingles + 1) - Frecuencia_Ingles[i];
                    if (ejeZ[j] <= ((c - b) / ((c - b) + (b - a))))
                        calificacion_Prepa[j] = (float) Math.Round(a + Math.Sqrt(((c - b) + (b - a)) * (b - a) * ejeZ[j]));
                    else
                        calificacion_Prepa[j] = (float) Math.Round(c - Math.Sqrt(((c - b) + (b - a)) * (b - a) * (1 - ejeZ[j])));
                }
                for (int i = 0; i < Z / 4; i++)
                {
                    n = dgv_Resultados.Rows.Add();
                    dgv_Resultados.Rows[n].Cells[0].Value = i + 1;
                    dgv_Resultados.Rows[n].Cells[1].Value = ejeW[i];
                    dgv_Resultados.Rows[n].Cells[2].Value = calificacion_Español[i];
                    dgv_Resultados.Rows[n].Cells[3].Value = ejeX[i];
                    dgv_Resultados.Rows[n].Cells[4].Value = calificacion_Matematicas[i];
                    dgv_Resultados.Rows[n].Cells[5].Value = ejeY[i];
                    dgv_Resultados.Rows[n].Cells[6].Value = calificacion_Ingles[i];
                    dgv_Resultados.Rows[n].Cells[7].Value = ejeZ[i];
                    dgv_Resultados.Rows[n].Cells[8].Value = calificacion_Prepa[i];
                    promedio.Add(((calificacion_Español[i] + calificacion_Matematicas[i] + calificacion_Ingles[i]) * (80 / Preguntas)) + (float) (0.2 * calificacion_Prepa[i]));
                    auxiliar.Add(promedio[i]);
                    dgv_Resultados.Rows[n].Cells[9].Value = promedio[i];
                }
                float[] promediosAceptados = new float[Aceptados];
                float[] indice = new float[Aceptados];
                promedio.Sort();
                promedio.Reverse();
                for (int i = 0; i < Aceptados; i++)
                {
                    promediosAceptados[i] = promedio[i];
                }
                for (int i = 0; i < Aceptados; i++)
                {
                    for (int j = 0; j < Z / 4; j++)
                    {
                        if (promediosAceptados[i] == auxiliar[j])
                        {
                            indice[i] = j + 1;
                        }
                    }
                }
                for (int i = 0; i < Aceptados; i++)
                {
                    n = dgv_Conclusion.Rows.Add();
                    dgv_Conclusion.Rows[n].Cells[0].Value = i + 1;
                    dgv_Conclusion.Rows[n].Cells[1].Value = indice[i];
                    dgv_Conclusion.Rows[n].Cells[2].Value = promedio[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.Text = Convert.ToString(txt.Tag);
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTablas_Click(object sender, EventArgs e)
        {
            panelTablas.Visible = true;
        }

        private void btnTablasRegresar_Click(object sender, EventArgs e)
        {
            panelTablas.Visible = false;
        }

        private void Aplicacion_Load(object sender, EventArgs e)
        {
        }

        private void btnTablasResultados_Click(object sender, EventArgs e)
        {
            panelResultados.Visible = true;
        }

        private void btnConclusion_Click(object sender, EventArgs e)
        {
            panelConclusion.Visible = true;
        }

        private void panelConclusion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConclusionRegresar_Click(object sender, EventArgs e)
        {
            panelConclusion.Visible = false;
            panelResultados.Visible = true;
        }

        private void btnRegresarResultados_Click(object sender, EventArgs e)
        {
            panelResultados.Visible = false;
            panelTablas.Visible = true;
        }
    }
}

class ExceptionRango : ApplicationException
{
    public ExceptionRango() : base("Los numeros insertados deben estar entre 0 y 100.")
    { }
}
