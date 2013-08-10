using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
		public RedirectToLozalizedRoute(bool useCurrentCultureLangauge,string defaultLanguage)
			: base(ControllerActionId, new MvcRouteHandler())
		{
			_useCurrentCultureLangauge = useCurrentCultureLangauge;
			_defaultLanguage = defaultLanguage;
			if (string.IsNullOrWhiteSpace(_defaultLanguage))
			{
				_defaultLanguage = MvcUrlExtension.GetCultureTwoDigit();
			}
			Defaults = new RouteValueDictionary(new {controller = "Home", action = "Index", id = UrlParameter.Optional});
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
			var redirectUrl = string.Format("/{0}{1}", language, originalUrl);

			httpContext.Response.Status = "302 Redirect to localized version";
			httpContext.Response.StatusCode = 302;
			httpContext.Response.AddHeader("Location", redirectUrl);
			httpContext.Response.End();
		}
	}
}