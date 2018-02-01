using SkillMatrix.Common.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SkillMatrix.Common
{
    public partial class Utilities
    {
        private static readonly Lazy<Regex> titleExpression = new Lazy<Regex>(() => new Regex(@"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])"));
        public static string ToTitleFromPascal(this string value, string delimiter = " ")
        {
            return titleExpression.Value.Replace(value, delimiter);
        }


        public static string ToTitleCase(this string value)
        {
            return System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value);
        }

        public static bool IsCyrilic(this string value)
        {
            return Regex.IsMatch(value, @"\p{IsCyrillic}");
        }

        public static bool IsLatin(this string value)
        {
            return !value.IsCyrilic();
        }

        public static string NotNull(this string s1)
        {
            return s1.NotNull(string.Empty);
        }

        public static string NotEmpty(this string s1, params string[] sn)
        {
            return !String.IsNullOrEmpty(s1) ? s1 : sn.FirstOrDefault(s => !String.IsNullOrEmpty(s));
        }

        public static string NotWhiteSpace(this string s1, params string[] sn)
        {
            return !String.IsNullOrWhiteSpace(s1) ? s1 : sn.FirstOrDefault(s => !String.IsNullOrWhiteSpace(s));
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string WhenNotEmpty(this string s, Action<string> trueAction, Action<string> falseAction = null)
        {
            return s.When(!s.IsNullOrEmpty(), trueAction, falseAction);
/*
            if (!String.IsNullOrEmpty(s))
            {
                if (trueAction != null) trueAction(s);
            }
            else
            {
                if (falseAction != null) falseAction(s);
            }
*/
        }

        public static string WhenNotWhitespace(this string s, Action<string> trueAction, Action<string> falseAction = null)
        {
            return s.When(!s.IsNullOrWhiteSpace(), trueAction, falseAction);
/*
            if (!String.IsNullOrWhiteSpace(s))
            {
                if (trueAction != null) trueAction(s);
            }
            else
            {
                if (falseAction != null) falseAction(s);
            }
*/
        }

        public static IEnumerable<string> Chunk(this string str, int chunkSize)
        {
            for (int i = 0; i < str.Length; i += chunkSize)
                yield return str.Substring(i, Math.Min(chunkSize, str.Length - i));
        }


        /// <summary>
        /// This method returns empty string for null object or calls value.ToString for not null
        /// </summary>
        /// <param name="value">object to be converted to string</param>
        /// <returns>Not null string</returns>
        public static string ToStringSafe(this object value)
        {
            return (value ?? string.Empty).ToString();
        }

        public static string LimitStringLength(this string value, int maxLength)
        {
            if(value == null || value.Length <= maxLength)
                return value;
            return value.Substring(0, maxLength);


        }

        /// <summary>
        /// Converts the string to Int32
        /// </summary>
        /// <param name="theInput"></param>
        /// <returns></returns>
        public static int ToInt32(this string theInput)
        {
            return !string.IsNullOrEmpty(theInput) ? Convert.ToInt32(theInput) : 0;
        }

        #region Validation

        public static string md5HashString(string toHash)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            var md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(toHash));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();  // Return the hexadecimal string.
        }

        /// <summary>
        /// Checks to see if the string passed in is a valid email address
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            if (strIn.IsNullOrEmpty())
            {
                return false;
            }

            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        #endregion


       
        /// <summary>
        /// Decode a url
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UrlDecode(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return HttpUtility.UrlDecode(input);
            }
            return input;
        }

        /// <summary>
        /// decode a chunk of html or url
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HtmlDecode(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return HttpUtility.HtmlDecode(input);
            }
            return input;
        }

        /// <summary>
        /// Uses regex to strip HTML from a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripHtmlFromString(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                input = Regex.Replace(input, @"</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>", string.Empty, RegexOptions.Singleline);
                input = Regex.Replace(input, @"\[[^]]+\]", "");
            }
            return input;
        }

        public static string AutoStringBuilder()
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i <= 5; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor((double)((26.0 * random.NextDouble()) + 65.0)))).ToString());
            }
            return builder.ToString();
        }

        public static string GetFaIconForFileExtension(string extension)
        {
            if (!Path.HasExtension(extension)) return string.Empty;
            var ext = Path.GetExtension(extension);
            if (ext != null)
            {
                ext = ext.Substring(1, ext.Length - 1);
                switch (ext)
                {
                    case "doc":
                        return "fa-file-word-o";
                    case "docx":
                        return "fa-file-word-o";
                    case "pdf":
                        return "fa-file-pdf-o";
                    case "xls":
                        return "fa-file-excel-o";
                    case "xlsx":
                        return "fa-file-excel-o";
                    case "ppt":
                        return "fa-file-powerpoint-o";
                    case "pptx":
                        return "fa-file-powerpoint-o";
                    case "txt":
                        return "fa-file-text-o";
                    case "png":
                        return "fa-file-picture-o";
                    case "jpg":
                        return "fa-file-picture-o";
                    case "jpeg":
                        return "fa-file-picture-o";
                    case "zip":
                        return "fa-file-zip-o";
                    case "rar":
                        return "fa-file-archive-o";
                    case "7zip":
                        return "fa-file-archive-o";
                    default:
                            return string.Empty;
                }
                //return ext;
            }
            return string.Empty;
        }

        public static string ClearFileName(string fileName, int trimEnd = 0)
        {
            if (string.IsNullOrEmpty(fileName)) return string.Empty;
            var ext = Path.GetFileNameWithoutExtension(fileName);
            return trimEnd!= 0 ? ext.Trim(trimEnd) : ext;
        }

        public static string GeneratePassword(int lowercase, int uppercase, int numerics,bool existNonLetter)
        {
            var lowers = "abcdefghijklmnopqrstuvwxyz";
            var uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var number = "0123456789";

            var random = new Random();

            var generated = "!";
            for (int i = 1; i <= lowercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    lowers[random.Next(lowers.Length - 1)].ToString()
                );

            for (int i = 1; i <= uppercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    uppers[random.Next(uppers.Length - 1)].ToString()
                );

            for (int i = 1; i <= numerics; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    number[random.Next(number.Length - 1)].ToString()
                );

            return existNonLetter? generated:generated.Replace("!", string.Empty);

        }


    }
}