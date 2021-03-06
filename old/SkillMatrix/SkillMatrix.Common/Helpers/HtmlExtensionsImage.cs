﻿using System;
using System.Web;
using System.Web.Mvc;

namespace SkillMatrix.Common.Helpers
{
    public static class UrlHelperExtension
    {
        public static string ContentFullPath(this UrlHelper url, string virtualPath)
        {
            var result = string.Empty;
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;

            result = string.Format("{0}://{1}{2}",
                requestUrl.Scheme,
                requestUrl.Authority,
                VirtualPathUtility.ToAbsolute(virtualPath));
            return result;
        }
    }

    public static class HtmlExtensionsImage
    {
        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            object htmlAttributes = null)
        {
            return Image(htmlHelper, src, altText,
                string.Empty, string.Empty, htmlAttributes);
        }

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            object htmlAttributes = null)
        {
            return Image(htmlHelper, src, altText,
                cssClass, string.Empty, htmlAttributes);
        }

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            string name,
            object htmlAttributes = null)
        {
            TagBuilder tb = new TagBuilder("img");

            HtmlExtensionsCommon.AddName(tb, name, "");

            tb.MergeAttribute("src", src);
            tb.MergeAttribute("alt", altText);

            if (!string.IsNullOrWhiteSpace(cssClass)) tb.AddCssClass(cssClass);

            tb.MergeAttributes(
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            // HTML Encode the String
            return MvcHtmlString.Create(
                tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}