using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace IncrementApplicationRevision
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Regex.Replace(File.ReadAllText(args[0]), @"<ApplicationRevision>(\d*)</ApplicationRevision>", match =>
            {
                var revision = int.Parse(match.Groups[1].Value) + 1;

                return string.Format(@"<ApplicationRevision>{0}</ApplicationRevision>", revision);
            
            });

            File.WriteAllText(args[0], text);
        }
    }
}
