using MvcLanguageUrls;
using System.Collections.Generic;
using System.Web.Routing;

namespace System.Web.Mvc.Html
{
	public static class MvcUrlHelpers
	{
		/// <summary>
		/// 
		/// </summary>
		public static string GetCurrentLanguage(this HtmlHelper htmlHelper)
		{
			return htmlHelper.ViewContext.RouteData.GetCurrentLanguage();
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName)
		{
			return htmlHelper.ActionLink(linkText, actionName, null,
										 new RouteValueDictionary
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey,
						                             MvcUrlExtension.GetCultureTwoDigit()
					                             }
				                             },
										 new RouteValueDictionary());
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   object routeValues)
		{
			return htmlHelper.ActionLink(linkText, actionName, null,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey,
						                             MvcUrlExtension.GetCultureTwoDigit()
					                             }
				                             },
										 new RouteValueDictionary());
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   object routeValues,
												   string language)
		{
			return htmlHelper.ActionLink(linkText, actionName, null,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey,
						                             language
					                             }
				                             },
										 new RouteValueDictionary());
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   string controllerName)
		{
			return htmlHelper.ActionLink(linkText, actionName, controllerName,
										 new RouteValueDictionary
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey,
						                             MvcUrlExtension.GetCultureTwoDigit()
					                             }
				                             },
										 new RouteValueDictionary());
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   string controllerName,
												   string language)
		{
			return htmlHelper.ActionLink(linkText, actionName, controllerName,
										 new RouteValueDictionary { { MvcUrlExtension.LanguageRouteKey, language } },
										 new RouteValueDictionary());
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   RouteValueDictionary routeValues)
		{
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = MvcUrlExtension.GetCultureTwoDigit();
			return htmlHelper.ActionLink(linkText, actionName, null, routeValues, new RouteValueDictionary());
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   RouteValueDictionary routeValues,
												   string language)
		{
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = language;
			return htmlHelper.ActionLink(linkText, actionName, null, routeValues, new RouteValueDictionary());
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   object routeValues, object htmlAttributes)
		{
			return htmlHelper.ActionLink(linkText, actionName, null,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey,
						                             MvcUrlExtension.GetCultureTwoDigit()
					                             }
				                             },
										 HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   object routeValues, object htmlAttributes,
												   string language)
		{
			return htmlHelper.ActionLink(linkText, actionName, null,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey, language
					                             }
				                             },
										 HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   RouteValueDictionary routeValues,
												   IDictionary<string, object> htmlAttributes)
		{
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = MvcUrlExtension.GetCultureTwoDigit();
			return htmlHelper.ActionLink(linkText, actionName, null, routeValues, htmlAttributes);
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   RouteValueDictionary routeValues,
												   IDictionary<string, object> htmlAttributes,
												   string language)
		{
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = language;
			return htmlHelper.ActionLink(linkText, actionName, null, routeValues, htmlAttributes);
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   string controllerName, object routeValues, object htmlAttributes)
		{
			return htmlHelper.ActionLink(linkText, actionName, controllerName,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey,
						                             MvcUrlExtension.GetCultureTwoDigit()
					                             }
				                             },
										 HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   string controllerName, object routeValues, object htmlAttributes,
												   string language)
		{
			return htmlHelper.ActionLink(linkText, actionName, controllerName,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey, language
					                             }
				                             },
										 HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   string controllerName, RouteValueDictionary routeValues,
												   IDictionary<string, object> htmlAttributes,
												   string language)
		{
			if (string.IsNullOrEmpty(linkText))
			{
				throw new ArgumentException("linkText");
			}
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = language;

			return
				MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection,
															 linkText, null, actionName, controllerName, routeValues, htmlAttributes));
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   string controllerName, string protocol, string hostName, string fragment,
												   object routeValues, object htmlAttributes)
		{
			return htmlHelper.ActionLink(linkText, actionName, controllerName, protocol, hostName, fragment,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey,
						                             MvcUrlExtension.GetCultureTwoDigit()
					                             }
				                             },
										 HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   string controllerName, string protocol, string hostName, string fragment,
												   object routeValues, object htmlAttributes,
												   string language)
		{
			return htmlHelper.ActionLink(linkText, actionName, controllerName, protocol, hostName, fragment,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey,
						                             language
					                             }
				                             },
										 HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   string controllerName, string protocol, string hostName, string fragment,
												   RouteValueDictionary routeValues,
												   IDictionary<string, object> htmlAttributes)
		{
			if (string.IsNullOrEmpty(linkText))
			{
				throw new ArgumentException("linkText");
			}
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = MvcUrlExtension.GetCultureTwoDigit();
			return
				MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection,
															 linkText, null, actionName, controllerName, protocol, hostName,
															 fragment, routeValues, htmlAttributes));
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		public static MvcHtmlString ActionLinkLang(this HtmlHelper htmlHelper, string linkText, string actionName,
												   string controllerName, string protocol, string hostName, string fragment,
												   RouteValueDictionary routeValues,
												   IDictionary<string, object> htmlAttributes,
												   string language)
		{
			if (string.IsNullOrEmpty(linkText))
			{
				throw new ArgumentException("linkText");
			}
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = language;
			return
				MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection,
															 linkText, null, actionName, controllerName, protocol, hostName,
															 fragment, routeValues, htmlAttributes));
		}






		private static string GenerateUrlLang(
			UrlHelper helper,
			string routeName,
			string actionName,
			string controllerName,
			RouteValueDictionary routeValues)
		{
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = MvcUrlExtension.GetCultureTwoDigit();
			return UrlHelper.GenerateUrl(routeName, actionName, controllerName, routeValues, helper.RouteCollection,
										 helper.RequestContext, true);
		}

		private static string GenerateUrlLang(
			UrlHelper helper,
			string routeName,
			string actionName,
			string controllerName,
			RouteValueDictionary routeValues,
			string language)
		{
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = language;
			return UrlHelper.GenerateUrl(routeName, actionName, controllerName, routeValues, helper.RouteCollection,
										 helper.RequestContext, true);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName)
		{
			return GenerateUrlLang(helper, null, actionName, null, null);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name and route values.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, object routeValues)
		{
			return GenerateUrlLang(helper, null, actionName, null, new RouteValueDictionary(routeValues));
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name and route values.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, object routeValues, string language)
		{
			return GenerateUrlLang(helper, null, actionName, null, new RouteValueDictionary(routeValues), language);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name and controller name.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, string controllerName)
		{
			return GenerateUrlLang(helper, null, actionName, controllerName, null);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name and controller name.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, string controllerName, string language)
		{
			return GenerateUrlLang(helper, null, actionName, controllerName, null, language);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method for the specified action name and route values.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, RouteValueDictionary routeValues)
		{
			return GenerateUrlLang(helper, null, actionName, null, routeValues);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method for the specified action name and route values.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, RouteValueDictionary routeValues,
										string language)
		{
			return GenerateUrlLang(helper, null, actionName, null, routeValues, language);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name, controller name, and route values.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, string controllerName, object routeValues)
		{
			return GenerateUrlLang(helper, null, actionName, controllerName, new RouteValueDictionary(routeValues));
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name, controller name, and route values.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, string controllerName,
										RouteValueDictionary routeValues)
		{
			return GenerateUrlLang(helper, null, actionName, controllerName, routeValues);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name, controller name, and route values.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, string controllerName,
										RouteValueDictionary routeValues, string language)
		{
			return GenerateUrlLang(helper, null, actionName, controllerName, routeValues, language);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name, controller name, route values, and protocol to use.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, string controllerName, object routeValues,
										string protocol)
		{
			return UrlHelper.GenerateUrl(null, actionName, controllerName, protocol, null, null,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey,
						                             MvcUrlExtension.GetCultureTwoDigit()
					                             }
				                             }, helper.RouteCollection,
										 helper.RequestContext, true);
		}

		/// <summary>
		/// Generates a fully qualified URL to an action method by using the specified action name, controller name, route values, and protocol to use.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, string controllerName, object routeValues,
										string protocol,
										string language)
		{
			return UrlHelper.GenerateUrl(null, actionName, controllerName, protocol, null, null,
										 new RouteValueDictionary(routeValues)
				                             {
					                             {
						                             MvcUrlExtension.LanguageRouteKey, language
					                             }
				                             }, helper.RouteCollection,
										 helper.RequestContext, true);
		}

		/// <summary>
		/// Generates a fully qualified URL for an action method by using the specified action name, controller name, route values, protocol to use, and host name.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, string controllerName,
										RouteValueDictionary routeValues, string protocol, string hostName)
		{
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = MvcUrlExtension.GetCultureTwoDigit();
			return UrlHelper.GenerateUrl(null, actionName, controllerName, protocol, hostName, null, routeValues,
										 helper.RouteCollection, helper.RequestContext, true);
		}

		/// <summary>
		/// Generates a fully qualified URL for an action method by using the specified action name, controller name, route values, protocol to use, and host name.
		/// </summary>
		public static string ActionLang(this UrlHelper helper, string actionName, string controllerName,
										RouteValueDictionary routeValues, string protocol, string hostName,
										string language)
		{
			if (routeValues == null)
				routeValues = new RouteValueDictionary();
			routeValues[MvcUrlExtension.LanguageRouteKey] = language;
			return UrlHelper.GenerateUrl(null, actionName, controllerName, protocol, hostName, null, routeValues,
										 helper.RouteCollection, helper.RequestContext, true);
		}

	}
}