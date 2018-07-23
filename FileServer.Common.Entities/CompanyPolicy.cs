using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Entities
{
	public class CompanyPolicy
	{
		public Guid Id { get; set; }
		public decimal AmountInsured { get; set; }
		public string Email { get; set; }
		public DateTime InceptionDate { get; set; }
		public bool InstallmentPayment { get; set; }
		public Guid ClientId { get; set; }
	}
}
