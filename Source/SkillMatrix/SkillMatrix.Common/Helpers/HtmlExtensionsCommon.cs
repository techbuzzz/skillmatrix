using System.Web.Mvc;

namespace SkillMatrix.Common.Helpers
{
    public static class HtmlExtensionsCommon
    {
        public enum Html5InputTypes
        {
            text,
            color,
            date,
            datetime,
            email,
            month,
            number,
            password,
            range,
            search,
            tel,
            time,
            url,
            week
        }

        public enum HtmlButtonTypes
        {
            submit,
            button,
            reset
        }

        public static void AddName(TagBuilder tb,
            string name, string id)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = TagBuilder.CreateSanitizedId(name);

                if (string.IsNullOrWhiteSpace(id))
                    tb.GenerateId(name);
                else
                    tb.MergeAttribute("id",
                        TagBuilder.CreateSanitizedId(id));
            }

            tb.MergeAttribute("name", name);
        }
    }
}