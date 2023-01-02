﻿using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1144",
                Username = "Omkar",
                Password = "Omkar@123",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Omkar Sabale"),
                    new Claim(JwtClaimTypes.GivenName, "Omkar"),
                    new Claim(JwtClaimTypes.FamilyName, "Sabale"),
                }
            }
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };


        public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("myApi.read"),
            new ApiScope("myApi.write"),
        };

        public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("myApi")
            {
                Scopes = new List<string>{ "myApi.read","myApi.write" },
                ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
            }
        };

        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "cwm.client",
                ClientName = "Client Credentials Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "myApi.read" }
            },
        };

    }
}
