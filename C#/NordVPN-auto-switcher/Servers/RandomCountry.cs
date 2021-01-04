using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordVPN_auto_switcher.Servers
{
    class RandomCountry
    {
        List<string> countryList = System.IO.File.ReadLines(@"CountryList.txt").ToList();
        public string GrabRandomCountry()
        {
            return countryList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
    }
}
