using ParcialDeJohnDoe.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialDeJohnDoe.Windows
{
    public partial class frmOrtoedrosAE : Form
    { 

        public frmOrtoedrosAE()
        {
            InitializeComponent();
        }
        private Ortoedro ortoedro;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosRelleno();
        }

        public Ortoedro GetOrtoedro()
        {
            return ortoedro;
        }

        private void CargarDatosRelleno()
        {
            comboBoxRelleno.DataSource = Enum.GetValues(typeof(Relleno));
            comboBoxRelleno.SelectedIndex = 0;
        }

        

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(textBoxAristaA.Text, out int AristaA))
            {
                valido = false;
                errorProvider1.SetError(textBoxAristaA, "Debe ingresar un dato valido");
            }
            if (!int.TryParse(textBoxAristaB.Text, out int AristaB))
            {
                valido = false;
                errorProvider1.SetError(textBoxAristaB, "Debe ingresar un dato valido");
            }
            if (!int.TryParse(textBoxAristaC.Text, out int AristaC))
            {
                valido = false;
                errorProvider1.SetError(textBoxAristaC, "Debe ingresar un numero valido ");
            }
            if (comboBoxRelleno.SelectedItem == null)
            {
                valido = false;
                errorProvider1.SetError(comboBoxRelleno, "Debe seleccionar una opcion");
            }
            return valido; 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if
                      (ortoedro == null)
                { 
                 ortoedro = new Ortoedro();
                }
                {
                    ortoedro.AristaA = int.Parse(textBoxAristaA.Text);
                    ortoedro.AristaB = int.Parse(textBoxAristaB.Text);
                    ortoedro.AristaC = int.Parse(textBoxAristaC.Text);
                    ortoedro.relleno = (Relleno)comboBoxRelleno.SelectedIndex;
                };
                if (ortoedro.validar())
                { DialogResult = DialogResult.OK; }
                errorProvider1.SetError(textBoxAristaA, "Las 3 aristas no pueden tener el mismo valor");



            }
        }
    }
}
