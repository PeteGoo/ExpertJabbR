using System;
using System.Threading.Tasks;
using JabbR.ContentProviders.Core;

namespace JabbR.ContentProviders {
    public class GoogleMapsApiPngContentProvider : CollapsibleContentProvider
    {
        protected override Task<ContentProviderResult> GetCollapsibleContent(ContentProviderHttpRequest request)
        {
            return TaskAsyncHelper.FromResult(new ContentProviderResult()
            {
                Content = String.Format(@"<img src=""{0}"" />", request.RequestUri),
                Title = request.RequestUri.AbsoluteUri.ToString()
            });
        }

        public override bool IsValidContent(Uri uri)
        {
            return uri.AbsoluteUri.StartsWith("http://maps.google.com/maps/api/", StringComparison.OrdinalIgnoreCase) &&  uri.AbsoluteUri.IndexOf("format=png", StringComparison.OrdinalIgnoreCase) > -1;
        }
    }
}