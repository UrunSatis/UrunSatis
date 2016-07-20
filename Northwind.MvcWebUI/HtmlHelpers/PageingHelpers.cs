using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.HtmlHelpers
{
    public static class PageingHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper html, PageingInfo pageingInfo)
        {

            int totalPage = (int)Math.Ceiling((decimal)(pageingInfo.TotalItems) / (pageingInfo.ItemsPerPage));
            var StringBuilder = new StringBuilder();
            for (int i = 1; i <= totalPage; i++)
            {
                var tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", string.Format("/Product/Index/?page={0}&category={1}", i, pageingInfo.CurrentCagetory));
                tagBuilder.InnerHtml = i.ToString();
                if (pageingInfo.CurrentPage == i)
                {
                    tagBuilder.AddCssClass("selected");
                }

                StringBuilder.Append(tagBuilder);
            }
            return MvcHtmlString.Create(StringBuilder.ToString());
        }
    }
}