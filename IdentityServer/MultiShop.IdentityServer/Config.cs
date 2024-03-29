﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
         new ApiResource("ResourceCatalog")
         {
             Scopes={"CatalogFullPermission","CatalogReadPermission"}
         },
         new ApiResource("ResourceDiscount")
         {
             Scopes={"DiscountFullPermission","DiscountReadPermission"}
         },
         new ApiResource("ResourceOrder")
         {
             Scopes={"OrderFullPermission","OrderReadPermission"}
         },
         new ApiResource("ResourceCargo")
         {
             Scopes = { "CargoFullPermission" }
         },
         new ApiResource("ResourceBasket")
         {
             Scopes = { "BasketFullPermission" }
         },
         new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CatalogFullPermission", "Catalog Full Permission"),
                new ApiScope("CatalogReadPermission", "Catalog Read Permission"),
                new ApiScope("DiscountFullPermission", "Discount Full Permission"),
                new ApiScope("DiscountReadPermission", "Discount Read Permission"),
                new ApiScope("OrderFullPermission", "Order Full Permission"),
                new ApiScope("OrderReadPermission", "Order Read Permission"),
                new ApiScope("CargoFullPermission", "Cargo Full Permission"),
                new ApiScope("BasketFullPermission", "Basket Full Permission"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };
        public static IEnumerable<Client> Clients => new Client[] {
        new Client
        {
            ClientId="MultiShopVisitorId",
            ClientName="Multi Shop Visitor User",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={"CatalogReadPermission","DiscountReadPermission","OrderReadPermission"}
        },
        new Client
        {
            ClientId="MultiShopManagerId",
            ClientName="Multi Shop Manager User",
            AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={ "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", "BasketFullPermission" }
        },
        new Client
        {
            ClientId="MultiShopAdminId",
            ClientName="Multi Shop Admin User",
            AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
            ClientSecrets={new Secret("multishopsecret".Sha256())},
            AllowedScopes={"CatalogFullPermission","DiscountFullPermission","OrderFullPermission","CargoFullPermission","BasketFullPermission",

                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email
            },
            AccessTokenLifetime=3600
        },


        };
    }
}