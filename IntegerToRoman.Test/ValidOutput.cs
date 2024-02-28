using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToRoman.Test
{
    internal class ValidOutput
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void InputInt1_OuputI()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            var ouput = converter.ConvertToRoman(1);

            Assert.AreEqual("I", ouput);
        }


        [Test]
        public void InputIntFromConfigKey_OuputConfigVal()
        {

            Dictionary<Int32, string> sourceDictionary = ConfigurationManager.AppSettings.AllKeys.Where(key => key.StartsWith("intToRomanVal.")).ToDictionary(key => Convert.ToInt32(key.Replace("intToRomanVal.", "")), val => ConfigurationManager.AppSettings[val]);

            IntegerToRomanConverter converter = new IntegerToRomanConverter();


            string output = "";

            foreach (KeyValuePair<int, string> entry in sourceDictionary)
            {
                output = converter.ConvertToRoman(entry.Key);

                Assert.AreEqual(entry.Value, output);

            }


        }

        [Test]
        public void Input4_OuputIV()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            var ouput = converter.ConvertToRoman(4);

            Assert.AreEqual("IV", ouput);
        }

        [Test]
        public void Input1400_OuputMCD()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            var ouput = converter.ConvertToRoman(1400);

            Assert.AreEqual("MCD", ouput);
        }

        [Test]
        public void Input1999_OuputMCMXCIX()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            var ouput = converter.ConvertToRoman(1999);

            Assert.AreEqual("MCMXCIX", ouput);
        }


        [Test]
        //39 = XXX + IX = XXXIX
        public void Input39_OuputXXXIX()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            var ouput = converter.ConvertToRoman(39);

            Assert.AreEqual("XXXIX", ouput);
        }

        [Test]
        //789 = DCC + LXXX + IX = DCCLXXXIX
        public void Input789_OuputDCCLXXXIX()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            var ouput = converter.ConvertToRoman(789);

            Assert.AreEqual("DCCLXXXIX", ouput);
        }




        [Test]
        public void Input1234_OuputMCCXXXIV()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            var ouput = converter.ConvertToRoman(1234);

            Assert.AreEqual("MCCXXXIV", ouput);
        }

        [Test]
        public void Input3999_OuputMMMCMXCIX()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            var ouput = converter.ConvertToRoman(3999);

            Assert.AreEqual("MMMCMXCIX", ouput);
        }

    }

}
