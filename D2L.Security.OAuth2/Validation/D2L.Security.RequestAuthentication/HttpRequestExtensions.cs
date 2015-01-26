﻿using System.Web;

namespace D2L.Security.RequestAuthentication {
	internal static class HttpRequestExtensions {

		private const string XSRF_HEADER = "X-Csrf-Token";
		private const string BEARER_TOKEN_AUTHORIZATION_SCHEME = "Bearer";
		private const string BEARER_TOKEN_AUTHORIZATION_SCHEME_PREFIX =
			BEARER_TOKEN_AUTHORIZATION_SCHEME + " ";
		private const string AUTHORIZATION_HEADER_NAME = "Authorization";

		/// <summary>
		/// Return the value of a cookie
		/// </summary>
		/// <param name="request">The request</param>
		/// <param name="cookieName">The name of the cookie</param>
		/// <returns>A cookie value, or null if the specified cookie was not found</returns>
		internal static string GetCookieValue( this HttpRequest request, string cookieName ) {
			if( string.IsNullOrEmpty( cookieName ) ) {
				return null;
			}

			if( request == null ) {
				return null;
			}

			HttpCookie cookie = request.Cookies.Get( cookieName );
			if( cookie == null ) {
				return null;
			}

			return cookie.Value;
		}

		/// <summary>
		/// Returns the value of the bearer token.
		/// </summary>
		/// <param name="request">The request</param>
		/// <returns>The value of the bearer token, or null if the bearer token is not set</returns>
		internal static string GetBearerTokenValue( this HttpRequest request ) {
			if( request == null ) {
				return null;
			}

			string headerValue = request.Headers[AUTHORIZATION_HEADER_NAME];
			if( headerValue == null ) {
				return null;
			}

			if( !headerValue.StartsWith( BEARER_TOKEN_AUTHORIZATION_SCHEME_PREFIX ) ) {
				return null;
			}

			string bearerToken = headerValue.Substring( BEARER_TOKEN_AUTHORIZATION_SCHEME_PREFIX.Length );
			return bearerToken;
		}

		/// <summary>
		/// Returns the value of the Xsrf header.
		/// </summary>
		/// <param name="request">The request</param>
		/// <returns>The value of the Xsrf header, or null if the Xsrf header was not found</returns>
		internal static string GetXsrfValue( this HttpRequest request ) {
			string xsrfValue = request.Headers[XSRF_HEADER];
			return xsrfValue;
		}
	}
}
