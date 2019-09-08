using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.TagHelpers
{
    [HtmlTargetElement("img", Attributes = "asp-image")]
    public class ImageTagHelper : TagHelper
    {

    }
}
