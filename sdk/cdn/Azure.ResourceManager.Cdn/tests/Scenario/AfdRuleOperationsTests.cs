﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdRuleOperationsTests : CdnManagementTestBase
    {
        public AfdRuleOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRuleName = Recording.GenerateAssetName("AFDRule");
            AfdRule afdRule = await CreateAfdRule(afdRuleSet, afdRuleName);
            await afdRule.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdRule.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRuleName = Recording.GenerateAssetName("AFDRule");
            AfdRule afdRule = await CreateAfdRule(afdRuleSet, afdRuleName);
            PatchableAfdRuleData updateOptions = new PatchableAfdRuleData
            {
                Order = 2
            };
            updateOptions.Conditions.Add(ResourceDataHelper.CreateDeliveryRuleCondition());
            updateOptions.Actions.Add(ResourceDataHelper.UpdateDeliveryRuleOperation());
            var lro = await afdRule.UpdateAsync(WaitUntil.Completed, updateOptions);
            AfdRule updatedAfdRule = lro.Value;
            ResourceDataHelper.AssertAfdRuleUpdate(updatedAfdRule, updateOptions);
        }
    }
}
