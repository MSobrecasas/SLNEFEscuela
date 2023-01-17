using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsEFEscuela.Dac;
using WindowsEFEscuela.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsEFEscuela
{
    public partial class frmAlumno : Form
    {

        public frmAlumno()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Crear();
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            MessageBox.Show((AbmAlumno.TraerUno(id).Nombre + " " + AbmAlumno.TraerUno(id).Apellido));
        }


        private void MostrarAlumnos()
        {
            GridAlumnos.DataSource = AbmAlumno.TraerTodos();
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            MostrarAlumnos();

            cbmProfesor.DataSource = AbmProfesor.TraerTodos();
            cbmProfesor.DisplayMember = "Nombre";
            cbmProfesor.ValueMember = "ProfesorId";
        }

        private void Crear()
        {
            //Profesor prof = (Profesor)cbmProfesor.SelectedValue;
            Alumno alumno = new Alumno()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimento = dtpFechaNacimiento.Value,
                IdProf = Convert.ToInt32(cbmProfesor.SelectedValue.ToString())
            };

            int filasAfectadas = AbmAlumno.Insertar(alumno);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Insert Correcto");
                MostrarAlumnos();
                limpiar();
            }
        }

        private void Modificar()
        {
            Alumno alumno = new Alumno()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimento = dtpFechaNacimiento.Value,
                IdProf = 1,
                IdAlumno = Convert.ToInt32(txtId.Text)
            };

            int filasAfectadas = AbmAlumno.Modificar(alumno);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Modificar Correcto");
                MostrarAlumnos();
                limpiar();
            }
        }


        private void Eliminar()
        {
            Alumno alumno = new Alumno()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimento = dtpFechaNacimiento.Value,
                IdProf = 1,
                IdAlumno = Convert.ToInt32(txtId.Text)
            };

            int filasAfectadas = AbmAlumno.Eliminar(alumno);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Eliminar Correcto");
                MostrarAlumnos();
                limpiar();
            }

        }

        private void GridAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = GridAlumnos.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = GridAlumnos.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtApellido.Text = GridAlumnos.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
        }
    }
}
