// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityServer4.Quickstart.UI
{
    public class ConsentOptions
    {
#pragma warning restore SA1401 // Fields should be private

        public static readonly string MustChooseOneErrorMessage = "You must pick at least one permission";
        public static readonly string InvalidSelectionErrorMessage = "Invalid selection";
#pragma warning disable SA1401 // Fields should be private
        public static bool EnableOfflineAccess = true;
#pragma warning restore SA1401 // Fields should be private
#pragma warning disable SA1401 // Fields should be private
        public static string OfflineAccessDisplayName = "Offline Access";
#pragma warning restore SA1401 // Fields should be private
#pragma warning disable SA1401 // Fields should be private
        public static string OfflineAccessDescription = "Access to your applications and resources, even when you are offline";
    }
}
