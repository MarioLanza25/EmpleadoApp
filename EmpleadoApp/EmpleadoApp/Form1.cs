using EmpleadoApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpleadoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadFrmEmpleado(object sender, EventArgs e)
        {
            cmbProfesiones.Items.AddRange(Enum.GetValues(typeof(TipoProfesion)).Cast<object>().ToArray());
            cmbProfesiones.SelectedIndex = 0;

            cmbCargos.Items.AddRange(Enum.GetValues(typeof(TipoCargo)).Cast<object>().ToArray());
            cmbCargos.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text ;
                string apellido = txtApellido.Text;
                string cedula = txtCedula.Text;
                string telefono = txtNumeroTelefono.Text;
                string correo = txtCorreo.Text;
                TipoProfesion tipoProfesion = (TipoProfesion) Enum.GetValues(typeof(TipoProfesion)).GetValue(cmbProfesiones.SelectedIndex);
                TipoCargo tipoCargo = (TipoCargo)Enum.GetValues(typeof(TipoCargo)).GetValue(cmbCargos.SelectedIndex);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            }
        }
    }
}
