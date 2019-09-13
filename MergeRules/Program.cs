using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeRules
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file:");
            string file = Console.ReadLine();
            StreamReader sr = new StreamReader(file);
            List<string> rules = new List<string>();
            const string fileLoc = @"C:\Users\u1470723\Documents";

            string line = sr.ReadLine();
            rules.Add(line);
            int count = 1;

            while (line != null)
            {
                bool add = true;
                foreach (string rule in rules)
                {
                    if(sameContents(rule, line))
                    {
                        
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    rules.Add(line);
                }
                line = sr.ReadLine();
            }

            StringBuilder sb = new StringBuilder();
            foreach (string rule in rules)
            {
                sb.AppendLine(rule);
            }

            Console.WriteLine(rules.Count);
            File.WriteAllText(fileLoc + "\\mergedRules.out", sb.ToString());
            while (true)
            {

            }
        }

        public static bool sameContents( string a, string b)
        {
            return String.Concat(a.OrderBy(c => c)).SequenceEqual(String.Concat(b.OrderBy(c => c)));
        }
    }
}
