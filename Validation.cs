using System.Text.RegularExpressions;

namespace LibCore
{
    public class Validation
    {
        public bool isNumeric(string input, bool matchDecimal)
        {
            string dec = "";
            
            if (matchDecimal)
                dec = ".";

            string regex = "^[0-9" + dec + "]{1,}$";

            return Regex.IsMatch(input, regex, RegexOptions.Singleline);
        }

        public bool directoryExist(string dir)
        {
            return System.IO.Directory.Exists(dir);
        }
    }
}