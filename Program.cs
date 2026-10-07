void Question1()
{
	try
	{
		Console.Write("Enter the current number of customers: ");
		int currentCustomerCount = Convert.ToInt32(Console.ReadLine());

		Console.Write("Enter the monthly price per customer: ");
		decimal monthlyPricePerCustomer = Convert.ToDecimal(Console.ReadLine());

		Console.Write("Enter the percentage price increase (for example, 7.5 for 7.5%): ");
		decimal percentagePriceIncrease = Convert.ToDecimal(Console.ReadLine());

		if (currentCustomerCount >= 0 && monthlyPricePerCustomer >= 0 && percentagePriceIncrease >= 0)
		{
			decimal priceIncreaseMultiplier = 1m + percentagePriceIncrease / 100m;
			decimal currentMonthlyRevenue = currentCustomerCount * monthlyPricePerCustomer;
			decimal projectedMonthlyRevenue = currentMonthlyRevenue * priceIncreaseMultiplier;
			decimal monthlyRevenueIncrease = projectedMonthlyRevenue - currentMonthlyRevenue;

			Console.WriteLine($"Current monthly revenue: ${currentMonthlyRevenue:0.00}");
			Console.WriteLine($"Projected monthly revenue: ${projectedMonthlyRevenue:0.00}");
			Console.WriteLine($"Monthly revenue increase: ${monthlyRevenueIncrease:0.00}");
		}
		else
		{
			Console.WriteLine("Customer count, monthly price, and percentage increase must not be negative.");
		}
	}
	catch (FormatException)
	{
		Console.WriteLine("Invalid input. Enter numeric values for the customer count, monthly price, and percentage increase.");
	}
	catch (OverflowException)
	{
		Console.WriteLine("One of the entered values is too large or too small.");
	}
}

// Question1();

void Question2()
{
	try
	{
		Console.Write("Enter the annual return rate as a percentage (for example, 7 for 7%): ");
		double annualReturnRatePercent = Convert.ToDouble(Console.ReadLine());

		if (annualReturnRatePercent > 0)
		{
			// Convert 7% to 0.07 because the growth formula uses a fractional rate, not a whole percentage.
			double annualReturnRateDecimal = annualReturnRatePercent / 100;

			// Each year multiplies the investment by (1 + rate), so doubling means (1 + rate)^years = 2.
			// Logarithms bring the unknown exponent (years) down, giving years = log(2) / log(1 + rate).
			double doublingTimeYears = Math.Log(2) / Math.Log(1 + annualReturnRateDecimal);

			Console.WriteLine($"Estimated time to double: {doublingTimeYears:F2} years");

			// Under 10 years is Fast; 10 through 20 years is Moderate; over 20 is Slow.
			if (doublingTimeYears < 10)
			{
				Console.WriteLine("Classification: Fast");
			}
			else if (doublingTimeYears <= 20)
			{
				Console.WriteLine("Classification: Moderate");
			}
			else
			{
				Console.WriteLine("Classification: Slow");
			}
		}
		else
		{
			Console.WriteLine("The annual return rate must be greater than zero.");
		}
	}
	catch (FormatException)
	{
		Console.WriteLine("Invalid input. Enter a numeric annual return rate.");
	}
	catch (OverflowException)
	{
		Console.WriteLine("The entered rate is too large or too small.");
	}
}

// Question2();

void Question3()
{
	try
	{
		Console.Write("Enter side length a: ");
		double sideA = Convert.ToDouble(Console.ReadLine());

		Console.Write("Enter side length b: ");
		double sideB = Convert.ToDouble(Console.ReadLine());

		Console.Write("Enter side length c: ");
		double sideC = Convert.ToDouble(Console.ReadLine());

		if (sideA > 0 && sideB > 0 && sideC > 0)
		{
			// Each pair must be strictly greater than the remaining side; equality is a flat line, not a triangle.
			if (sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA)
			{
				// Heron's formula, including Math.Sqrt, runs only after all triangle checks pass.
				double semiPerimeter = (sideA + sideB + sideC) / 2;
				double triangleArea = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));

				Console.WriteLine($"Triangle area: {triangleArea:F2}");
			}
			else
			{
				Console.WriteLine("Invalid triangle: the sum of each pair of sides must be greater than the remaining side.");
			}
		}
		else
		{
			Console.WriteLine("Invalid side lengths: all three sides must be greater than zero.");
		}
	}
	catch (FormatException)
	{
		Console.WriteLine("Invalid input: enter numeric values for all three side lengths.");
	}
	catch (OverflowException)
	{
		Console.WriteLine("Invalid input: one of the side lengths is too large or too small.");
	}
}

// Question3();

void Question4()
{
	try
	{
		Console.Write("Enter the number of compute hours used: ");
		decimal computeHours = Convert.ToDecimal(Console.ReadLine());

		if (computeHours < 0)
		{
			Console.WriteLine("Compute hours cannot be negative.");
		}
		// Progressive pricing applies each rate only to the hours in that tier.
		else if (computeHours <= 100)
		{
			// The first 100 hours are charged at $0.12 per hour.
			decimal usageCharge = computeHours * 0.12m;
			// Add a 5% service fee to the usage charge to get the invoice total.
			decimal serviceFee = usageCharge * 0.05m;
			decimal totalInvoice = usageCharge + serviceFee;

			Console.WriteLine($"Usage charge: ${usageCharge:0.00}");
			Console.WriteLine($"Service fee: ${serviceFee:0.00}");
			Console.WriteLine($"Total invoice: ${totalInvoice:0.00}");
		}
		else if (computeHours <= 500)
		{
			// Charge the first 100 hours at $0.12 and only the remaining hours at $0.09.
			decimal usageCharge = 100m * 0.12m + (computeHours - 100m) * 0.09m;
			decimal serviceFee = usageCharge * 0.05m;
			decimal totalInvoice = usageCharge + serviceFee;

			Console.WriteLine($"Usage charge: ${usageCharge:0.00}");
			Console.WriteLine($"Service fee: ${serviceFee:0.00}");
			Console.WriteLine($"Total invoice: ${totalInvoice:0.00}");
		}
		else
		{
			// Charge the first 500 hours in their tiers and only hours above 500 at $0.06.
			decimal usageCharge = 100m * 0.12m + 400m * 0.09m + (computeHours - 500m) * 0.06m;
			decimal serviceFee = usageCharge * 0.05m;
			decimal totalInvoice = usageCharge + serviceFee;

			Console.WriteLine($"Usage charge: ${usageCharge:0.00}");
			Console.WriteLine($"Service fee: ${serviceFee:0.00}");
			Console.WriteLine($"Total invoice: ${totalInvoice:0.00}");
		}
	}
	catch (FormatException)
	{
		Console.WriteLine("Invalid input. Enter a numeric number of compute hours.");
	}
	catch (OverflowException)
	{
		Console.WriteLine("The entered number of compute hours is too large or too small.");
	}
}

// Question4();

void Question5()
{
	// Keep the running sum and count so sales can be averaged without storing them in a collection.
	decimal totalSales = 0m;
	int validSaleCount = 0;
	decimal saleAmount = 0m;
	bool keepEnteringSales = true;

	while (keepEnteringSales)
	{
		try
		{
			Console.Write("Enter a sale amount (-1 to finish): ");
			saleAmount = Convert.ToDecimal(Console.ReadLine());

			// -1 ends entry; other negative amounts are rejected and do not change the running totals.
			if (saleAmount == -1m)
			{
				keepEnteringSales = false;
			}
			else if (saleAmount < 0m)
			{
				Console.WriteLine("Invalid sale amount. Enter zero or a positive amount, or -1 to finish.");
			}
			else
			{
				totalSales += saleAmount;
				validSaleCount++;
			}
		}
		catch (FormatException)
		{
			Console.WriteLine("Invalid input. Enter a numeric sale amount, or -1 to finish.");
		}
		catch (OverflowException)
		{
			Console.WriteLine("The sale amount is too large or too small. Try again.");
		}
	}

	// Only calculate an average when at least one valid sale was entered, avoiding division by zero.
	if (validSaleCount > 0)
	{
		decimal averageSale = totalSales / validSaleCount;

		Console.WriteLine($"Number of valid sales: {validSaleCount}");
		Console.WriteLine($"Total sales: ${totalSales:0.00}");
		Console.WriteLine($"Average sale: ${averageSale:0.00}");
	}
	else
	{
		Console.WriteLine("No valid sales were entered.");
	}
}

// Question5();

void Question6()
{
	try
	{
		Console.Write("Enter the initial investment: $");
		decimal initialInvestment = Convert.ToDecimal(Console.ReadLine());

		Console.Write("Enter the monthly benefit: $");
		decimal monthlyBenefit = Convert.ToDecimal(Console.ReadLine());

		if (initialInvestment <= 0m || monthlyBenefit <= 0m)
		{
			Console.WriteLine("The initial investment and monthly benefit must both be greater than zero.");
		}
		else
		{
			// Track accumulated benefits, elapsed months, and the safety limit before starting the simulation.
			decimal cumulativeBenefits = 0m;
			int monthCount = 0;
			int maximumMonths = 600;

			// Continue only while payback has not happened and the 600-month limit has not been reached.
			while (cumulativeBenefits < initialInvestment && monthCount < maximumMonths)
			{
				monthCount++;
				cumulativeBenefits += monthlyBenefit;
				decimal unrecoveredBalance = initialInvestment - cumulativeBenefits;

				// Clamp an overshoot in the final month so the displayed balance never goes below zero.
				if (unrecoveredBalance < 0m)
				{
					unrecoveredBalance = 0m;
				}

				Console.WriteLine($"Month {monthCount}: unrecovered balance ${unrecoveredBalance:0.00}");
			}

			// Report payback if reached; otherwise the loop stopped at the maximum month count.
			if (cumulativeBenefits >= initialInvestment)
			{
				Console.WriteLine($"Payback month: {monthCount}");
				Console.WriteLine($"Cumulative benefits at payback: ${cumulativeBenefits:0.00}");
			}
			else
			{
				Console.WriteLine("The investment was not recovered within 600 months.");
			}
		}
	}
	catch (FormatException)
	{
		Console.WriteLine("Invalid input. Enter numeric values for the initial investment and monthly benefit.");
	}
	catch (OverflowException)
	{
		Console.WriteLine("One of the entered amounts is too large or too small.");
	}
}

// Question6();

void Question7()
{
	// Store one nonnegative demand value for each of the seven days.
	int[] dailyDemand = new int[7];
	int dayIndex = 0;

	// Advance to the next day only after a valid demand value has been stored.
	while (dayIndex < dailyDemand.Length)
	{
		try
		{
			Console.Write($"Enter demand for Day {dayIndex + 1}: ");
			int demandValue = Convert.ToInt32(Console.ReadLine());

			if (demandValue >= 0)
			{
				dailyDemand[dayIndex] = demandValue;
				dayIndex++;
			}
			else
			{
				Console.WriteLine("Demand must be zero or greater. Please try again for this day.");
			}
		}
		catch (FormatException)
		{
			Console.WriteLine("Invalid input. Enter a whole-number demand value for this day.");
		}
		catch (OverflowException)
		{
			Console.WriteLine("The demand value is too large or too small. Please try again for this day.");
		}
	}

	Console.WriteLine("Weekly demand chart:");
	for (int chartDayIndex = 0; chartDayIndex < dailyDemand.Length; chartDayIndex++)
	{
		Console.Write($"Day {chartDayIndex + 1}: {dailyDemand[chartDayIndex]} ");

		// Integer division by 10 drops any remainder; print one star for each complete group of 10.
		for (int starIndex = 0; starIndex < dailyDemand[chartDayIndex] / 10; starIndex++)
		{
			Console.Write("*");
		}

		Console.WriteLine();
	}
}

// Question7();

int ComputeRiskScore(int missedPayments, int supportTickets, int monthsInactive)
{
	return missedPayments * 20 + supportTickets * 5 + monthsInactive * 8;
}

void Question8()
{
	try
	{
		Console.Write("Enter the number of missed payments: ");
		int missedPayments = Convert.ToInt32(Console.ReadLine());

		Console.Write("Enter the number of support tickets: ");
		int supportTickets = Convert.ToInt32(Console.ReadLine());

		Console.Write("Enter the number of months inactive: ");
		int monthsInactive = Convert.ToInt32(Console.ReadLine());

		// Reject negative inputs before calculating a score.
		if (missedPayments < 0 || supportTickets < 0 || monthsInactive < 0)
		{
			Console.WriteLine("Missed payments, support tickets, and months inactive must not be negative.");
		}
		else
		{
			// Delegate the calculation; this function handles input, validation, and classification.
			int riskScore = ComputeRiskScore(missedPayments, supportTickets, monthsInactive);
			string riskClassification;

			// Scores below 30 are Low, 30 through 59 are Moderate, and 60 or more are High.
			if (riskScore < 30)
			{
				riskClassification = "Low";
			}
			else if (riskScore < 60)
			{
				riskClassification = "Moderate";
			}
			else
			{
				riskClassification = "High";
			}

			Console.WriteLine($"Risk score: {riskScore}");
			Console.WriteLine($"Risk classification: {riskClassification}");
		}
	}
	catch (FormatException)
	{
		Console.WriteLine("Invalid input. Enter whole numbers for all three values.");
	}
	catch (OverflowException)
	{
		Console.WriteLine("One of the entered values is too large or too small.");
	}
}

// Question8();

void Question9()
{
	int transactionCount = 0;
	// Keep asking until the requested array size is within the allowed range.
	while (transactionCount < 3 || transactionCount > 20)
	{
		try
		{
			Console.Write("Enter the number of transactions (3 through 20): ");
			transactionCount = Convert.ToInt32(Console.ReadLine());

			if (transactionCount < 3 || transactionCount > 20)
			{
				Console.WriteLine("Enter a whole number from 3 through 20.");
			}
		}
		catch (FormatException)
		{
			Console.WriteLine("Invalid input. Enter a whole number from 3 through 20.");
		}
		catch (OverflowException)
		{
			Console.WriteLine("The transaction count is too large or too small. Try again.");
		}
	}

	decimal[] transactionAmounts = new decimal[transactionCount];
	int transactionIndex = 0;
	// Retry invalid amounts without advancing, so each array slot receives a valid nonnegative amount.
	while (transactionIndex < transactionAmounts.Length)
	{
		try
		{
			Console.Write($"Enter amount for transaction {transactionIndex + 1}: $");
			decimal transactionAmount = Convert.ToDecimal(Console.ReadLine());

			if (transactionAmount < 0m)
			{
				Console.WriteLine("Transaction amounts cannot be negative. Try again for this transaction.");
			}
			else
			{
				transactionAmounts[transactionIndex] = transactionAmount;
				transactionIndex++;
			}
		}
		catch (FormatException)
		{
			Console.WriteLine("Invalid input. Enter a numeric transaction amount.");
		}
		catch (OverflowException)
		{
			Console.WriteLine("The transaction amount is too large or too small. Try again.");
		}
	}

	decimal totalTransactions = 0m;
	// Start min and max from an actual transaction amount so the data determines both values.
	decimal minimumTransaction = transactionAmounts[0];
	decimal maximumTransaction = transactionAmounts[0];

	// Sum all amounts and update the minimum and maximum in one pass.
	for (int index = 0; index < transactionAmounts.Length; index++)
	{
		decimal currentAmount = transactionAmounts[index];
		totalTransactions += currentAmount;

		if (currentAmount < minimumTransaction)
		{
			minimumTransaction = currentAmount;
		}

		if (currentAmount > maximumTransaction)
		{
			maximumTransaction = currentAmount;
		}
	}

	decimal meanTransaction = totalTransactions / transactionCount;
	Console.WriteLine($"Minimum transaction: ${minimumTransaction:0.00}");
	Console.WriteLine($"Maximum transaction: ${maximumTransaction:0.00}");
	Console.WriteLine($"Total transactions: ${totalTransactions:0.00}");
	Console.WriteLine($"Mean transaction: ${meanTransaction:0.00}");

	// Classify in a second pass because the mean is known only after calculating the total.
	for (int index = 0; index < transactionAmounts.Length; index++)
	{
		string transactionLabel;
		if (transactionAmounts[index] > 1.5m * meanTransaction)
		{
			transactionLabel = "Review";
		}
		else
		{
			transactionLabel = "Normal";
		}

		Console.WriteLine($"Transaction {index + 1}: ${transactionAmounts[index]:0.00} - {transactionLabel}");
	}
}

// Question9();

decimal Q10CalculateTotalSales(decimal[] dailySales)
{
	decimal totalSales = 0m;
	for (int index = 0; index < dailySales.Length; index++)
	{
		totalSales += dailySales[index];
	}
	return totalSales;
}

decimal Q10CalculateAverageSales(decimal[] dailySales)
{
	// Revised after my review: Reuse the total calculation so the summing loop exists in only one method.
	return Q10CalculateTotalSales(dailySales) / dailySales.Length;
}

decimal Q10FindHighestSales(decimal[] dailySales)
{
	decimal highestSales = dailySales[0];
	// Revised after my review: Start at index 1 because index 0 already initializes the highest value.
	for (int index = 1; index < dailySales.Length; index++)
	{
		if (dailySales[index] > highestSales)
		{
			highestSales = dailySales[index];
		}
	}
	return highestSales;
}

decimal Q10FindLowestSales(decimal[] dailySales)
{
	decimal lowestSales = dailySales[0];
	// Revised after my review: Start at index 1 because index 0 already initializes the lowest value.
	for (int index = 1; index < dailySales.Length; index++)
	{
		if (dailySales[index] < lowestSales)
		{
			lowestSales = dailySales[index];
		}
	}
	return lowestSales;
}

int Q10CountDaysAboveAverage(decimal[] dailySales, decimal averageSales)
{
	int daysAboveAverage = 0;
	for (int index = 0; index < dailySales.Length; index++)
	{
		if (dailySales[index] > averageSales)
		{
			daysAboveAverage++;
		}
	}
	return daysAboveAverage;
}

void Question10()
{
	decimal[] dailySales = new decimal[7];
	int dayIndex = 0;

	while (dayIndex < dailySales.Length)
	{
		try
		{
			Console.Write($"Enter sales for Day {dayIndex + 1}: $");
			decimal salesAmount = Convert.ToDecimal(Console.ReadLine());

			if (salesAmount < 0m)
			{
				Console.WriteLine("Sales cannot be negative. Please try again for this day.");
			}
			else
			{
				dailySales[dayIndex] = salesAmount;
				dayIndex++;
			}
		}
		catch (FormatException)
		{
			Console.WriteLine("Invalid input. Enter a numeric sales amount for this day.");
		}
		catch (OverflowException)
		{
			Console.WriteLine("The sales amount is too large or too small. Please try again for this day.");
		}
	}

	Console.WriteLine("Daily sales:");
	for (int index = 0; index < dailySales.Length; index++)
	{
		Console.WriteLine($"Day {index + 1}: ${dailySales[index]:0.00}");
	}

	decimal totalSales = Q10CalculateTotalSales(dailySales);
	decimal averageSales = Q10CalculateAverageSales(dailySales);
	decimal highestSales = Q10FindHighestSales(dailySales);
	decimal lowestSales = Q10FindLowestSales(dailySales);
	int daysAboveAverage = Q10CountDaysAboveAverage(dailySales, averageSales);

	string weekClassification;
	if (daysAboveAverage >= 4)
	{
		weekClassification = "Strong";
	}
	else if (daysAboveAverage >= 2)
	{
		weekClassification = "Balanced";
	}
	else
	{
		weekClassification = "Concentrated";
	}

	Console.WriteLine($"Total sales: ${totalSales:0.00}");
	Console.WriteLine($"Average sales: ${averageSales:0.00}");
	Console.WriteLine($"Highest sales: ${highestSales:0.00}");
	Console.WriteLine($"Lowest sales: ${lowestSales:0.00}");
	Console.WriteLine($"Days above average: {daysAboveAverage}");
	Console.WriteLine($"Week classification: {weekClassification}");
}

Question10();
