using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToRoman.Test
{
    public class InputErrors
    {
        [SetUp]
        public void Setup()
        {
            //AppDomain.CurrentDomain.SetData
        }

        [Test]
        public void Input_Null_ThowError()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            Assert.That(() => converter.ConvertToRoman(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Input_EmptyString_ThowError()
        {

            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            Assert.That(() => converter.ConvertToRoman(""), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Input_SpaceString_ThowError()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            Assert.That(() => converter.ConvertToRoman(" "), Throws.TypeOf<ArgumentException>());
        }


        [Test]
        public void Input_NANString_ThowError()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            Assert.That(() => converter.ConvertToRoman("WRONG"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Input_Decimal_ThowError()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            Assert.That(() => converter.ConvertToRoman("1.566"), Throws.TypeOf<ArgumentException>());
        }




        [Test]
        public void Input_ZeroInt_ThowError()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            Assert.That(() => converter.ConvertToRoman("0"), Throws.TypeOf<ArgumentException>());
        }


        [Test]
        public void Input_NegativeInt_ThowError()
        {
            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            Assert.That(() => converter.ConvertToRoman("-5"), Throws.TypeOf<ArgumentException>());
        }


        [Test]
        public void Input_OverMaxInt_ThowError()
        {
            //Int32 maxInt = Convert.ToInt32(ConfigurationManager.AppSettings["inputMaxInt"]);

            IntegerToRomanConverter converter = new IntegerToRomanConverter();



            //Assert.That(() => converter.ConvertToRoman(maxInt+1), Throws.TypeOf<ArgumentException>());
            Assert.That(() => converter.ConvertToRoman(4000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Input_OverMaxString_ThowError()
        {
            //get max from config
            //Int32 maxInt = Convert.ToInt32(ConfigurationManager.AppSettings["inputMaxInt"]);

            IntegerToRomanConverter converter = new IntegerToRomanConverter();

            //Assert.That(() => converter.ConvertToRoman(Convert.ToString(maxInt + 1)), Throws.TypeOf<ArgumentException>());
            Assert.That(() => converter.ConvertToRoman(Convert.ToString(4000)), Throws.TypeOf<ArgumentException>());
        }
    }
}