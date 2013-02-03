using System;
using System.Threading.Tasks;
using JabbR.ContentProviders.Core;

namespace JabbR.ContentProviders
{
    public class ExpertTfsChunkContentProvider : CollapsibleContentProvider
    {
        private static readonly string _iframedMeetingFormat = "<div id=\"{0}\"></div><script language=\"javascript\">jQuery.support.cors = true;$.get('{1}',null,function(result) {{$(\"#{0}\").html(result.replace('\"/Content/', '\"http://expertdevautomationcloud.azurewebsites.net/Content/')); }},'html');</script>";

        protected override Task<ContentProviderResult> GetCollapsibleContent(ContentProviderHttpRequest request)
        {
            return TaskAsyncHelper.FromResult(new ContentProviderResult()
            {
                Content = String.Format(_iframedMeetingFormat, "hubot" + Guid.NewGuid().ToString().Replace("-", ""), request.RequestUri.AbsoluteUri),
                Title = "Info:"
            });
        }

        public override bool IsValidContent(Uri uri)
        {
            return uri.AbsoluteUri.StartsWith("http://expertdevautomationcloud.azurewebsites.net/HubotTfsChunk/", StringComparison.OrdinalIgnoreCase);
        }
    }
}