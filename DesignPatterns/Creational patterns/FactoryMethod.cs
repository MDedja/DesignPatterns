// namespace DesignPatterns;
// public enum CoordinateSystem
// {
//     Cartesian, // kordinatni
//     Polar // polarni
// }
//
// public class Point
// {
//     private double x, y;
//
//     // public Point(double x, double y)
//     // {
//     //     this.x = x;
//     //     this.y = y;
//     // }
//
//     // ne mozemo napraviti ctor sa istim parametrima ali za drugu svrhu ( kordinatni ili polarni ) pa bi morali da dodamo 
//     // parametar u ctor tipa CoordinateSystem i na osnovu toga da znamo o kom sistemu je rec. pa bi dodali onda u
//     // umesto ctor gore 
//
//     // public Point(double a, double b, CoordinateSystem cs = CoordinateSystem.Cartesian)
//     // {
//     //     // this.x = x;
//     //     // this.y = y;
//     //     // x i y vise nisu pravilni nazivi jer predstavljaju samo koordniatni tip - moramo da preimenujemo u nesto neutralno
//     //     if (cs == CoordinateSystem.Cartesian)
//     //     {
//     //         x = a;
//     //         y = b;
//     //     }
//     //     else
//     //     {
//     //         x = a * Math.Cos(b);
//     //         y = a * Math.Sin(b);
//     //     }
//     // }
//     
//     
//     // ovo vec postaje kompleksno i nabudzeno - bolji nacin Factory Method ( proizvodni metod )
//
//     // ctrl + . na prvi ctor sto smo imali nam zapravo i daje opciju konverzije u factory metod
//     // public Point(double x, double y)
//     // {
//     //     this.x = x;
//     //     this.y = y;
//     // }
//     
//     // ctrl + . kasnije
//
//     // private Point(double x, double y)
//     // {
//     //     this.x = x;
//     //     this.y = y;
//     // }
//
//     
//     //  Vidimo da je ctor postavljen na private a imamo dve metode koje
//     // u zavisnosti koju pozovemo kreiraju Point na jedan ili drugi nacin. Sada su nazivi parametara smisleni i nemamo
//     // potrebu za enumom
//     
//     // public static Point CreateCartesianPoint(double x, double y)
//     // {
//     //     return new Point(x, y);
//     // }
//     //
//     // public static Point CreatePolarPoint(double rho, double theta)
//     // {
//     //     return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
//     // }
//     
//     
//     // Zasto ne bi imali odvojenu klasu koja se bavi ovim ? SOLID ( kreiranje obj != sta obj radi -> zasebna klasa )
//     
//     // imamo problem sto je ctor sad private i ne vidimo ga iz spoljne klase - za sad stavicemo ga na public ( problem sto nismo primorani 
//     // da korisnimo factory sad jer mozemo i uraditi new Point() zbog public ctor-a.
//     
//     // public Point(double x, double y)
//     // {
//     //     this.x = x;
//     //     this.y = y;
//     // }
//     
//     //ako je u svrhu koriscenja van naseg assembly-ja mozemo staiviti internal i to nam resava problem.
//     // internal Point(double x, double y)
//     // {
//     //     this.x = x;
//     //     this.y = y;
//     // }
//     
//     // hocemo da nam bude private - jedini nacin je da nam Factory bude interna klasa - vracam ctor na private i prebacujem
//     // factory unutra
//     private Point(double x, double y)
//     {
//         this.x = x;
//         this.y = y;
//     }
//     
//     public static class Factory
//     {
//         public static Point CreateCartesianPoint(double x, double y)
//         {
//             return new Point(x, y);
//         }
//     
//         public static Point CreatePolarPoint(double rho, double theta)
//         {
//             return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
//         }
//     }
//     
//     // dodam to string da vidimo ispis 
//     public override string ToString()
//     {
//         return $"{nameof(x)}: {x},{nameof(y)}:{y}";
//     }
// }
//
// // public static class PointFactory
// // {
// //     public static Point CreateCartesianPoint(double x, double y)
// //     {
// //         return new Point(x, y);
// //     }
// //     
// //     public static Point CreatePolarPoint(double rho, double theta)
// //     {
// //         return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
// //     }
// // }
//
// class FactoryMethod
// {
//     static void Main(string[] args)
//     {
//         // var p1 = new Point(2, 3, Point.CoordinateSystem.Cartesian);
//         // var origin = Point.Origin;
//         //
//         // var p2 = Point.Factory.NewCartesianPoint(1, 2);
//         // Console.WriteLine(p2);
//         
//         
//
//         var pointCartesian = Point.Factory.CreateCartesianPoint(3, 2);
//         Console.WriteLine(pointCartesian);
//         var pointPolar = Point.Factory.CreatePolarPoint(2.5, Math.PI / 2);
//         Console.WriteLine(pointPolar);
//         
//         // Task koristi ovaj pristup sa internom klasom 
//         // Task.Factory.
//         // Task.Factory.
//     }
// }