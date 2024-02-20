using HelloWorldConsoleApp.Enums;

namespace HelloWorldConsoleApp;

public class MyApp {
  public static Int32 Main( String[] args ) {
    TransactionType trcType;
    Decimal originalPrice;
    Decimal currentValue;
    Decimal profitLoss;
    Decimal price = 5;
    Int32 nominal;
  
    //Get the nominal amount from the user
    Console.WriteLine("Input the nominal of the trade: ");
    String? userInput = Console.ReadLine();
    nominal = Convert.ToInt32( userInput );

    //Get the transaction type from the user
    Console.WriteLine("Specify transaction type (Buy/Sell):");
    userInput = Console.ReadLine();
    trcType = (TransactionType)Enum.Parse( enumType: typeof( TransactionType ), value: userInput!, ignoreCase: true);

    //Calculate CV
    currentValue = CalculateCurrentValue(trcType: trcType, nominal: nominal, price: price);
    Console.WriteLine("Current value: {0:N3}", currentValue);

    //Get the original price from the user
    Console.WriteLine("Original price: ");
    userInput = Console.ReadLine();

    //Calculate P/L
    originalPrice = Convert.ToDecimal( userInput );
    profitLoss = trcType == TransactionType.Sell ? CalculateProfitLoss(tradePrice: price, originalPrice: originalPrice, nominal: nominal) : 0;
    Console.WriteLine("Profit/Loss: {0:N3}", profitLoss);

    return 0;
  }

  public static Decimal CalculateCurrentValue(TransactionType trcType, Int32 nominal, Decimal price) {
    return price * nominal * Convert.ToInt32(trcType);
  }

  public static Decimal CalculateProfitLoss(Decimal tradePrice, Decimal originalPrice, Int32 nominal) {
    return (tradePrice - originalPrice) * nominal;
  }
}