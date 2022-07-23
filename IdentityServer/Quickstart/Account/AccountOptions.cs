// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace IdentityServer4.Quickstart.UI
{
    public class AccountOptions
    {
        // specify the Windows authentication scheme being used
        public static readonly string WindowsAuthenticationSchemeName = Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme;
#pragma warning disable SA1401 // Fields should be private
        public static bool AllowLocalLogin = true;
#pragma warning restore SA1401 // Fields should be private
#pragma warning disable SA1401 // Fields should be private
        public static bool AllowRememberLogin = true;
#pragma warning restore SA1401 // Fields should be private
#pragma warning disable SA1401 // Fields should be private
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);
#pragma warning restore SA1401 // Fields should be private

#pragma warning disable SA1401 // Fields should be private
        public static bool ShowLogoutPrompt = true;
#pragma warning restore SA1401 // Fields should be private
#pragma warning disable SA1401 // Fields should be private
        public static bool AutomaticRedirectAfterSignOut = false;

        // if user uses windows auth, should we load the groups from windows
#pragma warning disable SA1401 // Fields should be private
        public static bool IncludeWindowsGroups = false;
#pragma warning restore SA1401 // Fields should be private

        // TODO
#pragma warning disable SA1401 // Fields should be private
        public static string InvalidCredentialsErrorMessage = "Invalid username or password";
#pragma warning restore SA1401 // Fields should be private
    }
}
