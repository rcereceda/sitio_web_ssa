using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace SitioWeb.Helpers
{
    public static class MenuHelper
    {
        public static string Menu(this HtmlHelper helper)
        {
            var sb = new StringBuilder();

            SiteMapNode root = SiteMap.RootNode;
            SiteMapNode current = SiteMap.CurrentNode;            

            //Main Nav
            sb.Append("<div id='main-nav'>");
            // Create opening unordered list tag
            sb.Append("<ul class='tabbed'>");

            // Render root node
            if (current == root)
                sb.AppendLine("<li class='current-tab'>");
            else
                sb.AppendLine("<li>");
            sb.AppendFormat("<a href='{0}'>{1}</a>", root.Url, helper.Encode(root.Title));
            sb.AppendLine("</li>");

            // Render each top level node            
            var topLevelNodes = root.ChildNodes;
            foreach (SiteMapNode node in topLevelNodes)
            {
                if (current != null && (current == node || current.ParentNode == node))
                    sb.AppendLine("<li class='current-tab'>");
                else
                    sb.AppendLine("<li>");

                sb.AppendFormat("<a href='{0}'>{1}</a>", node.Url, helper.Encode(node.Title));
                sb.AppendLine("</li>");
            }

            // Close unordered list tag
            sb.Append("</ul>");
            sb.Append("<div class='clearer'>&nbsp;</div>");
            sb.Append("</div>");

            //Sub Nav
            sb.Append("<div class='sc_menu'>");
            // Create opening unordered list tag
            sb.Append("<ul class='sc_menu'>");
            if (current != null & current != root)
            {
                // Render each sub level node
                var subLevelNodes = current.ChildNodes;
                foreach (SiteMapNode node in subLevelNodes)
                {
                    if (current == node)
                        sb.AppendLine("<li class='current-tab'>");
                    else
                        sb.AppendLine("<li>");

                    sb.AppendFormat("<a href='{0}'>{1}</a>", node.Url, helper.Encode(node.Title));
                    sb.AppendLine("</li>");
                }

                if (current.ParentNode.ParentNode == root)
                {
                    // Render each sub top level node
                    var subTopLevelNodes = current.ParentNode.ChildNodes;
                    foreach (SiteMapNode node in subTopLevelNodes)
                    {
                        if (current == node)
                            sb.AppendLine("<li class='current-tab'>");
                        else
                            sb.AppendLine("<li>");

                        sb.AppendFormat("<a href='{0}'>{1}</a>", node.Url, helper.Encode(node.Title));
                        sb.AppendLine("</li>");
                    }
                }

            }
            // Close unordered list tag
            sb.Append("</ul>");
            sb.Append("<div class='clearer'>&nbsp;</div>");
            sb.Append("</div>");           

            return sb.ToString();
        }
    }
}