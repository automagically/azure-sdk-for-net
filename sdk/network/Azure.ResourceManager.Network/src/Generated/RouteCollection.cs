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

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing a collection of <see cref="RouteResource" /> and their operations.
    /// Each <see cref="RouteResource" /> in the collection will belong to the same instance of <see cref="RouteTableResource" />.
    /// To get a <see cref="RouteCollection" /> instance call the GetRoutes method from an instance of <see cref="RouteTableResource" />.
    /// </summary>
    public partial class RouteCollection : ArmCollection, IEnumerable<RouteResource>, IAsyncEnumerable<RouteResource>
    {
        private readonly ClientDiagnostics _routeClientDiagnostics;
        private readonly RoutesRestOperations _routeRestClient;

        /// <summary> Initializes a new instance of the <see cref="RouteCollection"/> class for mocking. </summary>
        protected RouteCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="RouteCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal RouteCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _routeClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", RouteResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(RouteResource.ResourceType, out string routeApiVersion);
            _routeRestClient = new RoutesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, routeApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != RouteTableResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, RouteTableResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a route in the specified route table.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes/{routeName}
        /// Operation Id: Routes_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="routeName"> The name of the route. </param>
        /// <param name="data"> Parameters supplied to the create or update route operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<RouteResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string routeName, RouteData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(routeName, nameof(routeName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _routeRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, routeName, data, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<RouteResource>(new RouteOperationSource(Client), _routeClientDiagnostics, Pipeline, _routeRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, routeName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates or updates a route in the specified route table.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes/{routeName}
        /// Operation Id: Routes_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="routeName"> The name of the route. </param>
        /// <param name="data"> Parameters supplied to the create or update route operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<RouteResource> CreateOrUpdate(WaitUntil waitUntil, string routeName, RouteData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(routeName, nameof(routeName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _routeRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, routeName, data, cancellationToken);
                var operation = new NetworkArmOperation<RouteResource>(new RouteOperationSource(Client), _routeClientDiagnostics, Pipeline, _routeRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, routeName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets the specified route from a route table.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes/{routeName}
        /// Operation Id: Routes_Get
        /// </summary>
        /// <param name="routeName"> The name of the route. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeName"/> is null. </exception>
        public virtual async Task<Response<RouteResource>> GetAsync(string routeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(routeName, nameof(routeName));

            using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.Get");
            scope.Start();
            try
            {
                var response = await _routeRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, routeName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RouteResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified route from a route table.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes/{routeName}
        /// Operation Id: Routes_Get
        /// </summary>
        /// <param name="routeName"> The name of the route. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeName"/> is null. </exception>
        public virtual Response<RouteResource> Get(string routeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(routeName, nameof(routeName));

            using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.Get");
            scope.Start();
            try
            {
                var response = _routeRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, routeName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RouteResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all routes in a route table.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes
        /// Operation Id: Routes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RouteResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RouteResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<RouteResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _routeRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RouteResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<RouteResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _routeRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new RouteResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all routes in a route table.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes
        /// Operation Id: Routes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RouteResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RouteResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<RouteResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _routeRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RouteResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<RouteResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _routeRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new RouteResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes/{routeName}
        /// Operation Id: Routes_Get
        /// </summary>
        /// <param name="routeName"> The name of the route. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string routeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(routeName, nameof(routeName));

            using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(routeName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes/{routeName}
        /// Operation Id: Routes_Get
        /// </summary>
        /// <param name="routeName"> The name of the route. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeName"/> is null. </exception>
        public virtual Response<bool> Exists(string routeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(routeName, nameof(routeName));

            using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(routeName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes/{routeName}
        /// Operation Id: Routes_Get
        /// </summary>
        /// <param name="routeName"> The name of the route. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeName"/> is null. </exception>
        public virtual async Task<Response<RouteResource>> GetIfExistsAsync(string routeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(routeName, nameof(routeName));

            using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _routeRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, routeName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<RouteResource>(null, response.GetRawResponse());
                return Response.FromValue(new RouteResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/routeTables/{routeTableName}/routes/{routeName}
        /// Operation Id: Routes_Get
        /// </summary>
        /// <param name="routeName"> The name of the route. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="routeName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="routeName"/> is null. </exception>
        public virtual Response<RouteResource> GetIfExists(string routeName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(routeName, nameof(routeName));

            using var scope = _routeClientDiagnostics.CreateScope("RouteCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _routeRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, routeName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<RouteResource>(null, response.GetRawResponse());
                return Response.FromValue(new RouteResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<RouteResource> IEnumerable<RouteResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<RouteResource> IAsyncEnumerable<RouteResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
