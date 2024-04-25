// using System.Text;
//
// namespace DesignPatterns
// {
//     // Recimo da razvijamo vise igrica koje se igraju po potezima dok jedan od igraca ne pobedi.
//     // Napravimo apstraktnu klasu koju ce nase igre nasledjivati - u njoj predefinisemo ponasanje 
//     // a samu implementaciju metoda ostavimo za sub klase.
//
//     // Ili pravimo burger - ima 100 vrsta sve se prave na isti nacin - lepinja - kackavalj - meso - salata - lepinja
//     
//     public abstract class Game
//     {
//         public void Run()
//         {
//             Start();
//             while (!HaveWinner)
//                 TakeTurn();
//             Console.WriteLine($"Player {WinningPlayer} wins.");
//         }
//
//         protected abstract void Start();
//         protected abstract bool HaveWinner { get; }
//         protected abstract void TakeTurn();
//         protected abstract int WinningPlayer { get; }
//
//         protected int currentPlayer;
//         protected readonly int numberOfPlayers;
//
//         public Game(int numberOfPlayers)
//         {
//             this.numberOfPlayers = numberOfPlayers;
//         }
//     }
//
//     public class Chess : Game
//     {
//         private int maxTurns = 10;
//         private int turn = 1;
//         protected override int WinningPlayer => currentPlayer;
//         protected override bool HaveWinner => turn == maxTurns;
//         public Chess() : base(2)
//         {
//         }
//
//         protected override void Start()
//         {
//             Console.WriteLine($"Starting a game of chess with {numberOfPlayers} players.");
//         }
//
//
//         protected override void TakeTurn()
//         {
//             Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
//             currentPlayer = (currentPlayer + 1) % numberOfPlayers;
//         }
//
//
//         
//     }
//
//     public class TicTacToe : Game
//     {
//         private int maxTurns = 5;
//         private int turn = 1;
//         protected override bool HaveWinner => turn == maxTurns;
//         protected override int WinningPlayer => currentPlayer;
//         
//         public TicTacToe() : base(2)
//         {
//         }
//     
//         protected override void Start()
//         {
//             Console.WriteLine($"Starting a game of tick tack toe with {numberOfPlayers} players.");
//         }
//         protected override void TakeTurn()
//         {
//             Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
//             currentPlayer = (currentPlayer + 1) % numberOfPlayers;
//         }
//     }
//
//     public static class TemplateMethodPattern
//     {
//         static void Main(string[] args)
//         {
//             var chess = new Chess();
//             chess.Run();
//
//             var ticTacToe = new TicTacToe();
//             ticTacToe.Run();
//         }
//     }
// }