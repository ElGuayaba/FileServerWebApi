using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Entities
{
	public class ArrayEntity<T>
	{
		public T[] policies { get; set; }
		public T[] clients { get; set; }

	}
}
