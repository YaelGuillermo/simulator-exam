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
    public partial class Generador : Form
    {
        public Generador()
        {
            InitializeComponent();
        }

        Metodos metodos = new Metodos();
        public int n;
        public List<float> numerosAleatorios = new List<float>();

        private void txtEnter (object sender, EventArgs e) 
        {
            metodos.textBox_Enter(sender, e);
        }

        private void txtLeave(object sender, EventArgs e)
        {
            metodos.textBox_Leave(sender, e);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                float a = Convert.ToInt32(txtA.Text); Variables.a = a;
                float c = Convert.ToInt32(txtC.Text); Variables.c = c;
                float x0 = Convert.ToInt32(txtX0.Text); Variables.x0 = x0;
                float M = Convert.ToInt32(txtM.Text); Variables.M = M;
                float N = Convert.ToInt32(txtN.Text); Variables.N = N;
                if (a < 0 || c < 0 || x0  < 0 || M < 0 || N < 0)
                    throw new ExceptionNegativos();
                numerosAleatorios.Add((float) Math.Round(((a * x0 + c) % M) / M, 5));
                for (int i = 1; i < N; i++)
                    numerosAleatorios.Add((float)Math.Round(((a * numerosAleatorios[i - 1] * M + c) % M) / M, 5));
                for (int i = 0; i < N; i++)
                {
                    n = dgv_Generador.Rows.Add();
                    dgv_Generador.Rows[n].Cells[0].Value = i + 1;
                    dgv_Generador.Rows[n].Cells[1].Value = numerosAleatorios[i];
                }
                bool bandera = false;
                float x = 0;
                float Periodo = 0;
                for (int i = 0; i < N; i++)
                {
                    x = numerosAleatorios[i];
                    float k = i + 1;
                    for (int j = (int)k; j < N; j++)
                    {
                        float y = numerosAleatorios[j];
                        if (x == y)
                        {
                            bandera = true;
                            Periodo = j - i;
                            break;
                        }
                    }
                }
                if (bandera == false)
                    MessageBox.Show("Ningun valor esta repetido");
                else
                    MessageBox.Show("El valor " + x + " se repite. El periodo es de " + Periodo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_Generador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
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
            numerosAleatorios.Clear();
            dgv_Generador.Rows.Clear();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Generador_Load(object sender, EventArgs e)
        {

        }
    }
}

class ExceptionNegativos : ApplicationException 
{
    public ExceptionNegativos() : base("Los numeros insertados deben ser positivos.")
    { }
}

public class Variables
{
    static public int n;
    static public float a, c, x0, M, N;
}