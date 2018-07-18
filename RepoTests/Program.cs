using FileServer.Common.Entities;
using FileServer.Infrastructure.Repository.Repository;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoTests
{
	class Program
	{
		static void Main(string[] args)
		{
			Alumno alumno = new Alumno
			{
				Id = 1,
				Nombre = "Craig",
				Apellidos = "Playstead",
				Dni = "123"
			};
			Alumno alumno1 = new Alumno
			{
				Id = 2,
				Nombre = "Jose",
				Apellidos = "Alamo",
				Dni = "321"
			};
			AlumnoRepository alumnoRepository = new AlumnoRepository();
			alumnoRepository.Add(alumno);
			alumnoRepository.Add(alumno1);
			Console.Write("GetAll: ");
			foreach (Alumno alu in alumnoRepository.GetAll())
				Console.WriteLine(JsonConvert.SerializeObject(alu,Formatting.Indented));
			Console.WriteLine();
			Alumno output = alumnoRepository.GetByID(2).First<Alumno>();
			Console.Write(JsonConvert.SerializeObject(output, Formatting.Indented));
			Console.ReadLine();
		}
	}
}
