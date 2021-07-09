using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace MyLibrus.Validation
{
    public class Validator
    {
        public bool isContainOnlyLetters(string x)
        {            
            bool ans = !x.Any(char.IsDigit);

            if(ans == true)
            {
                return true;
            }
            else
            {
                return false;                
            }
        }
    }
}
