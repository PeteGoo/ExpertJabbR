using System;
using System.Threading.Tasks;
using JabbR.ContentProviders.Core;

namespace JabbR.ContentProviders
{
    public class ExpertTfsChunkContentProvider : CollapsibleContentProvider
    {
        private static readonly string _iframedMeetingFormat = "<iframe src=\"{0}\" width=\"700\" height=\"400\"></iframe>";

        protected override Task<ContentProviderResult> GetCollapsibleContent(ContentProviderHttpRequest request)
        {
            return TaskAsyncHelper.FromResult(new ContentProviderResult()
            {
                Content = String.Format(_iframedMeetingFormat, request.RequestUri.AbsoluteUri),
                Title = "Info:"
            });
        }

        public override bool IsValidContent(Uri uri)
        {
            return uri.AbsoluteUri.StartsWith("http://expertdevautomationcloud.azurewebsites.net/HubotTfsChunk/", StringComparison.OrdinalIgnoreCase);
        }
    }
}