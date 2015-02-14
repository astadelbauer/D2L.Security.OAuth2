﻿namespace D2L.Security.AuthTokenProvisioning.Tests.Utilities {
	internal static class TestParameters {

		internal static ProvisioningParameters MakeValidProvisioningParams(
			string userId = null,
			string tenantId = "smTenant",
			string tenantUrl = "smTenantUrl",
			string xsrf = null
			) {

			ProvisioningParameters provisioningParams = new ProvisioningParameters(
				TestCredentials.LMS.CLIENT_ID,
				TestCredentials.LMS.CLIENT_SECRET,
				new string[] { TestCredentials.LOReSScopes.MANAGE },
				tenantId,
				tenantUrl
				);

			if( userId != null ) {
				provisioningParams.UserId = userId;
			}

			if( xsrf != null ) {
				provisioningParams.Xsrf = xsrf;
			}

			return provisioningParams;
		}
	}
}