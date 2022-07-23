﻿using System.Collections.Generic;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(
                    "roleidentity",
                    claimTypes: new[] { "role" })
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("figurineshop.com")
                {
                    Scopes = new List<Scope>
                    {
                        new Scope("mvc")
                    },
                },
                new ApiResource("catalog")
                {
                    UserClaims = new[] { "role" },
                    Scopes = new List<Scope>
                    {
                        new Scope("catalog.catalogbff"),
                        new Scope("catalog.admin")
                    },
                },
                new ApiResource("basket")
                {
                    UserClaims = new[] { "role" },

                    Scopes = new List<Scope>
                    {
                        new Scope("basket")
                    }
                },
                new ApiResource("comment")
                {
                    Scopes = new List<Scope>
                    {
                        new Scope("commentbff")
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            return new[]
            {
                new Client
                {
                    // AlwaysIncludeUserClaimsInIdToken = true,
                    ClientId = "mvc_pkce",
                    ClientName = "MVC PKCE Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    RedirectUris = { $"{configuration["MvcUrl"]}/signin-oidc" },
                    AllowedScopes = { "openid", "profile", "mvc", "roleidentity", "basket", "commentbff", "catalog.admin" },
                    RequirePkce = true,
                    RequireConsent = false
                },
                new Client
                {
                    ClientId = "catalog",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                },
                new Client
                {
                    ClientId = "basket",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                },
                new Client
                {
                    ClientId = "comment",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                },
                new Client
                {
                    ClientId = "catalogswaggerui",
                    ClientName = "Catalog Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{configuration["CatalogApi"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{configuration["CatalogApi"]}/swagger/" },

                    AllowedScopes =
                    {
                         "mvc",
                         "catalog.catalogbff",
                         "roleidentity"
                    }
                },
                new Client
                {
                    ClientId = "basketswaggerui",
                    ClientName = "Basket Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{configuration["BasketApi"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{configuration["BasketApi"]}/swagger/" },

                    AllowedScopes =
                    {
                         "mvc",
                         "basket.basketbff"
                    }
                },
                new Client
                {
                    ClientId = "commentswaggerui",
                    ClientName = "Comment Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{configuration["CommentApi"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{configuration["CommentApi"]}/swagger/" },

                    AllowedScopes =
                    {
                         "mvc",
                         "comment"
                    }
                }
            };
        }
    }
}