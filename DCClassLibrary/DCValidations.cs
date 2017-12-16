using System;
using System.Collections.Generic;
using System.Text;

namespace DCClassLibrary
{
    public class DCValidations
    {
        //Do Capitalize
        public static string DCCapitalize(string inp)
        {

            if (string.IsNullOrEmpty(inp))
            {
                return string.Empty;
            }
            else
            {
                char[] a = inp.ToCharArray();
                a[0] = char.ToUpper(a[0]);
                return new string(a);
            }
        }

        //Post code validations
        public static bool DCPostalCodeValidation(ref string inp)
        {

            if (string.IsNullOrEmpty(inp))
            {
                return true;
            }
            else //perform check
            {
                char[] a = inp.ToCharArray();
                //Check regex
                //if pass
                return true;
                //else
                //return false;

            }

        }

        //Zip Validation
        public static bool DCZipCodeValidation(ref string inp)
        {
            //ii.This can be 5 digits or 9, regardless of any punctuation.  If it this fails this, return false.
            //iii.If it contains 5 digits, return true, along with the 5 digits without any punctuation.
            //iv.If it contains 9 digits return true, along with the 9 digits in the format 12345 - 1234.

            if (string.IsNullOrEmpty(inp)) //5 or 9 digit pass
            {
                return true;
            }
            else 
            {
               
                
                return false;
                //else
                //return false;

            }

        }

    }
}
