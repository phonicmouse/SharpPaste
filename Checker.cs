namespace SharpPaste
{
    public class Checker
    {
        public static bool isHex(string test)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        public static void 
    }
}