using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using ContentToolLibrary.Models;

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

        private int CompareDates(string startDate, string stopDate)
        {
            var format = "yyyy-MM-dd";
            var culture = CultureInfo.CurrentCulture;
            
            var newStartDate = DateTime.ParseExact(startDate, format, culture);
            var newStopDate = DateTime.ParseExact(startDate, format, culture);

            return DateTime.Compare(newStartDate, newStopDate);
        }

        public bool ValidateAllPlaylists(List<XMLPlaylistModel.Playlist> allPlaylists)
        {
            foreach (var playlist in allPlaylists)
            {
                foreach (var entry in playlist.Content)
                {
                    if (!IsValidSlideDuration(entry.Duration))
                    {
                        //errorlist
                    }

                    if (entry.StartDate == null && entry.StopDate == null)
                    {
                        continue;
                    }

                    if (!IsValidDate(entry.StartDate))
                    {
                        //errorlist
                    }

                    if (!IsValidDate(entry.StopDate))
                    {
                        //errorlist
                    }

                    var dateCompare = CompareDates(entry.StartDate, entry.StopDate);
                    if (dateCompare == 0 || dateCompare > 0)
                    {
                        //erroList
                    }
                }    
            }
        }
    }
}