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
    public partial class Principal : Form
    {
        //González Hernández Yael Guillermo #20211785
        public Principal()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        private void hideSubMenu()
        {
            panelPruebas.Visible = false;
        }
        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnPruebas_Click(object sender, EventArgs e)
        {
            showSubmenu(panelPruebas);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnGenerador_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Generador());
            hideSubMenu();
        }

        private void btnAplicacion_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Aplicacion());
            hideSubMenu();
        }

        private void btnPoker_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Poker());
            hideSubMenu();
        }

        private void btnKorlm_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Promedio());
            hideSubMenu();
        }
    }
}

public class Metodos
{
    public void textBox_Enter(object sender, EventArgs e)
    {
        Control control = sender as Control;
        if (control is TextBox)
        {
            TextBox txt = (TextBox)control;
            if (txt.Text == txt.Tag.ToString())
                txt.Text = "";
        }
    }

    public void textBox_Leave(object sender, EventArgs e)
    {
        Control control = sender as Control;
        if (control is TextBox)
        {
            TextBox txt = (TextBox)control;
            if (txt.Text == "")
                txt.Text = txt.Tag.ToString();
        }
    }
}