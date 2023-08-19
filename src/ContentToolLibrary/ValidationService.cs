using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using ContentToolLibrary.Exceptions;

namespace ContentToolLibrary
{
    public class ValidationService
    {
        /// <summary>
        /// Confirms directory path exists
        /// </summary>
        /// <param name="dirPath">Path to check exists</param>
        public bool IsValidPath(string dirPath)
        {
            return Directory.Exists(dirPath);
        }

        /// <summary>
        /// Confirms specified slide duration is correctly formatted
        /// </summary>
        public bool IsValidSlideDuration(string slideDuration)
        {
            var validFormat = new Regex(@"^\d\d\.\d\d$");
            return validFormat.Match(slideDuration).Success;
        }

        /// <summary>
        /// Confirms specified dates are correctly formatted to what the IGT system expects
        /// </summary>
        /// <returns></returns>
        public bool IsValidDate(string date)
        {
            try
            {
                var newDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.CurrentCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}