using HelloWorldConsoleApp.Enums;

namespace HelloWorldConsoleApp;

public class MyApp {
  public static Int32 Main( String[] args ) {
    TransactionType trcType;
    Decimal currentValue;
    Decimal price = 5;
    Int32 nominal;
  
    Console.WriteLine("Input the nominal of the trade: ");
    String? userInput = Console.ReadLine();
    nominal = Convert.ToInt32( userInput );

    Console.WriteLine("Specify transaction type (Buy/Sell):");
    userInput = Console.ReadLine();
    trcType = (TransactionType)Enum.Parse( enumType: typeof( TransactionType ), value: userInput!, ignoreCase: true);

    currentValue = CalculateCurrentValue(trcType: trcType, nominal: nominal, price: price);
    Console.WriteLine("Current value: {0:N3}", currentValue);
    return 0;
  }

  public static Decimal CalculateCurrentValue(TransactionType trcType, Int32 nominal, Decimal price) {
    return price * nominal * Convert.ToInt32(trcType);
  }
}