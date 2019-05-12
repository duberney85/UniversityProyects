using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorGrafos
{
    public partial class FrmAgregarVertice : Form
    {
        private bool _control;
        private string _dato;

        /// <summary>
        /// Variable de control
        /// </summary>
        public bool Control
        {
            get { return _control; }
            set { _control = value; }
        }

        /// <summary>
        /// El dato que almacenara el vertice
        /// </summary>
        public string Dato
        {
            get { return _dato; }
            set { _dato = value; }
        }


        public FrmAgregarVertice()
        {
            InitializeComponent();
            _control = false;
            _dato = " ";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string valor = txtVertice.Text.Trim();

            if(string.IsNullOrWhiteSpace(valor))
            {
                MessageBox.Show(
                    "Debes ingresar un valor", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                _dato = valor;
                _control = true;
                this.Hide();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _control = false;
            this.Hide();
        }

        private void FrmAgregarVertice_Load(object sender, EventArgs e)
        {
            this.txtVertice.Focus();
        }

        private void FrmAgregarVertice_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void FrmAgregarVertice_Shown(object sender, EventArgs e)
        {
            this.txtVertice.Clear();
            this.txtVertice.Focus();
        }

        private void FrmAgregarVertice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btnAceptar_Click(null, null);
            }
        }

        private void txtVertice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btnAceptar_Click(null, null);
            }
        }
    }
}
