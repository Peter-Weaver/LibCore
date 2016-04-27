using System.Collections.Generic;

namespace LibCore
{
    public class Compare
    {
        public static bool CompareLower(string str1, string str2, bool trim)
        {
            if (trim)
                return str1.ToLower().Trim().Equals(str2.ToLower().Trim());
            else
                return str1.ToLower().Equals(str2.ToLower());
        }

        // Wacky and custom functions that I need for projects

        public static bool IsInStringList(List<string> items, string item) 
        {
            foreach (string i in items)
            {
                return CompareLower(i, item, true);
            }

            return false;
        }
         
        public static List<string> IsInStringListRemove(List<string> items, string item)
        {
            // Credit: http://stackoverflow.com/questions/1582285/how-to-remove-elements-from-a-generic-list-while-iterating-over-it
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (CompareLower(items[i], item, true))
                {
                    items.RemoveAt(i);
                }
            }

            return items;
        }
    }
}