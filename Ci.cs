using System;

namespace CedulaDeIdentidadValidator
{
    public static class Ci
    {
        const int coef = 2987634;
        public static int getValidationNumber(String ci)
        {
            int ret;


            int sum = 0;
            while (ci.Length <= 6)
            {
                ci += "0";
            }

            for (int i = 0; i < 7; i++)
            {

                int n1 = int.Parse(ci[i].ToString());
                int n2 = int.Parse(coef.ToString()[i].ToString());
                sum += n1 * n2;
            }

            int a = sum.ToString().Length - 1;
            int sumP = sum;
            while (sumP.ToString()[a] != '0')
            {
                sumP++;
            }
            ret = sumP - sum;



            return ret;

        }
        public static bool Validate(String ci)
        {

            bool valid = false;
            ci = ci.Trim();
            /*Remove the last char that is the identifier*/
            String cinID = ci.Remove(ci.Length - 1);
            cinID = cinID.Trim();
            /*identifier number*/
            char ciID = ci[ci.Length - 1];

            while (cinID.Length <= 6)
            {
                cinID += "0";
            }

            int ident = getValidationNumber(cinID);


            if (ident.ToString().Trim() == ciID.ToString().Trim())
            {
                valid = true;


            }
            else if (ident.ToString().Trim() != ciID.ToString().Trim())
            {
                valid = false;


            }


            return valid;

        }
        // test 56600650
    }
}
