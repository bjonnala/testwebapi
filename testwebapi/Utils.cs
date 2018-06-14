using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testwebapi
{
    public class Utils : IUtils
    {
        public string ComputeGuid()
        {
            const string valid = "ABCDEFGHIJKLMNPQRSTUVWXYZ";
            var length = 16;
            StringBuilder guid = new StringBuilder();
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            char[] values = res.ToString().ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form.
                string hexOutput = String.Format("{0:X}", value);
                guid.Append(hexOutput);
            }

            return guid.ToString();
        }

        public string ComputeExpirationTime()
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expirationtime = Math.Round((DateTime.UtcNow.AddDays(30) - unixEpoch).TotalSeconds);

            return expirationtime.ToString();
        }
    }
}
