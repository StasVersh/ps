using System.Collections.Generic;

namespace ProjectAssets.Resources.Scripts.Utilities
{
    public static class CoinsConvertor
    {
        private static List<string> nomes = new List<string>
        {
            "",
            "K",
            "M",
            "B",
            "T",
        };
        
        public static string ToMinString(long value)
        {
            if (value == 0) return "0";

            double number = value;
            
            int i = 0;
            while (i + 1 < nomes.Count && number >= 1000d)
            {
                number /= 1000d;
                i++;
            }
            
            return number.ToString("#.##") + nomes[i];
        }
    }
}