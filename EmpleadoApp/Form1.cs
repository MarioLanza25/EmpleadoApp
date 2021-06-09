using EmpleadoApp.Enums;
using EmpleadoApp.Model;
using EmpleadoApp.Poco;
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
        private EmpleadoModel empleadoModel;
        public Form1()
        {
            InitializeComponent();
            empleadoModel = new EmpleadoModel();
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
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string cedula = txtCedula.Text;
                string telefono = txtNumeroTelefono.Text;
                string correo = txtCorreo.Text;
                TipoProfesion tipoProfesion = (TipoProfesion)Enum.GetValues(typeof(TipoProfesion)).GetValue(cmbProfesiones.SelectedIndex);
                TipoCargo tipoCargo = (TipoCargo)Enum.GetValues(typeof(TipoCargo)).GetValue(cmbCargos.SelectedIndex);
                ValidateEmpleado(out double salario);

                Empleado emp = new Empleado()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Cedula = cedula,
                    Telefono = telefono,
                    Correo = correo,
                    Salario = salario,
                    TipoProfesion = tipoProfesion,
                    TipoCargo = tipoCargo
                };

                empleadoModel.AddElements(emp);
                MessageBox.Show("Empleado ha sido agregado satisfactoriamente!");
                dgvDatosEmpleado.DataSource = empleadoModel.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void ValidateEmpleado(out double salario)
        {
            if (!double.TryParse(txtSalario.Text, out double sal))
            {
                throw new ArgumentException($"El valor {txtSalario.Text} es invalido");
            }
            salario = sal;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDatosEmpleado.Rows.Count==0)
            {
                return;
            }
            int index = dgvDatosEmpleado.CurrentCell.RowIndex;
            empleadoModel.Remove(index);
            dgvDatosEmpleado.DataSource = empleadoModel.GetAll();
        }
    }
}
