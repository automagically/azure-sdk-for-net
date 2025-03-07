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

namespace Azure.ResourceManager.ConnectedVMwarevSphere
{
    /// <summary>
    /// A class representing a collection of <see cref="VirtualMachineTemplateResource" /> and their operations.
    /// Each <see cref="VirtualMachineTemplateResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="VirtualMachineTemplateCollection" /> instance call the GetVirtualMachineTemplates method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class VirtualMachineTemplateCollection : ArmCollection, IEnumerable<VirtualMachineTemplateResource>, IAsyncEnumerable<VirtualMachineTemplateResource>
    {
        private readonly ClientDiagnostics _virtualMachineTemplateClientDiagnostics;
        private readonly VirtualMachineTemplatesRestOperations _virtualMachineTemplateRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineTemplateCollection"/> class for mocking. </summary>
        protected VirtualMachineTemplateCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineTemplateCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualMachineTemplateCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineTemplateClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ConnectedVMwarevSphere", VirtualMachineTemplateResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(VirtualMachineTemplateResource.ResourceType, out string virtualMachineTemplateApiVersion);
            _virtualMachineTemplateRestClient = new VirtualMachineTemplatesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineTemplateApiVersion);
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
        /// Create Or Update virtual machine template.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="data"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual async Task<ArmOperation<VirtualMachineTemplateResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string virtualMachineTemplateName, VirtualMachineTemplateData data = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineTemplateRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ConnectedVMwarevSphereArmOperation<VirtualMachineTemplateResource>(new VirtualMachineTemplateOperationSource(Client), _virtualMachineTemplateClientDiagnostics, Pipeline, _virtualMachineTemplateRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Create Or Update virtual machine template.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Create
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="data"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual ArmOperation<VirtualMachineTemplateResource> CreateOrUpdate(WaitUntil waitUntil, string virtualMachineTemplateName, VirtualMachineTemplateData data = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineTemplateRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, data, cancellationToken);
                var operation = new ConnectedVMwarevSphereArmOperation<VirtualMachineTemplateResource>(new VirtualMachineTemplateOperationSource(Client), _virtualMachineTemplateClientDiagnostics, Pipeline, _virtualMachineTemplateRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Implements virtual machine template GET method.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineTemplateResource>> GetAsync(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineTemplateRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineTemplateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Implements virtual machine template GET method.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual Response<VirtualMachineTemplateResource> Get(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineTemplateRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineTemplateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List of virtualMachineTemplates in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates
        /// Operation Id: VirtualMachineTemplates_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineTemplateResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineTemplateResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineTemplateResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineTemplateRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineTemplateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualMachineTemplateResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineTemplateRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineTemplateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List of virtualMachineTemplates in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates
        /// Operation Id: VirtualMachineTemplates_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineTemplateResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineTemplateResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VirtualMachineTemplateResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineTemplateRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineTemplateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualMachineTemplateResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineTemplateRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineTemplateResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(virtualMachineTemplateName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual Response<bool> Exists(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(virtualMachineTemplateName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineTemplateResource>> GetIfExistsAsync(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualMachineTemplateRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineTemplateResource>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineTemplateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual Response<VirtualMachineTemplateResource> GetIfExists(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachineTemplateRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineTemplateResource>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineTemplateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualMachineTemplateResource> IEnumerable<VirtualMachineTemplateResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualMachineTemplateResource> IAsyncEnumerable<VirtualMachineTemplateResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
