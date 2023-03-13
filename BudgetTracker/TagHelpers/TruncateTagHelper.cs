using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BudgetTracker.TagHelpers
{
    [HtmlTargetElement("truncate")]
    public class TruncateTagHelper : TagHelper
    {
        [HtmlAttributeName("prefix")]
        public string? prefix { get; set; } = TagHelperConstants.TruncateDefaultPrefix;

        [HtmlAttributeName("suffix")]
        public string? suffix { get; set; } = TagHelperConstants.TruncateDefaultSuffix;

        [HtmlAttributeName("offset")]
        public int offset { get; set; } = TagHelperConstants.TruncateDefaultOffset;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var innerContent = childContent.GetContent();

            if (innerContent.Length > offset)
            { 
                output.Content.SetContent(innerContent.Substring(0, innerContent.Length-offset) + suffix);
            }

            await base.ProcessAsync(context, output);
        }
    }
}
