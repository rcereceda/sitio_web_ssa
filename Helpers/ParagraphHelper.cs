using System;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace SitioWeb.Helpers
{
    public static class ParagraphHelper
    {
        public static string GetFirstParagraph(this HtmlHelper helper, string file)
        {            
            Match m = Regex.Match(file, "<p>(.+?)</p>", RegexOptions.Singleline);            
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
            {
                return file;
            }
        }
    }
}