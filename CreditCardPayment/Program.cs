using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardPayment
{
	class Program
	{
		static void Main(string[] args)
		{
			double intRate;
			double Balance;
			Console.WriteLine("What is the interest rate of the credit card:");
			intRate = double.Parse(Console.ReadLine());
			Console.WriteLine("\nWhat is the balance of the credit card:");
			Balance = double.Parse(Console.ReadLine());

		}
	}
}
