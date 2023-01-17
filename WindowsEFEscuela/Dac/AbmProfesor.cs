using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsEFEscuela.Data;
using WindowsEFEscuela.Models;

namespace WindowsEFEscuela.Dac
{
   public class AbmProfesor
    {
        private static DBEscuelaContext context = new DBEscuelaContext();

        public static List<Profesor> TraerTodos()
        {
            return context.Profesores.ToList();
        }
    }
}
