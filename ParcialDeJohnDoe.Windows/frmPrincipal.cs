using ParcialDeJohnDoe.Datos;
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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmOrtoedrosAE ingreso = new frmOrtoedrosAE() { Text = "Nuevo Ortoedro" };
            DialogResult dr = ingreso.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            Ortoedro o = ingreso.GetOrtoedro();
            
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, o);
            AgregarFila(r);
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private  DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void SetearFila(DataGridViewRow r, Ortoedro o)
        {
            r.Cells[colAristaA.Index].Value = o.AristaA;
            r.Cells[colAristaB.Index].Value = o.AristaB;
            r.Cells[colAristaC.Index].Value = o.AristaC;
            r.Cells[colRelleno.Index].Value = o.relleno.ToString();
            r.Cells[colArea.Index].Value = o.GetArea();
            r.Cells[colVolumen.Index].Value = o.GetVolumen();

        }

        private Repositorio Repositorio;
        private List<Ortoedro> listaOrtoedros;
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Repositorio = new Repositorio();
            var cantidad = Repositorio.GetCantidad();
            MostrarCantidad(cantidad);
            if (cantidad > 0)
            {
                listaOrtoedros = Repositorio.GetLista();
                MostrarDatosEnGrilla();
            }

        }

      

        private void MostrarCantidad(int cantidad)
        {
            CantidadTextBox.Text = cantidad.ToString();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var esfera in listaOrtoedros)
            {
                var r = ConstruirFila();
                SetearFila(r, esfera);
                AgregarFila(r);
            }
        }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Repositorio.GuardarEnArchivo();
            Application.Exit();
        }

        
        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            Ortoedro ortoedro = (Ortoedro)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el ortoedro {ortoedro}?",
                "Confirmar Operación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            Repositorio.Borrar(ortoedro);
            dgvDatos.Rows.Remove(r);

        }
    }
    }

