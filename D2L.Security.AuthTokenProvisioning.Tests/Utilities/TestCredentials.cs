﻿using System.Security.Cryptography.X509Certificates;

namespace D2L.Security.AuthTokenProvisioning.Tests.Utilities {
	internal static class TestCredentials {

		internal static class LOReSScopes {
			internal const string MANAGE = "https://api.brightspace.com/auth/lores.manage";
		}

		internal static class LMS {
			internal static readonly X509Certificate2 CERTIFICATE =
				new X509Certificate2(
					Resources.lms_dev_d2l,
					Resources.lms_dev_d2l_PASSWORD
					);

			internal const string CLIENT_ID = "lms.dev.d2l";
			internal const string CLIENT_SECRET = "lms_secret";
		}
	}
}