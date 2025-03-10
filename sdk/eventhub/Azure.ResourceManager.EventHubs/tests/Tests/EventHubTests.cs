﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.EventHubs.Tests.Helpers;
using KeyType = Azure.ResourceManager.EventHubs.Models.KeyType;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class EventhubTests : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventHubCollection _eventHubCollection;
        public EventhubTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateNamespaceAndGetEventhubCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            EventHubNamespaceResource eventHubNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            _eventHubCollection = eventHubNamespace.GetEventHubs();
        }

        [TearDown]
        public async Task ClearNamespaces()
        {
            //remove all namespaces under current resource group
            if (_resourceGroup != null)
            {
                EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
                List<EventHubNamespaceResource> namespaceList = await namespaceCollection.GetAllAsync().ToEnumerableAsync();
                foreach (EventHubNamespaceResource eventHubNamespace in namespaceList)
                {
                    await eventHubNamespace.DeleteAsync(WaitUntil.Completed);
                }
                _resourceGroup = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteEventHub()
        {
            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            EventHubResource eventHub = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName, new EventHubData())).Value;
            Assert.NotNull(eventHub);
            Assert.AreEqual(eventHub.Id.Name, eventhubName);

            //validate if created successfully
            eventHub = await _eventHubCollection.GetIfExistsAsync(eventhubName);
            Assert.NotNull(eventHub);
            Assert.IsTrue(await _eventHubCollection.ExistsAsync(eventhubName));

            //delete eventhub
            await eventHub.DeleteAsync(WaitUntil.Completed);

            //validate
            eventHub = await _eventHubCollection.GetIfExistsAsync(eventhubName);
            Assert.Null(eventHub);
            Assert.IsFalse(await _eventHubCollection.ExistsAsync(eventhubName));
        }

        [Test]
        [RecordedTest]
        [Ignore("exceed 8s")]
        public async Task CreateEventhubWithParameter()
        {
            //prepare a storage account
            string accountName = Recording.GenerateAssetName("storage");
            StorageSku sku = new StorageSku("Standard_LRS");
            var storageAccountCreateParameters = new StorageAccountCreateParameters(sku, StorageKind.StorageV2, "eastus2")
            {
                AccessTier = AccessTier.Hot
            };
            StorageAccountResource account = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, storageAccountCreateParameters)).Value;
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }

            //create eventhub
            string eventHubName = Recording.GenerateAssetName("eventhub");
            EventHubData parameter = new EventHubData()
            {
                MessageRetentionInDays = 4,
                PartitionCount = 4,
                Status = EntityStatus.Active,
                CaptureDescription = new CaptureDescription()
                {
                    Enabled = true,
                    Encoding = EncodingCaptureDescription.Avro,
                    IntervalInSeconds = 120,
                    SizeLimitInBytes = 10485763,
                    Destination = new EventHubDestination()
                    {
                        Name = "EventHubArchive.AzureBlockBlob",
                        BlobContainer = "container",
                        ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
                        StorageAccountResourceId = account.Id.ToString()
                    }
                }
            };
            EventHubResource eventHub = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventHubName, parameter)).Value;

            //validate
            Assert.NotNull(eventHub);
            Assert.AreEqual(eventHub.Id.Name, eventHubName);
            Assert.AreEqual(eventHub.Data.Status, parameter.Status);
            Assert.AreEqual(eventHub.Data.MessageRetentionInDays, parameter.MessageRetentionInDays);
            Assert.AreEqual(eventHub.Data.PartitionCount, parameter.PartitionCount);
            Assert.AreEqual(eventHub.Data.CaptureDescription.IntervalInSeconds, parameter.CaptureDescription.IntervalInSeconds);
            Assert.AreEqual(eventHub.Data.CaptureDescription.SizeLimitInBytes, parameter.CaptureDescription.SizeLimitInBytes);
            Assert.AreEqual(eventHub.Data.CaptureDescription.Destination.Name, parameter.CaptureDescription.Destination.Name);
            Assert.AreEqual(eventHub.Data.CaptureDescription.Destination.BlobContainer, parameter.CaptureDescription.Destination.BlobContainer);
            Assert.AreEqual(eventHub.Data.CaptureDescription.Destination.StorageAccountResourceId, parameter.CaptureDescription.Destination.StorageAccountResourceId);
            Assert.AreEqual(eventHub.Data.CaptureDescription.Destination.ArchiveNameFormat, parameter.CaptureDescription.Destination.ArchiveNameFormat);

            await account.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllEventhubs()
        {
            //create two eventhubs
            string eventhubName1 = Recording.GenerateAssetName("eventhub1");
            string eventhubName2 = Recording.GenerateAssetName("eventhub2");
            _ = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName1, new EventHubData())).Value;
            _ = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName2, new EventHubData())).Value;

            //validate
            int count = 0;
            EventHubResource eventHub1 = null;
            EventHubResource eventHub2 = null;
            await foreach (EventHubResource eventHub in _eventHubCollection.GetAllAsync())
            {
                count++;
                if (eventHub.Id.Name == eventhubName1)
                    eventHub1 = eventHub;
                if (eventHub.Id.Name == eventhubName2)
                    eventHub2 = eventHub;
            }
            Assert.AreEqual(count, 2);
            Assert.NotNull(eventHub1);
            Assert.NotNull(eventHub2);
        }

        [Test]
        [RecordedTest]
        public async Task EventhubCreateGetUpdateDeleteAuthorizationRule()
        {
            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            EventHubResource eventHub = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName, new EventHubData())).Value;

            //create an authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            EventHubAuthorizationRuleCollection ruleCollection = eventHub.GetEventHubAuthorizationRules();
            AuthorizationRuleData parameter = new AuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            EventHubAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get authorization rule
            authorizationRule = await ruleCollection.GetAsync(ruleName);
            Assert.AreEqual(authorizationRule.Id.Name, ruleName);
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //get all authorization rules
            List<EventHubAuthorizationRuleResource> rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();

            //validate
            Assert.True(rules.Count == 1);
            bool isContainAuthorizationRuleName = false;
            foreach (EventHubAuthorizationRuleResource rule in rules)
            {
                if (rule.Id.Name == ruleName)
                {
                    isContainAuthorizationRuleName = true;
                }
            }
            Assert.True(isContainAuthorizationRuleName);

            //update authorization rule
            parameter.Rights.Add(AccessRights.Manage);
            authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            //delete authorization rule
            await authorizationRule.DeleteAsync(WaitUntil.Completed);

            //validate if deleted
            Assert.IsFalse(await ruleCollection.ExistsAsync(ruleName));
            rules = await ruleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.True(rules.Count == 0);
        }

        [Test]
        [RecordedTest]
        public async Task EventhubAuthorizationRuleRegenerateKey()
        {
            //create eventhub
            string eventhubName = Recording.GenerateAssetName("eventhub");
            EventHubResource eventHub = (await _eventHubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName, new EventHubData())).Value;
            EventHubAuthorizationRuleCollection ruleCollection = eventHub.GetEventHubAuthorizationRules();

            //create authorization rule
            string ruleName = Recording.GenerateAssetName("authorizationrule");
            AuthorizationRuleData parameter = new AuthorizationRuleData()
            {
                Rights = { AccessRights.Listen, AccessRights.Send }
            };
            EventHubAuthorizationRuleResource authorizationRule = (await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleName, parameter)).Value;
            Assert.NotNull(authorizationRule);
            Assert.AreEqual(authorizationRule.Data.Rights.Count, parameter.Rights.Count);

            AccessKeys keys1 = await authorizationRule.GetKeysAsync();
            Assert.NotNull(keys1);
            Assert.NotNull(keys1.PrimaryConnectionString);
            Assert.NotNull(keys1.SecondaryConnectionString);

            AccessKeys keys2 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyOptions(KeyType.PrimaryKey));

            //the recordings are sanitized therefore cannot be compared
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(keys1.PrimaryKey, keys2.PrimaryKey);
                Assert.AreEqual(keys1.SecondaryKey, keys2.SecondaryKey);
            }

            AccessKeys keys3 = await authorizationRule.RegenerateKeysAsync(new RegenerateAccessKeyOptions(KeyType.SecondaryKey));
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreEqual(keys2.PrimaryKey, keys3.PrimaryKey);
                Assert.AreNotEqual(keys2.SecondaryKey, keys3.SecondaryKey);
            }
        }
    }
}
