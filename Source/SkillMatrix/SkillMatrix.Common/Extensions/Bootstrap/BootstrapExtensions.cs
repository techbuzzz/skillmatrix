using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace SkillMatrix.Common.Extensions.Bootstrap
{
    public static class BootstrapExtensions
    {
        public static MvcHtmlString TipValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            //< b class="tooltip tooltip-top-right">Please enter email address/username</b>

            // TagBuilder containerDivBuilder = new TagBuilder("b");
            //containerDivBuilder.AddCssClass("tooltip tooltip-top-left");
            var containerDivBuilder = new TagBuilder("small");
            containerDivBuilder.AddCssClass("help-block");
            containerDivBuilder.InnerHtml = helper.ValidationMessageFor(expression).ToString();

            return MvcHtmlString.Create(containerDivBuilder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString FormLabelFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            //TagBuilder requiredSpan = new TagBuilder("span");
            var label = new TagBuilder("label");
            //label.AddCssClass("required");


            if (ModelMetadata.FromLambdaExpression(expression, html.ViewData).IsRequired) label.AddCssClass("require");

            label.Attributes["for"] = TagBuilder.CreateSanitizedId(ExpressionHelper.GetExpressionText(expression));

            return new MvcHtmlString(label.ToString());
        }

        public static MvcHtmlString FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            return html.FormTextBoxFor(expression, null, null);
        }

        public static MvcHtmlString FormTextBoxreadOnly<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            return html.TextBoxFor(expression, null, new {@readonly = "readonly", @class = "form-control"});
        }

        public static MvcHtmlString FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, string format)
        {
            return html.FormTextBoxFor(expression, format, null);
        }

        public static MvcHtmlString FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return html.FormTextBoxFor(expression, null, htmlAttributes);
        }

        public static MvcHtmlString FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, string format, object htmlAttributes)
        {
            RouteValueDictionary attributes = FormHtmlAttributes(expression, htmlAttributes, "form-control");

            return html.TextBoxFor(expression, format, attributes);
        }

        public static MvcHtmlString FormPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression)
        {
            return html.PasswordFor(expression, new {@class = "form-control", autocomplete = "off"});
        }

        public static MvcHtmlString FormTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            return html.FormTextAreaFor(expression, null);
        }

        public static MvcHtmlString FormTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            RouteValueDictionary attributes = FormHtmlAttributes(expression, htmlAttributes, "form-control");
            if (!attributes.ContainsKey("rows")) attributes["rows"] = 6;

            return html.TextAreaFor(expression, attributes);
        }

        public static MvcHtmlString FormDatePickerFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            return html.FormDatePickerFor(expression, null);
        }

        public static MvcHtmlString FormDatePickerFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            RouteValueDictionary attributes = FormHtmlAttributes(expression, htmlAttributes, "form-control datepicker");

            return html.TextBoxFor(expression, "{0:d}", attributes);
        }

        public static MvcHtmlString FormDateTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            return html.FormDateTimePickerFor(expression, null);
        }

        public static MvcHtmlString FormDateTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            RouteValueDictionary attributes =
                FormHtmlAttributes(expression, htmlAttributes, "form-control datetimepicker");

            return html.TextBoxFor(expression, "{0:g}", attributes);
        }

        private static RouteValueDictionary FormHtmlAttributes(LambdaExpression expression, object attributes,
            string cssClass)
        {
            RouteValueDictionary htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);
            if (!htmlAttributes.ContainsKey("autocomplete")) htmlAttributes["autocomplete"] = "off";
            htmlAttributes["class"] = (cssClass + " " + htmlAttributes["class"]).Trim();
            if (htmlAttributes.ContainsKey("readonly")) return htmlAttributes;

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null && memberExpression.Member.IsDefined(typeof(EditableAttribute), false))
            {
                EditableAttribute editable = memberExpression.Member.GetCustomAttribute<EditableAttribute>(false);
                if (!editable.AllowEdit) htmlAttributes["readonly"] = "readonly";
            }

            return htmlAttributes;
        }

        public static HtmlString ValidationSummaryBootstrap(this HtmlHelper htmlHelper)
        {
            if (htmlHelper == null) throw new ArgumentNullException("htmlHelper");

            if (htmlHelper.ViewData.ModelState.IsValid) return new HtmlString(string.Empty);

            return new HtmlString(
                "<div class=\"alert alert-warning\">"
                + htmlHelper.ValidationSummary()
                + "</div>");
        }
    }
}