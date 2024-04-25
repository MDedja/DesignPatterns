// using MoreLinq.Extensions;
//
// namespace DesignPatterns;
//
// public interface IDatabase
// {
//     public int GetPopulation(string names);
// }
//
// public class SingletonDatabase : IDatabase
// {
//     private Dictionary<string, int> capitals;
//     public static int Count { get; private set; }
//     public static SingletonDatabase Instance { get; } = new();
//     private SingletonDatabase()
//     {
//         Console.WriteLine("Initializing database");
//         Count++;
//         capitals = LoadCapitalsFromFile();
//     }
//
//     private static Dictionary<string, int> LoadCapitalsFromFile()
//     {
//         return File.ReadAllLines(
//                 Path.Combine(
//                     new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
//             )
//             .Batch(2)
//             .ToDictionary(
//                 list => list.ElementAt(0).Trim(),
//                 list => int.Parse(list.ElementAt(1)));
//     }
//     public int GetPopulation(string name)
//     {
//         return capitals[name];
//     }
//
// }
//
// class Singleton
// {
//     static void Main(string[] args)
//     {
//         var db = SingletonDatabase.Instance;
//         Console.WriteLine("["+SingletonDatabase.Count + "]"+"New York population is " + db.GetPopulation("New York"));
//         
//         
//         var db2 = SingletonDatabase.Instance;
//         Console.WriteLine("["+SingletonDatabase.Count + "]"+"New York population is " + db2.GetPopulation("New York"));
//         
//         
//         var db3 = SingletonDatabase.Instance;
//         Console.WriteLine("["+SingletonDatabase.Count + "]"+"New York population is " + db3.GetPopulation("New York"));
//
//         
//         // primer ako izmenimo ctor na public
//         // var db4 = new SingletonDatabase();
//         // Console.WriteLine("["+SingletonDatabase.Count + "]"+"New York population is " + db3.GetPopulation("New York"));
//     }
// }
//
//
//
