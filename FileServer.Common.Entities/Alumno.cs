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
	}
}
