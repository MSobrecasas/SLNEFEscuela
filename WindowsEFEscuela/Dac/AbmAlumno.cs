using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsEFEscuela.Data;
using WindowsEFEscuela.Models;

namespace WindowsEFEscuela.Dac
{
    public class AbmAlumno
    {
        private static DBEscuelaContext context = new DBEscuelaContext();

        public static List<Alumno> TraerTodos()
        {
            return context.Alumnos.ToList();
        }

        public static Alumno TraerUno(int id)
        {
            return context.Alumnos.Find(id);
        }

        public static int Insertar(Alumno alumno)
        { 
            context.Alumnos.Add(alumno);
            return context.SaveChanges();
        }

        public static int Modificar(Alumno alumno)
        {
            Alumno origen = context.Alumnos.Find(alumno.IdAlumno);
            origen.Nombre = alumno.Nombre;
            origen.Apellido = alumno.Apellido;
            origen.FechaNacimento = alumno.FechaNacimento;
            origen.IdProf = alumno.IdProf;


            return context.SaveChanges();
        }

        public static int Eliminar(Alumno alumno)
        {
            Alumno origen = context.Alumnos.Find(alumno.IdAlumno);
            if (origen != null)
            {
                context.Alumnos.Remove(origen);
                return context.SaveChanges();
            }
            return 0;
        }

    }
}
