using System;
using System.Collections.Generic;
using System.Globalization;
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
		/// The default localized route name.
		/// </summary>
		public const string LocalizedRouteName = "LocalizedDefaultRoute";
		public const string LocalizedAreaRouteName = "LocalizedAreaDefault_{0}";

		static MvcUrlExtension()
		{
			_languageRouteKey = "lang";
		}

		private static bool _initialized;
		private static string _languageRouteKey;
		private static string _defaultLanguage;
		private static RedirectToLozalizedRoute _defaultLanguageRedirectToLozalizedRoute;
		private static readonly Dictionary<int, string> _userLanguages = new Dictionary<int, string>();

		/// <summary>
		/// Language key name in default route name.
		/// </summary>
		/// <exception cref="InvalidOperationException">The route is registered and this key can not be changed.</exception>
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
		/// Maps default localized language route.
		/// </summary>
		/// <param name="routes">The route collection intance.</param>
		/// <param name="languages">Languages to support.</param>
		public static void MapLocalizedRoute(RouteCollection routes, params string[] languages)
		{
			if (languages == null || languages.Length == 0)
				return;
			_defaultLanguage = languages[0];
			var lngCodes = string.Join("|", languages);
			BuildUserLanguages(languages);

			routes.MapRoute(
				LocalizedRouteName,
				string.Format("{{{0}}}/{{controller}}/{{action}}/{{id}}", _languageRouteKey),
				new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				new { lang = string.Format(@"(?i)\A{0}\z", lngCodes) }
				);

			_initialized = true;
		}


		/// <summary>
		/// Maps default localized language route.
		/// </summary>
		/// <param name="routes">The route collection intance.</param>
		/// <param name="languages">Languages to support.</param>
		/// <param name="namespaces">A set of namespaces for the application.</param>
		public static void MapLocalizedRoute(
			RouteCollection routes,
			string[] languages,
			string[] namespaces)
		{
			if (languages == null || languages.Length == 0)
				return;
			_defaultLanguage = languages[0];
			var lngCodes = string.Join("|", languages);
			BuildUserLanguages(languages);

			routes.MapRoute(
				LocalizedRouteName,
				string.Format("{{{0}}}/{{controller}}/{{action}}/{{id}}", _languageRouteKey),
				new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				new { lang = string.Format(@"(?i)\A{0}\z", lngCodes) },
				namespaces
				);

			_initialized = true;
		}


		/// <summary>
		/// Maps area localized language route.
		/// </summary>
		/// <param name="context">The context of the registration area which encapsulates the information that is required in order to register the area.</param>
		/// <param name="areaRegistration">The instance of the area registration class implementation.</param>
		/// <param name="languages">Languages to support.</param>
		public static void MapLocalizedAreaRoute(
			AreaRegistrationContext context,
			AreaRegistration areaRegistration,
			params string[] languages)
		{
			if (languages == null || languages.Length == 0)
				return;
			var lngCodes = string.Join("|", languages);
			BuildUserLanguages(languages);

			context.MapRoute(
				string.Format(LocalizedAreaRouteName, areaRegistration.AreaName),
				string.Format("{{{0}}}/{1}/{{controller}}/{{action}}/{{id}}", _languageRouteKey, areaRegistration.AreaName),
				new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				new { lang = string.Format(@"(?i)\A{0}\z", lngCodes) }
				);
		}


		/// <summary>
		/// Maps area localized language route.
		/// </summary>
		/// <param name="context">The context of the registration area which encapsulates the information that is required in order to register the area.</param>
		/// <param name="areaRegistration">The instance of the area registration class implementation.</param>
		/// <param name="urlPrefix">The prefix of the area in URLs.</param>
		/// <param name="languages">Languages to support.</param>
		public static void MapLocalizedAreaRoute(
			AreaRegistrationContext context,
			AreaRegistration areaRegistration,
			string urlPrefix,
			string[] languages)
		{
			if (languages == null || languages.Length == 0)
				return;
			var lngCodes = string.Join("|", languages);
			BuildUserLanguages(languages);

			context.MapRoute(
				string.Format(LocalizedAreaRouteName, areaRegistration.AreaName),
				string.Format("{{{0}}}/{1}/{{controller}}/{{action}}/{{id}}", _languageRouteKey, urlPrefix),
				new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				new { lang = string.Format(@"(?i)\A{0}\z", lngCodes) }
				);
		}


		/// <summary>
		/// Maps area localized language route.
		/// </summary>
		/// <param name="context">The context of the registration area which encapsulates the information that is required in order to register the area.</param>
		/// <param name="areaRegistration">The instance of the area registration class implementation.</param>
		/// <param name="urlPrefix">The prefix of the area in URLs.</param>
		/// <param name="languages">Languages to support.</param>
		/// <param name="namespaces">An enumerable set of namespaces for the application.</param>
		public static void MapLocalizedAreaRoute(
			AreaRegistrationContext context,
			AreaRegistration areaRegistration,
			string urlPrefix,
			string[] languages,
			string[] namespaces)
		{
			if (languages == null || languages.Length == 0)
				return;
			var lngCodes = string.Join("|", languages);
			BuildUserLanguages(languages);

			context.MapRoute(
				string.Format(LocalizedAreaRouteName, areaRegistration.AreaName),
				string.Format("{{{0}}}/{1}/{{controller}}/{{action}}/{{id}}", _languageRouteKey, urlPrefix),
				new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				new { lang = string.Format(@"(?i)\A{0}\z", lngCodes) },
				namespaces
				);
		}

		/// <summary>
		/// Maps area localized language route.
		/// </summary>
		/// <param name="context">The context of the registration area which encapsulates the information that is required in order to register the area.</param>
		/// <param name="areaRegistration">The instance of the area registration class implementation.</param>
		/// <param name="languages">Languages to support.</param>
		/// <param name="namespaces">An enumerable set of namespaces for the application.</param>
		public static void MapLocalizedAreaRoute(
			AreaRegistrationContext context,
			AreaRegistration areaRegistration,
			string[] languages,
			string[] namespaces)
		{
			if (languages == null || languages.Length == 0)
				return;
			var lngCodes = string.Join("|", languages);
			BuildUserLanguages(languages);

			context.MapRoute(
				string.Format(LocalizedAreaRouteName, areaRegistration.AreaName),
				string.Format("{{{0}}}/{1}/{{controller}}/{{action}}/{{id}}", _languageRouteKey, areaRegistration.AreaName),
				new { controller = "Home", action = "Index", id = UrlParameter.Optional },
				new { lang = string.Format(@"(?i)\A{0}\z", lngCodes) },
				namespaces
				);
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


		static void BuildUserLanguages(string[] lang)
		{
			foreach (var l in lang)
			{
				var c = new CultureInfo(l);
				_userLanguages[c.LCID] = l;
			}
		}

		internal static string GetCultureTwoDigit()
		{
			var culture = Thread.CurrentThread.CurrentUICulture;
			string languageCode;
			if (_userLanguages.TryGetValue(culture.LCID, out languageCode))
			{
				return languageCode;
			}
			return culture.TwoLetterISOLanguageName.ToLower();
		}
	}
}