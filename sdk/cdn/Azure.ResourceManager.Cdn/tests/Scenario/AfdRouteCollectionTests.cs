﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdRouteCollectionTests : CdnManagementTestBase
    {
        public AfdRouteCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            _ = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRouteName = Recording.GenerateAssetName("AFDRoute");
            AfdRoute afdRoute = await CreateAfdRoute(afdEndpointInstance, afdRouteName, afdOriginGroupInstance, afdRuleSet);
            Assert.AreEqual(afdRouteName, afdRoute.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdEndpointInstance.GetAfdRoutes().CreateOrUpdateAsync(WaitUntil.Completed, null, afdRoute.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdEndpointInstance.GetAfdRoutes().CreateOrUpdateAsync(WaitUntil.Completed, afdRouteName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            _ = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRouteName = Recording.GenerateAssetName("AFDRoute");
            _ = await CreateAfdRoute(afdEndpointInstance, afdRouteName, afdOriginGroupInstance, afdRuleSet);
            int count = 0;
            await foreach (var tempRoute in afdEndpointInstance.GetAfdRoutes().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AfdOrigin afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRouteName = Recording.GenerateAssetName("AFDRoute");
            AfdRoute afdRoute = await CreateAfdRoute(afdEndpointInstance, afdRouteName, afdOriginGroupInstance, afdRuleSet);
            AfdRoute getAfdRoute = await afdEndpointInstance.GetAfdRoutes().GetAsync(afdRouteName);
            ResourceDataHelper.AssertValidAfdRoute(afdRoute, getAfdRoute);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdEndpointInstance.GetAfdRoutes().GetAsync(null));
        }
    }
}
