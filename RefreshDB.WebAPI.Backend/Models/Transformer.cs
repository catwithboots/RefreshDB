using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace RefreshDB.WebAPI.Backend.Models
{
    public class Transformer
    {
        public static string RemoveSpecialCharacters(string str)
        {
            // We don't want any special characters except the underscore and dash
            string transformed = Regex.Replace(str, @"[^0-9a-zA-Z\w]+", "_");

            return transformed;
        }
    }
}