using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PayFastSignatureHelper
{
    /// <summary>
    /// Utility class to generate PayFast MD5 Compatible signatures
    /// </summary>
    public static class PayFastSigner
    {
        /// <summary>
        /// Generates a PayFast compatile MD5 signature from the provided data <collection> and optional passphrase.
        /// </summary>
        /// <param name="data">Key-value pairs or dictionary representing the data to be signed.</param>
        /// <param name="passphrase"/>Optional passphrase used by your PayFast account.</param>
        /// <returns>MD5 signature as a lowercase hexadecimal string.</returns>
        public static string generatePayFastSignature(Dictionary<string, string> data, string? passphrase)
        {
            //check for null or empty data
            if (data == null || data.Count == 0)
                throw new ArgumentException("Data dictionary cannot be null or empty.", nameof(data));

            // build the signature string
            string signatureString = string.Join("&", data.Select(kv => $"{kv.Key}={PhpUrlEncode(kv.Value.Trim())}"));

            // append passphrase if provided
            if (!string.IsNullOrEmpty(passphrase))
            {
                signatureString += $"&passphrase={PhpUrlEncode(passphrase.Trim())}";
            }

            // compute MD5 hash
            var md5signature = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(signatureString));
            string finalHash = BitConverter.ToString(md5signature).Replace("-", "").ToLower();

            return finalHash;
        }

        /// <summary>
        ///  Since Payfast uses PHP's urlencode function, we need to replicate its behavior here.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string PhpUrlEncode(string value)
        {
            var sb = new StringBuilder();

            foreach (byte b in Encoding.UTF8.GetBytes(value))
            {
                if ((b >= 'a' && b <= 'z') ||
                    (b >= 'A' && b <= 'Z') ||
                    (b >= '0' && b <= '9') || b == '-' || b == '_' || b == '.' || b == '~')
                {
                    sb.Append((char)b);
                }
                else if (b == ' ')
                {
                    sb.Append('+');
                }
                else
                {
                    sb.Append('%').Append(b.ToString("X2"));
                }
            }

            return sb.ToString();
        }
    }
}
