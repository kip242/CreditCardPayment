using System;

namespace CreditCardPayment
{
	class Program
	{
		static void Main(string[] args)
		{
			string carryOn = string.Empty;
			do
			{
				Console.WriteLine("What would you like to do today\n" +
					"1. Run how long it will take to pay of a credit card\n" +
					"2. Run payoff all credit card scenario");
				string choice = Console.ReadLine();

				if (choice == "1")
				{
					DoWork();
					Console.WriteLine("\nWould you like to make another calculation(Y/N)?");
					carryOn = Console.ReadLine();
				}
				//else
					//AllCardPayoff();
			}
			while (carryOn != "y" || carryOn != "Y");

			Console.WriteLine("Thank you, press any key to exit");
			Console.ReadKey();
		}

		private static void DoWork()
		{
			int currentMonth = DateTime.Now.Month;
			int currentYear = DateTime.Now.Year;
			
			int numberOfMonths = 0; 
			double monthlyPurchases = 0;
			double intRate;
			double Balance;
			double runningBalance = 0;
			double DPR;
			double monthlyInterestRate;
			double monthlyPayment;
			double balanceAfterIntCalc;
			double monthlyInterestAmount;
			double runningMonthlyInterest = 0;
			double totalDollars = 0;
			string answerMonthlyCharges;
			Console.WriteLine("What is the interest rate of the credit card:");
			intRate = double.Parse(Console.ReadLine());
			Console.WriteLine("\nWhat is the balance of the credit card:");
			Balance = double.Parse(Console.ReadLine());
			Console.WriteLine("\nHow much are you paying per month:");
			monthlyPayment = double.Parse(Console.ReadLine());
			runningBalance = Balance;
			Console.WriteLine("\nWill you have any monthly charges on this card? (Y/N)");
			answerMonthlyCharges = Console.ReadLine();

			if (answerMonthlyCharges == "y" || answerMonthlyCharges == "Y")
			{
				
				Console.WriteLine("What is your estimated monthly charge on the card?");
				monthlyPurchases = double.Parse(Console.ReadLine());
			}

			DPR = intRate / 365;
			
			Console.WriteLine("\nMonth\t\tBalance\t\tInterest For The Month\t\tDays In Billing Cylce");
			Console.WriteLine("-------------------------------------------------------------------------------");

			do
			{
				//double roundedBalance;
				double balanceAfterPayment = Balance - monthlyPayment;
			
				
					int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
					monthlyInterestRate = DPR * daysInMonth;
					balanceAfterIntCalc = (balanceAfterPayment * (monthlyInterestRate / 100)) + balanceAfterPayment;
					double monthlyInterestAmountN = balanceAfterPayment * (monthlyInterestRate / 100);
					monthlyInterestAmount = Math.Round(monthlyInterestAmountN, 2);

					numberOfMonths++;
					double roundedBalance = Math.Round(balanceAfterIntCalc, 2);
					runningMonthlyInterest += monthlyInterestAmount;


					currentMonth++;
					if (currentMonth > 12)
					{
						currentMonth = 1;
					}

					totalDollars = runningBalance + runningMonthlyInterest;
					Balance = roundedBalance + monthlyPurchases;
					Console.WriteLine($"{currentMonth}\t\t{roundedBalance}\t\t{monthlyInterestAmount}\t\t\t\t{daysInMonth}");
				
				
			}
			while (Balance > 0);

			if (Balance < 0)
			{
				totalDollars -= Balance;
			}

			Console.WriteLine($"\nPaying {monthlyPayment} at {intRate}% it will take {numberOfMonths} months to pay off the credit card balance " +
				$"will end up paying at total of {Math.Round(totalDollars,2)}");
		}

		private static void FinalMonth()
		{
			
		}
	}
}
