using IntegerToRoman;

namespace IntegerToRomanConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            foreach (string arg in args)
            {

                Console.WriteLine("Argument:{0} Roman:{1}", arg, converter.ConvertToRoman(arg.Trim()));
            }
        }
    }
}
