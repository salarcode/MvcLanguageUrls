using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcLanguageUrls
{
	/// <summary>
	/// 
	/// </summary>
	public class RedirectToLozalizedRoute : Route
	{
		private readonly bool _useCurrentCultureLangauge;
		private readonly string _defaultLanguage;
		private const string ControllerActionId = "{controller}/{action}/{id}";

		/// <summary>
		/// 
		/// </summary>
		public RedirectToLozalizedRoute(bool useCurrentCultureLangauge, string defaultLanguage)
			: base(ControllerActionId, new MvcRouteHandler())
		{
			_useCurrentCultureLangauge = useCurrentCultureLangauge;
			_defaultLanguage = defaultLanguage;
			if (string.IsNullOrWhiteSpace(_defaultLanguage))
			{
				_defaultLanguage = MvcUrlExtension.GetCultureTwoDigit();
			}
			Defaults = new RouteValueDictionary(new { controller = "Home", action = "Index", id = UrlParameter.Optional });
		}

		public override RouteData GetRouteData(HttpContextBase httpContext)
		{
			var data = base.GetRouteData(httpContext);
			if (data == null) return null;

			var lang = data.Values[MvcUrlExtension.LanguageRouteKey];
			if (lang == null)
			{
				string language = _defaultLanguage;
				if (_useCurrentCultureLangauge)
					language = MvcUrlExtension.GetCultureTwoDigit(language);
				data.Values[MvcUrlExtension.LanguageRouteKey] = language;

				RedirectToLocalizedLocation(httpContext, language);
			}
			return data;
		}

		private void RedirectToLocalizedLocation(HttpContextBase httpContext, string language)
		{
			if (httpContext.Request == null || httpContext.Request.Url == null)
			{
				return;
			}

			var originalUrl = httpContext.Request.Url.PathAndQuery;
			if (originalUrl[0] != '/')
				originalUrl = '/' + originalUrl;

			// is bundle?
			if (IsBundledUrl(originalUrl))
			{
				return;
			}

			var redirectUrl = string.Format("/{0}{1}", language, originalUrl);

			httpContext.Response.Status = "302 Redirect to localized version";
			httpContext.Response.StatusCode = 302;
			httpContext.Response.AddHeader("Location", redirectUrl);
			httpContext.Response.End();
		}

		private bool IsBundledUrl(string url)
		{
			if (string.IsNullOrEmpty(url))
				return true;
			url = MakeCompatibleActionUrl(url);

			foreach (var bundle in BundleTable.Bundles)
			{
				var path = MakeCompatibleActionUrl(bundle.Path);
				if (url == path)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Makes bundled urls compatible with relative urls
		/// </summary>
		private static string MakeCompatibleActionUrl(string url)
		{
			if (string.IsNullOrEmpty(url))
				return url;
			url = url.ToLower();
			var qindex = url.IndexOf("?", StringComparison.Ordinal);
			if (qindex > -1)
			{
				url = url.Substring(0, qindex);
			}
			else
			{
				var qhash = url.IndexOf("#", StringComparison.Ordinal);
				if (qhash > -1)
				{
					url = url.Substring(0, qhash);
				}
			}
			if (url[0] == '~')
				url = url.Remove(0, 1);
			if (url[0] != '/')
				url = '/' + url;

			if (url[url.Length - 1] != '/')
				url = url + '/';
			return url;
		}
	}


}