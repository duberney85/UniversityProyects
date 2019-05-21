using System;
using System.Windows.Forms;

namespace SimuladorGrafos
{
    public partial class frmAgregarArista : Form
    {
        private bool _control;
        private int _dato;

        /// <summary>
        /// Peso que almacenara la arista
        /// </summary>
        public int Dato
        {
            get { return _dato; }
            set { _dato = value; }
        }

        /// <summary>
        /// Variable de control
        /// </summary>
        public bool Control
        {
            get { return _control; }
            set { _control = value; }
        }

        public frmAgregarArista()
        {
            InitializeComponent();
            _control = false;
            _dato = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                _dato = Convert.ToInt32(txtPeso.Text.Trim());
                if (_dato < 0)
                {
                    MessageBox.Show(
                        "Debe ingresar un valor positivo",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    _control = true;
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Debe ingresar un valor numerico",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _control = false;
            this.Hide();
        }

        private void frmAgregarArista_Load(object sender, EventArgs e)
        {
            this.txtPeso.Focus();
        }

        private void frmAgregarArista_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void frmAgregarArista_Shown(object sender, EventArgs e)
        {
            this.txtPeso.Clear();
            this.txtPeso.Focus();
        }

        private void frmAgregarArista_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null, null);
            }
        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null, null);
            }
        }
    }
}
