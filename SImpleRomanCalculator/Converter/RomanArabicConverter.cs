using System.Text.RegularExpressions;

namespace SimpleRomanCalculator.Converter
{

    public class RomanArabicConverter:IRomanArabicConverter
    {
        private const string DELIMETERS = @"\s*([-+/*()])\s*";
       
        private const string ROMANPATTERN = "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        private Dictionary<string, ushort> RomansDigits = new Dictionary<string, ushort>()
        {  {"M", 1000},
           {"CM",900 },
           {"D", 500},
           {"CD",400 },
           {"C", 100},
           {"XC",90 },
           {"L", 50},
           {"XL",40 },
           {"X", 10},
           {"IX",9 },
           {"V", 5},
           {"IV",4 },
           {"I", 1}
        };
        public List<string> ConvertInputToArabic(string roman)
        {
            if(roman is null||roman.Length == 0)
            {
                throw new ArgumentException("Input can't be empty");
            }
            var strings = Regex.Split(roman.Trim(), DELIMETERS).Where(s => !string.IsNullOrEmpty(s)).ToList();
            for (int i = 0; i < strings.Count; i++)
            {
                {
                    if (strings[i].IndexOfAny(new char[] { '*', '+', '-', '\\', '(', ')' }) == -1)
                    {
                        ushort? number = RomanToArabic(strings[i]);
                        if (number.HasValue) {
                            strings[i] = number.ToString() ;
                        }
                        else
                        {
                            throw new ArgumentException("Incorrect input " + strings[i] + " is not a Roman number");
                        }
                    }
                }
            }
            return strings;
        }

        public ushort? RomanToArabic(string s)
        {
            ushort sum = 0;
            if (IsRomanDigit(s))
            {
                while (s.Length > 0)
                {
                    foreach (var item in RomansDigits)
                    {
                        if (s.StartsWith(item.Key))
                        {
                            sum += item.Value;
                            s = s.Substring(item.Key.Length);
                            break;
                        }
                    }
                }
                return sum;
            }
            else
            {
                return null;
            }
        }

        public string ArabicToRoman(ushort u)
        {
            if (u > 3999)
            {
                throw new ArgumentException("The result is out of range for Roman digits(1-3999)");
            }
            string result = "";
            while (u > 0)
            {
                foreach (var item in RomansDigits)
                {
                    if (u >= item.Value)
                    {
                        u -= item.Value;
                        result += item.Key;
                        break;
                    }
                }
            }
            return result;
        }
        public bool IsRomanDigit(string s)
        {
            Regex regex = new Regex(ROMANPATTERN);
            return regex.IsMatch(s);
        }
    }
}
