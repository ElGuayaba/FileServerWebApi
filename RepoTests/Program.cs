﻿using FileServer.Common.Entities;
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
			Alumno alumno2 = new Alumno
			{
				Id = 3,
				Nombre = "Pepe",
				Apellidos = "Popo",
				Dni = "666"
			};
			Alumno alumno3 = new Alumno
			{
				Id = 2,
				Nombre = "Invader",
				Apellidos = "Popo",
				Dni = "666"
			};

			AlumnoRepository alumnoRepository = new AlumnoRepository();
			alumnoRepository.Add(alumno);
			alumnoRepository.Add(alumno1);
			alumnoRepository.Add(alumno2);
			Console.Write("GetAll: ");
			foreach (Alumno alu in alumnoRepository.GetAll())
				Console.WriteLine(JsonConvert.SerializeObject(alu,Formatting.Indented));
			Console.WriteLine("------------");

			Alumno output = alumnoRepository.GetByID(2).First<Alumno>();
			Console.WriteLine(JsonConvert.SerializeObject(output, Formatting.Indented));
			Console.WriteLine("------------");
		
			alumnoRepository.Remove(1);
			foreach (Alumno alu in alumnoRepository.GetAll())
				Console.WriteLine(JsonConvert.SerializeObject(alu, Formatting.Indented));
			Console.WriteLine("------------");

			Alumno retorno = alumnoRepository.Update(alumno3);
			Console.WriteLine("Nombre Retorno: " + retorno.Nombre);
			foreach (Alumno alu in alumnoRepository.GetAll())
				Console.WriteLine(JsonConvert.SerializeObject(alu, Formatting.Indented));
			Console.WriteLine("------------");
			Console.ReadLine();
		}
	}
}
