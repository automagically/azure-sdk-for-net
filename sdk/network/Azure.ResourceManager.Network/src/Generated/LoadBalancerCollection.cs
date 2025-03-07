// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing a collection of <see cref="LoadBalancerResource" /> and their operations.
    /// Each <see cref="LoadBalancerResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="LoadBalancerCollection" /> instance call the GetLoadBalancers method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class LoadBalancerCollection : ArmCollection, IEnumerable<LoadBalancerResource>, IAsyncEnumerable<LoadBalancerResource>
    {
        private readonly ClientDiagnostics _loadBalancerClientDiagnostics;
        private readonly LoadBalancersRestOperations _loadBalancerRestClient;

        /// <summary> Initializes a new instance of the <see cref="LoadBalancerCollection"/> class for mocking. </summary>
        protected LoadBalancerCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="LoadBalancerCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal LoadBalancerCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _loadBalancerClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", LoadBalancerResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(LoadBalancerResource.ResourceType, out string loadBalancerApiVersion);
            _loadBalancerRestClient = new LoadBalancersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, loadBalancerApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a load balancer.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}
        /// Operation Id: LoadBalancers_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="data"> Parameters supplied to the create or update load balancer operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="loadBalancerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="loadBalancerName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<LoadBalancerResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string loadBalancerName, LoadBalancerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(loadBalancerName, nameof(loadBalancerName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _loadBalancerRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, loadBalancerName, data, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<LoadBalancerResource>(new LoadBalancerOperationSource(Client), _loadBalancerClientDiagnostics, Pipeline, _loadBalancerRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, loadBalancerName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a load balancer.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}
        /// Operation Id: LoadBalancers_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="data"> Parameters supplied to the create or update load balancer operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="loadBalancerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="loadBalancerName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<LoadBalancerResource> CreateOrUpdate(WaitUntil waitUntil, string loadBalancerName, LoadBalancerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(loadBalancerName, nameof(loadBalancerName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _loadBalancerRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, loadBalancerName, data, cancellationToken);
                var operation = new NetworkArmOperation<LoadBalancerResource>(new LoadBalancerOperationSource(Client), _loadBalancerClientDiagnostics, Pipeline, _loadBalancerRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, loadBalancerName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified load balancer.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}
        /// Operation Id: LoadBalancers_Get
        /// </summary>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="loadBalancerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="loadBalancerName"/> is null. </exception>
        public virtual async Task<Response<LoadBalancerResource>> GetAsync(string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(loadBalancerName, nameof(loadBalancerName));

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.Get");
            scope.Start();
            try
            {
                var response = await _loadBalancerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, loadBalancerName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LoadBalancerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified load balancer.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}
        /// Operation Id: LoadBalancers_Get
        /// </summary>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="loadBalancerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="loadBalancerName"/> is null. </exception>
        public virtual Response<LoadBalancerResource> Get(string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(loadBalancerName, nameof(loadBalancerName));

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.Get");
            scope.Start();
            try
            {
                var response = _loadBalancerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, loadBalancerName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LoadBalancerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all the load balancers in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers
        /// Operation Id: LoadBalancers_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="LoadBalancerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<LoadBalancerResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<LoadBalancerResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _loadBalancerRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new LoadBalancerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<LoadBalancerResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _loadBalancerRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new LoadBalancerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all the load balancers in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers
        /// Operation Id: LoadBalancers_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="LoadBalancerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<LoadBalancerResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<LoadBalancerResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _loadBalancerRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new LoadBalancerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<LoadBalancerResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _loadBalancerRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new LoadBalancerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}
        /// Operation Id: LoadBalancers_Get
        /// </summary>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="loadBalancerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="loadBalancerName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(loadBalancerName, nameof(loadBalancerName));

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(loadBalancerName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}
        /// Operation Id: LoadBalancers_Get
        /// </summary>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="loadBalancerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="loadBalancerName"/> is null. </exception>
        public virtual Response<bool> Exists(string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(loadBalancerName, nameof(loadBalancerName));

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(loadBalancerName, expand: expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}
        /// Operation Id: LoadBalancers_Get
        /// </summary>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="loadBalancerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="loadBalancerName"/> is null. </exception>
        public virtual async Task<Response<LoadBalancerResource>> GetIfExistsAsync(string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(loadBalancerName, nameof(loadBalancerName));

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _loadBalancerRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, loadBalancerName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<LoadBalancerResource>(null, response.GetRawResponse());
                return Response.FromValue(new LoadBalancerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}
        /// Operation Id: LoadBalancers_Get
        /// </summary>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="loadBalancerName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="loadBalancerName"/> is null. </exception>
        public virtual Response<LoadBalancerResource> GetIfExists(string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(loadBalancerName, nameof(loadBalancerName));

            using var scope = _loadBalancerClientDiagnostics.CreateScope("LoadBalancerCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _loadBalancerRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, loadBalancerName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<LoadBalancerResource>(null, response.GetRawResponse());
                return Response.FromValue(new LoadBalancerResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<LoadBalancerResource> IEnumerable<LoadBalancerResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<LoadBalancerResource> IAsyncEnumerable<LoadBalancerResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
