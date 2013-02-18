using System;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcLanguageUrls
{
	/// <summary>
	/// Helpers to register default routers.
	/// </summary>
	public static class MvcUrlExtension
	{
		private const string RedirectToLocalizedRouteName = "RedirectToLocalizedRoute";
		/// <summary>
		/// The default localized router name.
		/// </summary>
		public const string LocalizedRouteName = "LocalizedDefaultRoute";

		static MvcUrlExtension()
		{
			_languageRouteKey = "lang";
		}

		private static bool _initialized;
		private static string _languageRouteKey;
		private static string _defaultLanguage;
		private static RedirectToLozalizedRoute _defaultLanguageRedirectToLozalizedRoute;

		/// <summary>
		/// Language key name in default router name.
		/// </summary>
		/// <exception cref="InvalidOperationException">The router is registered and this key can not be changed.</exception>
		public static string LanguageRouteKey
		{
			get { return _languageRouteKey; }
			set
			{
				if (_initialized)
					throw new InvalidOperationException("LanguageRouteKey is already initialized!");
				_languageRouteKey = value;
			}
		}

		/// <summary>
		/// Maps default localized language router.
		/// </summary>
		/// <param name="routes">The route collection intance.</param>
		/// <param name="languages">Languages to support.</param>
		public static void MapLocalizedRoute(RouteCollection routes, params string[] languages)
		{
			if (languages == null || languages.Length == 0)
				return;
			_defaultLanguage = languages[0];
			var lngCodes = string.Join("|", languages);

			routes.MapRoute(
				LocalizedRouteName,
				string.Format("{{{0}}}/{{controller}}/{{action}}/{{id}}", _languageRouteKey),
				new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				new { lang = string.Format(@"\A{0}\z", lngCodes) }
				);

			_initialized = true;
		}

		/// <summary>
		/// Redirect to localized route if language in not specified.
		/// </summary>
		public static void RedirectToLocalizedRoute(
			RouteCollection routes,
			bool enable,
			bool userCurrentCulturLanguage = true,
			string defaulLanguage = "")
		{
			if (enable)
			{
				var lng = defaulLanguage;
				if (string.IsNullOrWhiteSpace(lng))
					lng = _defaultLanguage;

				if (_defaultLanguageRedirectToLozalizedRoute != null)
					routes.Remove(_defaultLanguageRedirectToLozalizedRoute);

				_defaultLanguageRedirectToLozalizedRoute = new RedirectToLozalizedRoute(userCurrentCulturLanguage, lng);
				routes.Add(RedirectToLocalizedRouteName, _defaultLanguageRedirectToLozalizedRoute);
			}
			else
			{
				if (_defaultLanguageRedirectToLozalizedRoute != null)
					routes.Remove(_defaultLanguageRedirectToLozalizedRoute);
				_defaultLanguageRedirectToLozalizedRoute = null;
			}
		}

		internal static string GetCultureTwoDigit()
		{
			return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower();
		}
	}
}