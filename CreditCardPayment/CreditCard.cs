using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardPayment
{
	public class CreditCard
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Balance { get; set; }
		public decimal IntRate { get; set; }
		public int MonthlyPayment { get; set; }
		public int MonthlyCharges { get; set; }
	}
}
