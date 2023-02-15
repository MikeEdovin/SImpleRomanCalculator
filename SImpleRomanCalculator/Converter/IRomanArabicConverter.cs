using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRomanCalculator.Converter
{
    internal interface IRomanArabicConverter
    {
        abstract List<string> ConvertInputToArabic(string roman);
        abstract ushort? RomanToArabic(string s);
        abstract string ArabicToRoman(ushort u);
    }
}
