using System.Text;

namespace DesignPatterns
{
    // + Open/Close - lako dodavanje nove strategije bez diranja postojeceg koda
    // + Izdvajanje logike u odvojene celine
    public enum OutputFormat
    {
        Markdown,
        Html,
        HtmlProMax
    }

    // Pravimo interfejs za strategiju - u nasem slucaju sta lista svakog jezika treba da ima 
    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }

    // Implementacija strategije - lista u Markdown-u 
    public class MarkdownListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
        }

        public void End(StringBuilder sb)
        {
        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" * {item}");
        }
    }

    // Implementacija strategije - lista u html-u
    public class HtmlListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"  <li>{item}</li>");
        }
    }

    public class HtmlProMaxListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<miki>");
        }
    
        public void End(StringBuilder sb)
        {
            sb.AppendLine("</miki>");
        }
    
        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"  <milane>{item}</milane>");
        }
    }

    public class TextProcessor
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy listStrategy;

        public void SetOutputFormat(OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.Markdown:
                    listStrategy = new MarkdownListStrategy();
                    break;
                case OutputFormat.Html:
                    listStrategy = new HtmlListStrategy();
                    break;
                case OutputFormat.HtmlProMax:
                    listStrategy = new HtmlProMaxListStrategy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);
            foreach (var item in items)
                listStrategy.AddListItem(sb, item);
            listStrategy.End(sb);
        }

        public StringBuilder Clear()
        {
            return sb.Clear();
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public static class StrategyPattern
    {
        static void Main(string[] args)
        {
            var tp = new TextProcessor();
            tp.SetOutputFormat(OutputFormat.Markdown);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp);

            tp.Clear();
            tp.SetOutputFormat(OutputFormat.Html);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp);

            tp.Clear();
            tp.SetOutputFormat(OutputFormat.HtmlProMax);
            tp.AppendList(new[] { "bas", "mi", "ne das", "mira" });
            Console.WriteLine(tp);
        }
    }
}











public interface ICalculationStrategy
{
    int Calculate(int value1, int value2);
}

// ConcreteStrategy
public class AdditionStrategy : ICalculationStrategy
{
    public int Calculate(int value1, int value2)
    {
        return value1 + value2;
    }
}
public class SubtractionStrategy : ICalculationStrategy
{
    public int Calculate(int value1, int value2)
    {
        return value1 - value2;
    }
}
// Context
public class Calculator
{
    private ICalculationStrategy _strategy;
    public Calculator(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }
    public int ExecuteCalculation(int value1, int value2)
    {
        return _strategy.Calculate(value1, value2);
    }
    
    // new Calculator(  )
}