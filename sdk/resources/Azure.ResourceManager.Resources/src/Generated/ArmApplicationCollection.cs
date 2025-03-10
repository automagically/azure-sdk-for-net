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

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing a collection of <see cref="ArmApplicationResource" /> and their operations.
    /// Each <see cref="ArmApplicationResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="ArmApplicationCollection" /> instance call the GetArmApplications method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ArmApplicationCollection : ArmCollection, IEnumerable<ArmApplicationResource>, IAsyncEnumerable<ArmApplicationResource>
    {
        private readonly ClientDiagnostics _armApplicationApplicationsClientDiagnostics;
        private readonly ApplicationsRestOperations _armApplicationApplicationsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ArmApplicationCollection"/> class for mocking. </summary>
        protected ArmApplicationCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ArmApplicationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ArmApplicationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _armApplicationApplicationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ArmApplicationResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ArmApplicationResource.ResourceType, out string armApplicationApplicationsApiVersion);
            _armApplicationApplicationsRestClient = new ApplicationsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, armApplicationApplicationsApiVersion);
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
        /// Creates a new managed application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="data"> Parameters supplied to the create or update a managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ArmApplicationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string applicationName, ArmApplicationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _armApplicationApplicationsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<ArmApplicationResource>(new ArmApplicationOperationSource(Client), _armApplicationApplicationsClientDiagnostics, Pipeline, _armApplicationApplicationsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, applicationName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Creates a new managed application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="data"> Parameters supplied to the create or update a managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ArmApplicationResource> CreateOrUpdate(WaitUntil waitUntil, string applicationName, ArmApplicationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _armApplicationApplicationsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, applicationName, data, cancellationToken);
                var operation = new ResourcesArmOperation<ArmApplicationResource>(new ArmApplicationOperationSource(Client), _armApplicationApplicationsClientDiagnostics, Pipeline, _armApplicationApplicationsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, applicationName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the managed application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual async Task<Response<ArmApplicationResource>> GetAsync(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.Get");
            scope.Start();
            try
            {
                var response = await _armApplicationApplicationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ArmApplicationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the managed application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual Response<ArmApplicationResource> Get(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.Get");
            scope.Start();
            try
            {
                var response = _armApplicationApplicationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, applicationName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ArmApplicationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all the applications within a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications
        /// Operation Id: Applications_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ArmApplicationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ArmApplicationResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ArmApplicationResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _armApplicationApplicationsRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ArmApplicationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ArmApplicationResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _armApplicationApplicationsRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ArmApplicationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all the applications within a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications
        /// Operation Id: Applications_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ArmApplicationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ArmApplicationResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ArmApplicationResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _armApplicationApplicationsRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ArmApplicationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ArmApplicationResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _armApplicationApplicationsRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ArmApplicationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(applicationName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual Response<bool> Exists(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(applicationName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual async Task<Response<ArmApplicationResource>> GetIfExistsAsync(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _armApplicationApplicationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ArmApplicationResource>(null, response.GetRawResponse());
                return Response.FromValue(new ArmApplicationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the managed application. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual Response<ArmApplicationResource> GetIfExists(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _armApplicationApplicationsClientDiagnostics.CreateScope("ArmApplicationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _armApplicationApplicationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, applicationName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ArmApplicationResource>(null, response.GetRawResponse());
                return Response.FromValue(new ArmApplicationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ArmApplicationResource> IEnumerable<ArmApplicationResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ArmApplicationResource> IAsyncEnumerable<ArmApplicationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
