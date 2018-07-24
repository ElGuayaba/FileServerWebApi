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

		public override bool Equals(object obj)
		{
			var policy = obj as CompanyPolicy;
			return policy != null &&
				   Id.Equals(policy.Id) &&
				   AmountInsured.CompareTo(policy.AmountInsured) == 0 &&
				   Email == policy.Email &&
				   InceptionDate == policy.InceptionDate &&
				   InstallmentPayment == policy.InstallmentPayment &&
				   ClientId.Equals(policy.ClientId);
		}

		public override int GetHashCode()
		{
			var hashCode = -1211853315;
			hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
			hashCode = hashCode * -1521134295 + AmountInsured.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
			hashCode = hashCode * -1521134295 + InceptionDate.GetHashCode();
			hashCode = hashCode * -1521134295 + InstallmentPayment.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(ClientId);
			return hashCode;
		}
	}
}
