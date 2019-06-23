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
			string carryOn = string.Empty;
			do
			{
				DoWork();
				Console.WriteLine("\nWould you like to make another calculation(Y/N)?");
				carryOn = Console.ReadLine();
			}
			while (carryOn != "y" || carryOn != "Y");

			Console.WriteLine("Thank you, press any key to exit");
			Console.ReadKey();
		}

		public static void DoWork()
		{
			int currentMonth = DateTime.Now.Month;
			int currentYear = DateTime.Now.Year;
			int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
			int numberOfMonths = 0; ;
			double intRate;
			double Balance;
			double DPR;
			double monthlyInterestRate;
			double monthlyPayment;
			double balanceAfterIntCalc;
			Console.WriteLine("What is the interest rate of the credit card:");
			intRate = double.Parse(Console.ReadLine());
			Console.WriteLine("\nWhat is the balance of the credit card:");
			Balance = double.Parse(Console.ReadLine());
			Console.WriteLine("\nHow much are you paying per month:");
			monthlyPayment = double.Parse(Console.ReadLine());

			DPR = intRate / 365;
			monthlyInterestRate = DPR * daysInMonth;
			Console.WriteLine("\nMonth\t\tBalance\t\tDays In Billing Cylce");

			do
			{
				balanceAfterIntCalc = (Balance * (monthlyInterestRate / 100)) + Balance;
				Balance = balanceAfterIntCalc - monthlyPayment;
				numberOfMonths++;
				double roundedBalance = Math.Round(Balance, 2);

				Console.WriteLine($"{numberOfMonths}\t\t{roundedBalance}\t\t{daysInMonth}");
			}
			while (Balance > 0);

			Console.WriteLine($"\nPaying {monthlyPayment} at {intRate} % it will take {numberOfMonths} months to pay off the credit card balance");
		}
	}
}
