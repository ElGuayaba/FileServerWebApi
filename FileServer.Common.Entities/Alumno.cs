using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Entities
{
	public class Alumno
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public string Dni { get; set; }

		public override bool Equals(object obj)
		{
			var alumno = obj as Alumno;
			return alumno != null &&
				   Id == alumno.Id &&
				   Nombre == alumno.Nombre &&
				   Apellidos == alumno.Apellidos &&
				   Dni == alumno.Dni;
		}

		public override int GetHashCode()
		{
			var hashCode = -1407328918;
			hashCode = hashCode * -1521134295 + Id.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
			return hashCode;
		}
	}
}
