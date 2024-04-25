// using System.Text;
// using System.Text.Json.Nodes;
// using System.Xml;
// using System.Xml.Linq;
// using System.Xml.Serialization;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
// using Formatting = System.Xml.Formatting;
//
// namespace DesignPatterns;
//
// // Zamislimo da je ovo neki eksterni Api i koristimo ga da dobijemo podatke sa berze - on vraca podatke u XML-u
// public static class XmlDataApi
// {
//     public static XmlDocument GetXmlDocument()
//     {
//         var a = Path.Combine("C:\\Users\\MilanDedjanski\\RiderProjects\\DesignPatterns\\DesignPatterns\\", "xmlFile");
//         var xmlFile = File.ReadAllLines(a);
//         StringBuilder sb = new StringBuilder();
//         foreach (var line in xmlFile)
//         {
//             sb.Append(line);
//         }
//
//         XmlDocument xDoc = new XmlDocument();
//         xDoc.LoadXml(sb.ToString());
//         return xDoc;
//     }
// }
//
// // Neka je StatisticGenerator neka biblioteka koja radi napredne statisticke proracune ali kao argument prima samo 
// // json, ne radi sa xml-om
// public interface IStatistics
// {
//     public Dictionary<string, string> GenerateStatisticsBasedOnJson(JObject jsonObject);
// }
// public class StatisticsGenerator : IStatistics
// {
//     public Dictionary<string, string> GenerateStatisticsBasedOnJson(JObject jsonObject)
//     {
//         var heading = jsonObject.GetValue("heading").ToString();
//         var body = jsonObject.GetValue("body").ToString();
//         var avrg = body.Split(",");
//         List<int> averageValue = new List<int>();
//         foreach (var value in avrg)
//         {
//             averageValue.Add(int.Parse(value));
//         }
//
//         return new Dictionary<string, string>
//         {
//             { "Title", heading },
//             { "Values", body },
//             { "Average Value", averageValue.Average().ToString() }
//         };
//     }
// }
//
//
// // Sad imamo situaciju da dobijamo xml podatke ali zelimo da ih imamo u json-u kako bi koristili ovu mocnu biblioteku 
// // Zato kreiramo adapter koji ce nam raditi adaptaciju xml-u u json
// public class Adapter
// {
//     public Dictionary<string, string> GetStatistics(XmlDocument xmlDocument)
//     {
//         var jsonObject = ConvertXmlDocumentToJsonObject(xmlDocument);
//         var statisticsGenerator = new StatisticsGenerator();
//         return statisticsGenerator.GenerateStatisticsBasedOnJson(jsonObject);
//     }
//
//     private JObject ConvertXmlDocumentToJsonObject(XmlDocument xmlDocument)
//     {
//         XElement xElement = XElement.Parse(xmlDocument.OuterXml);
//
//         string jsonString = JsonConvert.SerializeXNode(xElement, Newtonsoft.Json.Formatting.None, true);
//
//         return JObject.Parse(jsonString);
//     }
// }
//
// public static class AdapterPattern
// {
//     static void Main(string[] args)
//     {
//         var xmlData = XmlDataApi.GetXmlDocument();
//         // StatisticsGenerator statisticsGenerator = new StatisticsGenerator();
//         // var nono = statisticsGenerator.GenerateStatisticsBasedOnJson(xmlData);
//         Adapter adapter = new Adapter();
//         var result = adapter.GetStatistics(xmlData);
//         foreach (var kvp in result)
//         {
//             Console.WriteLine($"{kvp.Key}: {kvp.Value}");
//         }
//     }
// }