// namespace DesignPatterns;
//
// // sluzi da sakrijemo kompleksne implementacije i ne zamaramo korisnika sa njima
// // Console je primer fasade, Console.WriteLine, Console.ReadLine... su kompleksne implementacije
// // dok su od nas sakrivene i pozivamo jednostavan interfejs
//
// // Primer Bank je fasada - implementacije Execute ne znaju za postojanje Bank klase. 
// // Bank uzima vise podsistema i koristi ih da u okviru jednog mesta korisnik pozove sta mu treba i ne brine o svakoj od implementacija
// public static class Bank
// {
//     public static bool Deposit(decimal amount)
//     {
//         var depositLogic = new DepositLogic();
//         return depositLogic.Execute(amount);
//     }
//
//     public static bool Withdraw(decimal amount)
//     {
//         var withdrawLogic = new WithdrawLogic();
//         return withdrawLogic.Execute(amount);
//     }
//
//     public static bool Loan(decimal amount)
//     {
//         var loanLogic = new LoanLogic();
//         return loanLogic.Execute(amount);
//     }
// }
//
// public interface IBankLogic
// {
//     public bool Execute(decimal amount);
// }
//
// public class DepositLogic : IBankLogic
// {
//     public bool Execute(decimal amount)
//     {
//         // get account
//         // validation
//         // add amount 
//         // update
//         // if executed succesfully return true - else false
//         return true;
//     }
// }
//
// public class WithdrawLogic : IBankLogic
// {
//     public bool Execute(decimal amount)
//     {
//         // get account
//         // validation
//         // check if enough money on account
//         // if not check for "dozvoljeni minus" 
//         // deduct amount
//         // update
//         // if executed succesfully return true - else false
//         return true;
//     }
// }
//
// public class LoanLogic : IBankLogic
// {
//     public bool Execute(decimal amount)
//     {
//         // get account
//         // validation
//         // check if loan can be given out to this account
//         // calculate interest
//         // add amount
//         // update
//         // if load approved return true - else false
//         return true;
//     }
// }
//
// public static class FacadePattern
// {
//     static void Main(string[] args)
//     {
//         Bank.Deposit(100);
//         Bank.Withdraw(50);
//         Bank.Loan(500);
//         // Bank.
//     }
// }