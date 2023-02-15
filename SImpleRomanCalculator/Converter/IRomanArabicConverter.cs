namespace SimpleRomanCalculator.Converter
{
    public interface IRomanArabicConverter
    {
        List<string> ConvertInputToArabic(string roman);
        ushort? RomanToArabic(string s);
        string ArabicToRoman(ushort u);
    }
}
