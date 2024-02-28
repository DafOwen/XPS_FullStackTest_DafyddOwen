using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToRoman
{
    public class IntegerToRomanConverter
    {

        private Dictionary<Int32, string> numeralsInput = new Dictionary<int, string>();
        private Int32 _inputInt, _maxInteger;

        public IntegerToRomanConverter()
        {
            //Fetch Numeral Values
            GetNumeralValues();
        }


        //String parameter overload
        public string ConvertToRoman(string valString)
        {
            //validation

            //string input
            ValidateInputString(valString);

            //already tested is int, convert type
            _inputInt = Convert.ToInt32(valString.Trim());

            //validate converted Int
            ValidateInputInt(_inputInt);

            return ConvertToRoman();
        }

        //Integer parameter overload
        public string ConvertToRoman(Int32 valInt)
        {
            //validaton
            //INT
            ValidateInputInt(valInt);

            _inputInt = valInt;

            return ConvertToRoman();
        }


        //Fairly simple method - the input data set needs to cover the subtractive numbers as well as standard characters
        private string ConvertToRoman()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (KeyValuePair<int, string> entry in numeralsInput)
            {
                while (_inputInt >= entry.Key)
                {
                    stringBuilder.Append(entry.Value);
                    _inputInt -= entry.Key;
                }
            }

            return stringBuilder.ToString();
        }


        //More complex method - no need for data input / subtraction numerals data
        //Not used
        //KHTML / WebKit method as used in Chrome/Safari (Lars Knoll/Martin Jones)
        //This code builds the Roman numeral from right to left, considering the least significant decimal digit of number in each iteration of the loop and adding letters to the front of the result string.
        //d is an index into the array of letters.Since it always points to a power-of-ten letter, d + 1 points to a letter worth five times as much, and d + 2 to the next power of ten.
        private string ConvertMoreComplex(Int32 valInt)
        {

            //validaton
            //INT
            ValidateInputInt(valInt);

            _inputInt = valInt;

            StringBuilder romanResult = new StringBuilder();

            char[] romanDigits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int i, d = 0;


            do
            {
                int num = _inputInt % 10;

                if (num % 5 < 4)
                    for (i = num % 5; i > 0; i--)
                        romanResult.Insert(0, romanDigits[d]);

                if (num >= 4 && num <= 8)
                    romanResult.Insert(0, romanDigits[d + 1]);

                if (num == 9)
                    romanResult.Insert(0, romanDigits[d + 2]);

                if (num % 5 == 4)
                    romanResult.Insert(0, romanDigits[d]);

                _inputInt /= 10;
                d += 2;
            }
            while (_inputInt != 0);

            return romanResult.ToString();
        }


        private void GetNumeralValues()
        {
            //Initially I put these in an app.config file - I prefer to avoid hard coding number/values
            //But considering these are never going to change and a config file would be a dependancy - moved in here

            //Order important - highest to lowest

            numeralsInput.Add(1000, "M");
            numeralsInput.Add(900, "CM");//subtraction
            numeralsInput.Add(500, "D");
            numeralsInput.Add(400, "CD");//subtraction
            numeralsInput.Add(100, "C");
            numeralsInput.Add(90, "XC");//subtraction
            numeralsInput.Add(50, "L");
            numeralsInput.Add(40, "XL");//subtraction
            numeralsInput.Add(10, "X");
            numeralsInput.Add(9, "IX");//subtraction
            numeralsInput.Add(5, "V");
            numeralsInput.Add(4, "IV");//subtraction
            numeralsInput.Add(1, "I");

        }


        private void ValidateInputString(string valString)
        {
            //null
            if (valString == null)
                throw new ArgumentNullException("Input must be an Integer / not null");

            //Empty/Space
            if (valString.Trim() == "")
                throw new ArgumentException("Input must be an Integer / not empty");


            //Int/NAN
            int testVAl;
            bool valIsInt = int.TryParse(valString, out testVAl);
            if (!valIsInt)
                throw new ArgumentException("Input must be an Integer");

        }

        private void ValidateInputInt(Int32 inputval)
        {
            // Less than 1
            if (inputval < 1)
                throw new ArgumentException("Input Integer must be > 0");

            //4000 or larger - Roman numerals don't work past 3999
            if (inputval > 3999)
                throw new ArgumentException("Input Integer must be =< 3999");
        }


    }
}

