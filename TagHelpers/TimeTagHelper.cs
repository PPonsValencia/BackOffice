using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.TagHelpers
{
    [HtmlTargetElement("time", Attributes = "asp-date-time")]
    public class TimeTagHelper : TagHelper
    {
//        private const string DateTimeAttributeName = "asp-date-time";

        [HtmlAttributeName("asp-date-time")]
        public DateTime DateTime { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
//            output.Attributes["datetime"] = DateTime.ToString("yyyy-MM-dd'T'HH:mm:ss") + "Z";
//            output.Attributes["title"] = DateTime.ToString("dddd, MMMM d, yyyy 'at' h:mm tt");

            var childContent = await output.GetChildContentAsync();
            if (childContent.IsEmptyOrWhiteSpace)
            {
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Content.SetContent(DateTime.ToString("MMMM d, yyyy"));
            }
        }
    }
}
