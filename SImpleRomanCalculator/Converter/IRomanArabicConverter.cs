namespace SimpleRomanCalculator.Converter
{
    internal interface IRomanArabicConverter
    {
        abstract List<string> ConvertInputToArabic(string roman);
        abstract ushort? RomanToArabic(string s);
        abstract string ArabicToRoman(ushort u);
    }
}
