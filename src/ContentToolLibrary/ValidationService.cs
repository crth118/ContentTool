using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using ContentToolLibrary.Models;

namespace ContentToolLibrary
{
    public class ValidationService
    {
        public List<string> ErrorMessages = new();
        
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
        
        /// <summary>
        /// Validates all playlists. Logs any errors to ErrorMessages list
        /// </summary>
        /// <param name="allPlaylists"></param>
        /// <returns></returns>
        public bool AreValidPlaylists(List<XMLPlaylistModel.Playlist> allPlaylists)
        {
            foreach (var playlist in allPlaylists)
            {
                foreach (var entry in playlist.Content)
                {
                    if (!IsValidSlideDuration(entry.Duration))
                    {
                        var msg = $"Invalid slide duration for {entry.Path}";
                        ErrorMessages.Add(msg);
                    }

                    if (entry.StartDate == null && entry.StopDate == null)
                    {
                        continue;
                    }

                    if (!IsValidDate(entry.StartDate))
                    {
                        var msg = $"Invalid start date for {entry.Path}";
                        ErrorMessages.Add(msg);
                    }

                    if (!IsValidDate(entry.StopDate))
                    {
                        var msg = $"Invalid stop date for {entry.Path}";
                        ErrorMessages.Add(msg);
                    }

                    var dateCompare = CompareDates(entry.StartDate, entry.StopDate);
                    if (dateCompare == 0 || dateCompare > 0)
                    {
                        var msg = $"{entry.StartDate} is at or equal to {entry.StopDate}." +
                                  $"The start date must be BEFORE the stop date";
                        ErrorMessages.Add(msg);
                    }
                }    
            }

            return ErrorMessages.Any();
        }
    }
}