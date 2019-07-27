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

			CreditCard cc = new CreditCard();
			creditcardDataSet ds = new creditcardDataSet();
			creditcardDataSetTableAdapters.cardsTableAdapter cardsTableAdapter = new creditcardDataSetTableAdapters.cardsTableAdapter();
			
			int numberOfMonths = 0; 
			int monthlyPurchases = 0;
			decimal runningBalance = 0;
			decimal DPR;
			decimal monthlyInterestRate;
			decimal balanceAfterIntCalc;
			decimal monthlyInterestAmount;
			decimal runningMonthlyInterest = 0;
			decimal totalDollars = 0;
			string answerMonthlyCharges;

			do
			{
				Console.WriteLine("\nWhat is the name of the Credit Card?");
				cc.Name = Console.ReadLine();

				if (cc.Name.Length > 23)
				{
					Console.WriteLine("Please enter a name that is less than 23 characters");
				}
			} while (cc.Name.Length > 23);
			Console.WriteLine("What is the interest rate of the credit card:");
			cc.IntRate = decimal.Parse(Console.ReadLine());
			Console.WriteLine("\nWhat is the balance of the credit card:");
			cc.Balance = decimal.Parse(Console.ReadLine());
			Console.WriteLine("\nHow much are you paying per month:");
			cc.MonthlyPayment = int.Parse(Console.ReadLine());
			runningBalance = cc.Balance;
			Console.WriteLine("\nWill you have any monthly charges on this card? (Y/N)");
			answerMonthlyCharges = Console.ReadLine();

			if (answerMonthlyCharges == "y" || answerMonthlyCharges == "Y")
			{
				
				Console.WriteLine("What is your estimated monthly charge on the card?");
				monthlyPurchases = int.Parse(Console.ReadLine());
			}

			cardsTableAdapter.InsertQuery(cc.Name, cc.Balance, cc.IntRate, cc.MonthlyPayment, monthlyPurchases);

			DPR = cc.IntRate / 365;
			
			Console.WriteLine("\nMonth\t\tCredit Card Name\t\tBalance\t\tInterest For The Month\t\tDays In Billing Cylce");
			Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

			do
			{
				int toAdd = 0;
				decimal balanceAfterPayment = cc.Balance - cc.MonthlyPayment;
				int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
				monthlyInterestRate = DPR * daysInMonth;
				balanceAfterIntCalc = (balanceAfterPayment * (monthlyInterestRate / 100)) + balanceAfterPayment;
				decimal monthlyInterestAmountN = balanceAfterPayment * (monthlyInterestRate / 100);
				monthlyInterestAmount = Math.Round(monthlyInterestAmountN, 2);

				numberOfMonths++;
				decimal roundedBalance = Math.Round(balanceAfterIntCalc, 2);
				runningMonthlyInterest += monthlyInterestAmount;


				currentMonth++;
				if (currentMonth > 12)
				{
					currentMonth = 1;
				}

				int nameLength = cc.Name.Length;

				if (nameLength < 23)
				{
					toAdd = ToAdd(nameLength); //31 - nameLength;
				}

				totalDollars = runningBalance + runningMonthlyInterest;
				cc.Balance = roundedBalance + monthlyPurchases;
				Console.WriteLine($"{currentMonth}\t\t{cc.Name.PadRight(toAdd)}\t\t{roundedBalance}\t\t{monthlyInterestAmount}\t\t\t\t{daysInMonth}");
				
				
			}
			while (cc.Balance > 0);

			if (cc.Balance < 0)
			{
				totalDollars -= cc.Balance;
			}

			Console.WriteLine($"\nPaying {cc.MonthlyPayment} at {cc.IntRate}% it will take {numberOfMonths} months to pay off the credit card balance " +
				$"will end up paying at total of {Math.Round(totalDollars,2)}");
		}

		private static int ToAdd(int length)
		{
			if (length < 7)
			{
				return 0;
			}
			return 23 - length;
		}

		private static void FinalMonth()
		{
			
		}
	}
}
