﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Tests.Helpers;

namespace Azure.ResourceManager.EventHubs.Tests
{
    public class ConsumerGroupTests : EventHubTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EventHubResource _eventHub;
        private ConsumerGroupCollection _consumerGroupCollection;
        public ConsumerGroupTests(bool isAsync) : base(isAsync)
        {
        }
        [SetUp]
        public async Task CreateNamespaceAndGetEventhubCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string namespaceName = await CreateValidNamespaceName("testnamespacemgmt");
            EventHubNamespaceCollection namespaceCollection = _resourceGroup.GetEventHubNamespaces();
            EventHubNamespaceResource eHNamespace = (await namespaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, new EventHubNamespaceData(DefaultLocation))).Value;
            EventHubCollection eventhubCollection = eHNamespace.GetEventHubs();
            string eventhubName = Recording.GenerateAssetName("eventhub");
            _eventHub = (await eventhubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventhubName, new EventHubData())).Value;
            _consumerGroupCollection = _eventHub.GetConsumerGroups();
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
        public async Task CreateDeleteConsumerGroup()
        {
            //create consumer group
            string consumerGroupName = Recording.GenerateAssetName("testconsumergroup");
            ConsumerGroupResource consumerGroup = (await _consumerGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, consumerGroupName, new ConsumerGroupData())).Value;
            Assert.NotNull(consumerGroup);
            Assert.AreEqual(consumerGroup.Id.Name, consumerGroupName);

            //validate if created successfully
            consumerGroup = await _consumerGroupCollection.GetIfExistsAsync(consumerGroupName);
            Assert.NotNull(consumerGroup);
            Assert.IsTrue(await _consumerGroupCollection.ExistsAsync(consumerGroupName));

            //delete consumer group
            await consumerGroup.DeleteAsync(WaitUntil.Completed);

            //validate
            consumerGroup = await _consumerGroupCollection.GetIfExistsAsync(consumerGroupName);
            Assert.Null(consumerGroup);
            Assert.IsFalse(await _consumerGroupCollection.ExistsAsync(consumerGroupName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllConsumerGroups()
        {
            //create ten consumer groups
            for (int i = 0; i < 10; i++)
            {
                string consumerGroupName = Recording.GenerateAssetName("testconsumergroup" + i.ToString());
                _ = (await _consumerGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, consumerGroupName, new ConsumerGroupData())).Value;
            }

            //validate
            List<ConsumerGroupResource> list = await _consumerGroupCollection.GetAllAsync().ToEnumerableAsync();
            // the count should be 11 because there is a default consumergroup
            Assert.AreEqual(list.Count, 11);
            list = await _consumerGroupCollection.GetAllAsync(5, 5).ToEnumerableAsync();
            Assert.AreEqual(list.Count, 6);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateConsumerGroup()
        {
            //create consumer group
            string consumerGroupName = Recording.GenerateAssetName("testconsumergroup");
            ConsumerGroupResource consumerGroup = (await _consumerGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, consumerGroupName, new ConsumerGroupData())).Value;
            Assert.NotNull(consumerGroup);
            Assert.AreEqual(consumerGroup.Id.Name, consumerGroupName);

            //update consumer group and validate
            consumerGroup.Data.UserMetadata = "update the user meta data";
            consumerGroup = (await _consumerGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, consumerGroupName, consumerGroup.Data)).Value;
            Assert.AreEqual(consumerGroup.Data.UserMetadata, "update the user meta data");
        }
    }
}
