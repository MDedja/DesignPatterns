// using System.Runtime.Serialization.Formatters.Binary;
// using System.Text.Json;
// using System.Xml.Serialization;
//
// namespace DesignPatterns;
//
// // Prototype patern koristimo za kopiranje objekata. Ovaj pristup paternu obezbedjuje da novi objekat nema istu referencu.
// // postoje i drugi pristupi gde se npr definise interfejs sa Clone metodom i onda svaka klasa pravi svoju logiku kloniranja
// // problem sa tim je sto kada bi sada hteli da dodamo prototype kod nas na sgs na primer morali bi da idemo od klase do klase
// // i definisemo clone metodu koja za kompleksne klase moze biti bas kompleksna.
//
// public static class ExtensionMethods
// {
//     // Za Xml serializer neophodno je da sve klase imaju prazan ctor
//     public static T DeepCopyXml<T>(this T self)
//     {
//         using var ms = new MemoryStream();
//         XmlSerializer s = new XmlSerializer(typeof(T));
//         s.Serialize(ms, self);
//         ms.Position = 0;
//         return (T)s.Deserialize(ms);
//     }
//     
//     // Za Json serializer neophodno je da sva polja imaju get set
//     public static T DeepCopyJson<T>(this T self)
//     {
//         string json = JsonSerializer.Serialize(self);
//         return JsonSerializer.Deserialize<T>(json)!;
//     }
// }
//
// public class Location
// {
//     public string Code { get; set; }
//     public string Name { get; set; }
//     public Region Region { get; set; }
//
//     public Location()
//     {
//         
//     }
//     
//     public override string ToString()
//     {
//         return $"{nameof(Code)}: {Code}, {nameof(Name)}: {Name}, {nameof(Region)}: {Region}";
//     }
// }
//
// public class Region
// {
//     public string Code { get; set; }
//     public string Name { get; set; }
//
//     public Region()
//     {
//         
//     }
//     public Region(string code, string name)
//     {
//         Code = code;
//         Name = name;
//     }
//     public override string ToString()
//     {
//         return $"{nameof(Code)}: {Code}, {nameof(Name)}: {Name}";
//     }
// }
//
// public static class Prototype
// {
//     static void Main()
//     {
//         Location location = new Location { Code = "locationCode", Name = "locationName", Region = new Region("regionCode","regionName") };
//
//         Location newLocation = location;
//         newLocation.Code = "newCode";
//         newLocation.Region.Code = "newRegCode";
//         Console.WriteLine(location);
//         Console.WriteLine(newLocation);
//         // Location location2 = location.DeepCopyJson();
//         Location location2 = location.DeepCopyXml();
//
//         location2.Code = "newLocCode";
//         location2.Region.Code = "newRegCode";
//         // location2.Region = new Region("newRegCode", "newRegName");
//         Console.WriteLine(location);
//         Console.WriteLine(location2);
//     }
// }