// namespace DesignPatterns;
//
// // apstrakta fabrika - razlika u odnosu na factory method je sto daje 
// // apstrakne objekte umesto pravih kao u factory method.
//
// // izlazemo van samo interfejs IHotDrink
// public interface IHotDrink
// {
//     void Consume();
// }
//
// //Klasa postavljena kao internal kao demonstracija da je u pitanju klasa
// // koja nije vidljiva van asemblija
// internal class Tea : IHotDrink
// {
//     public void Consume()
//     {
//         Console.WriteLine("This tea is nice but I'd prefer it with milk.");
//     }
// }
//
// internal class Coffee : IHotDrink
// {
//     public void Consume()
//     {
//         Console.WriteLine("This coffee is delicious!");
//     }
// }
//
// // recimo da su procesi pripreme razliciti - mozda hocemo da dodamo 
// // vise vrsta kafa ili caja.. Pravimo posebne factory-je i jedan interfejs
// // za njih
// public interface IHotDrinkFactory
// {
//     IHotDrink Prepare(int amount);
// }
//
// internal class TeaFactory : IHotDrinkFactory
// {
//     public IHotDrink Prepare(int amount)
//     {
//         Console.WriteLine($"Put in tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
//         return new Tea();
//     }
// }
//
// internal class CoffeeFactory : IHotDrinkFactory
// {
//     public IHotDrink Prepare(int amount)
//     {
//         Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
//         return new Coffee();
//     }
// }
//
// // ovo nam daje moguc
//
// public class HotDrinkMachine
// {
//     // prvi pristup sa enum-om - moguce ali se krsi O iz SOLID
//     // open for extension but closed for modification
//     // Ako bi hteli da dodamo pice tipa topla cokolada 
//     // dodali bi klasu gore i factory sto je ok ali bi morali ovde 
//     // da dodajemo i enum sto krsi O
//     public enum AvailableDrink
//     {
//         Coffee,
//         Tea
//     }
//
//     private Dictionary<AvailableDrink, IHotDrinkFactory> factories =
//         new Dictionary<AvailableDrink, IHotDrinkFactory>();
//
//     // drugi pristup - bolji jer ne krsi O. Radimo istu stvar ali uz pomoc 
//     // refleksije umesto enuma
//     private List<Tuple<string, IHotDrinkFactory>> namedFactories =
//         new List<Tuple<string, IHotDrinkFactory>>();
//
//     public HotDrinkMachine()
//     {
//         //foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
//         //{
//         //  var factory = (IHotDrinkFactory) Activator.CreateInstance(
//         //    Type.GetType("DesignPatterns." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
//         //  factories.Add(drink, factory);
//         //}
//
//         foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
//         {
//             if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
//             {
//                 namedFactories.Add(Tuple.Create(
//                     t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
//             }
//         }
//     }
//
//     public IHotDrink MakeDrink()
//     {
//         Console.WriteLine("Available drinks");
//         for (var index = 0; index < namedFactories.Count; index++)
//         {
//             var tuple = namedFactories[index];
//             Console.WriteLine($"{index}: {tuple.Item1}");
//         }
//
//         while (true)
//         {
//             string s;
//             if ((s = Console.ReadLine()) != null
//                 && int.TryParse(s, out int i) 
//                 && i >= 0
//                 && i < namedFactories.Count)
//             {
//                 Console.Write("Specify amount: ");
//                 s = Console.ReadLine();
//                 if (s != null
//                     && int.TryParse(s, out int amount)
//                     && amount > 0)
//                 {
//                     return namedFactories[i].Item2.Prepare(amount);
//                 }
//             }
//
//             Console.WriteLine("Incorrect input, try again.");
//         }
//     }
//
//     //public IHotDrink MakeDrink(AvailableDrink drink, int amount)
//     //{
//     //  return factories[drink].Prepare(amount);
//     //}
// }
//
// class AbstractFactory
// {
//     static void Main(string[] args)
//     {
//         var machine = new HotDrinkMachine();
//         //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 300);
//         //drink.Consume();
//
//         IHotDrink drink = machine.MakeDrink();
//         drink.Consume();
//     }
// }