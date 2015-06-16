using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFL.Framework.Extension;
using System.Collections;

namespace JFL.Framework.Extension.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            string t = "4.7";
            var r = t.IsDecimal();

        }
    }

    public class User
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
