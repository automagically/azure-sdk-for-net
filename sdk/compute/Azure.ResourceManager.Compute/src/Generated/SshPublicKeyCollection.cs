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

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A class representing a collection of <see cref="SshPublicKeyResource" /> and their operations.
    /// Each <see cref="SshPublicKeyResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="SshPublicKeyCollection" /> instance call the GetSshPublicKeys method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class SshPublicKeyCollection : ArmCollection, IEnumerable<SshPublicKeyResource>, IAsyncEnumerable<SshPublicKeyResource>
    {
        private readonly ClientDiagnostics _sshPublicKeyClientDiagnostics;
        private readonly SshPublicKeysRestOperations _sshPublicKeyRestClient;

        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyCollection"/> class for mocking. </summary>
        protected SshPublicKeyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SshPublicKeyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sshPublicKeyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", SshPublicKeyResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SshPublicKeyResource.ResourceType, out string sshPublicKeyApiVersion);
            _sshPublicKeyRestClient = new SshPublicKeysRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sshPublicKeyApiVersion);
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
        /// Creates a new SSH public key resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="data"> Parameters supplied to create the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SshPublicKeyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string sshPublicKeyName, SshPublicKeyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ComputeArmOperation<SshPublicKeyResource>(Response.FromValue(new SshPublicKeyResource(Client, response), response.GetRawResponse()));
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
        /// Creates a new SSH public key resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="data"> Parameters supplied to create the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SshPublicKeyResource> CreateOrUpdate(WaitUntil waitUntil, string sshPublicKeyName, SshPublicKeyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _sshPublicKeyRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, data, cancellationToken);
                var operation = new ComputeArmOperation<SshPublicKeyResource>(Response.FromValue(new SshPublicKeyResource(Client, response), response.GetRawResponse()));
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
        /// Retrieves information about an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual async Task<Response<SshPublicKeyResource>> GetAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.Get");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SshPublicKeyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual Response<SshPublicKeyResource> Get(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.Get");
            scope.Start();
            try
            {
                var response = _sshPublicKeyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SshPublicKeyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all of the SSH public keys in the specified resource group. Use the nextLink property in the response to get the next page of SSH public keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys
        /// Operation Id: SshPublicKeys_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SshPublicKeyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SshPublicKeyResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SshPublicKeyResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sshPublicKeyRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKeyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SshPublicKeyResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sshPublicKeyRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKeyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all of the SSH public keys in the specified resource group. Use the nextLink property in the response to get the next page of SSH public keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys
        /// Operation Id: SshPublicKeys_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SshPublicKeyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SshPublicKeyResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SshPublicKeyResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sshPublicKeyRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKeyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SshPublicKeyResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sshPublicKeyRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SshPublicKeyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(sshPublicKeyName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual Response<bool> Exists(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(sshPublicKeyName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual async Task<Response<SshPublicKeyResource>> GetIfExistsAsync(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _sshPublicKeyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SshPublicKeyResource>(null, response.GetRawResponse());
                return Response.FromValue(new SshPublicKeyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public virtual Response<SshPublicKeyResource> GetIfExists(string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sshPublicKeyName, nameof(sshPublicKeyName));

            using var scope = _sshPublicKeyClientDiagnostics.CreateScope("SshPublicKeyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _sshPublicKeyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, sshPublicKeyName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SshPublicKeyResource>(null, response.GetRawResponse());
                return Response.FromValue(new SshPublicKeyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SshPublicKeyResource> IEnumerable<SshPublicKeyResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SshPublicKeyResource> IAsyncEnumerable<SshPublicKeyResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
