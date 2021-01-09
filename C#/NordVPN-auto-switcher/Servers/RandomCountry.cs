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
        // CountryList.txt needs to exist otherwise it wont work at all <-
        List<string> countryList = System.IO.File.ReadLines(@"CountryList.txt").ToList();
        public string GrabRandomCountry()
        {
            return countryList.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
    }
}
