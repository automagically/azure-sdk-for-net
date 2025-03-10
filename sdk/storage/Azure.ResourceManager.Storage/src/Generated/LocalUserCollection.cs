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

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="LocalUserResource" /> and their operations.
    /// Each <see cref="LocalUserResource" /> in the collection will belong to the same instance of <see cref="StorageAccountResource" />.
    /// To get a <see cref="LocalUserCollection" /> instance call the GetLocalUsers method from an instance of <see cref="StorageAccountResource" />.
    /// </summary>
    public partial class LocalUserCollection : ArmCollection, IEnumerable<LocalUserResource>, IAsyncEnumerable<LocalUserResource>
    {
        private readonly ClientDiagnostics _localUserClientDiagnostics;
        private readonly LocalUsersRestOperations _localUserRestClient;

        /// <summary> Initializes a new instance of the <see cref="LocalUserCollection"/> class for mocking. </summary>
        protected LocalUserCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="LocalUserCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal LocalUserCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _localUserClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", LocalUserResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(LocalUserResource.ResourceType, out string localUserApiVersion);
            _localUserRestClient = new LocalUsersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, localUserApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != StorageAccountResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, StorageAccountResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update the properties of a local user associated with the storage account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}
        /// Operation Id: LocalUsers_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="username"> The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account. </param>
        /// <param name="data"> The local user associated with a storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="username"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<LocalUserResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string username, LocalUserData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(username, nameof(username));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _localUserRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, username, data, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<LocalUserResource>(Response.FromValue(new LocalUserResource(Client, response), response.GetRawResponse()));
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
        /// Create or update the properties of a local user associated with the storage account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}
        /// Operation Id: LocalUsers_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="username"> The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account. </param>
        /// <param name="data"> The local user associated with a storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="username"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<LocalUserResource> CreateOrUpdate(WaitUntil waitUntil, string username, LocalUserData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(username, nameof(username));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _localUserRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, username, data, cancellationToken);
                var operation = new StorageArmOperation<LocalUserResource>(Response.FromValue(new LocalUserResource(Client, response), response.GetRawResponse()));
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
        /// Get the local user of the storage account by username.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}
        /// Operation Id: LocalUsers_Get
        /// </summary>
        /// <param name="username"> The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="username"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> is null. </exception>
        public virtual async Task<Response<LocalUserResource>> GetAsync(string username, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(username, nameof(username));

            using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.Get");
            scope.Start();
            try
            {
                var response = await _localUserRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, username, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LocalUserResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the local user of the storage account by username.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}
        /// Operation Id: LocalUsers_Get
        /// </summary>
        /// <param name="username"> The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="username"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> is null. </exception>
        public virtual Response<LocalUserResource> Get(string username, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(username, nameof(username));

            using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.Get");
            scope.Start();
            try
            {
                var response = _localUserRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, username, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new LocalUserResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the local users associated with the storage account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers
        /// Operation Id: LocalUsers_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="LocalUserResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<LocalUserResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<LocalUserResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _localUserRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new LocalUserResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// List the local users associated with the storage account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers
        /// Operation Id: LocalUsers_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="LocalUserResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<LocalUserResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<LocalUserResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _localUserRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new LocalUserResource(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}
        /// Operation Id: LocalUsers_Get
        /// </summary>
        /// <param name="username"> The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="username"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string username, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(username, nameof(username));

            using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(username, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}
        /// Operation Id: LocalUsers_Get
        /// </summary>
        /// <param name="username"> The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="username"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> is null. </exception>
        public virtual Response<bool> Exists(string username, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(username, nameof(username));

            using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(username, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}
        /// Operation Id: LocalUsers_Get
        /// </summary>
        /// <param name="username"> The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="username"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> is null. </exception>
        public virtual async Task<Response<LocalUserResource>> GetIfExistsAsync(string username, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(username, nameof(username));

            using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _localUserRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, username, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<LocalUserResource>(null, response.GetRawResponse());
                return Response.FromValue(new LocalUserResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/localUsers/{username}
        /// Operation Id: LocalUsers_Get
        /// </summary>
        /// <param name="username"> The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="username"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="username"/> is null. </exception>
        public virtual Response<LocalUserResource> GetIfExists(string username, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(username, nameof(username));

            using var scope = _localUserClientDiagnostics.CreateScope("LocalUserCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _localUserRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, username, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<LocalUserResource>(null, response.GetRawResponse());
                return Response.FromValue(new LocalUserResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<LocalUserResource> IEnumerable<LocalUserResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<LocalUserResource> IAsyncEnumerable<LocalUserResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
