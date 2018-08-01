using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Application.Service.Contract
{
	public interface IWorkflow
	{
		void Start();
		void Refresh();
	}
}
