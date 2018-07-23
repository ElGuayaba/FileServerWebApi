using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Entities
{
	public class CompanyClient
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }

		public override bool Equals(object obj)
		{
			var alumno = obj as CompanyClient;
			return alumno != null &&
				   Id == alumno.Id &&
				   Name == alumno.Name &&
				   Email == alumno.Email &&
				   Role == alumno.Role;
		}

		public override int GetHashCode()
		{
			var hashCode = -1407328918;
			hashCode = hashCode * -1521134295 + Id.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Role);
			return hashCode;
		}
	}
}
