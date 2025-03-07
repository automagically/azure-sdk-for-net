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
    /// A class representing a collection of <see cref="VirtualMachineExtensionImageResource" /> and their operations.
    /// Each <see cref="VirtualMachineExtensionImageResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="VirtualMachineExtensionImageCollection" /> instance call the GetVirtualMachineExtensionImages method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class VirtualMachineExtensionImageCollection : ArmCollection, IEnumerable<VirtualMachineExtensionImageResource>, IAsyncEnumerable<VirtualMachineExtensionImageResource>
    {
        private readonly ClientDiagnostics _virtualMachineExtensionImageClientDiagnostics;
        private readonly VirtualMachineExtensionImagesRestOperations _virtualMachineExtensionImageRestClient;
        private readonly string _location;
        private readonly string _publisherName;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineExtensionImageCollection"/> class for mocking. </summary>
        protected VirtualMachineExtensionImageCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineExtensionImageCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="publisherName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        internal VirtualMachineExtensionImageCollection(ArmClient client, ResourceIdentifier id, string location, string publisherName) : base(client, id)
        {
            _location = location;
            _publisherName = publisherName;
            _virtualMachineExtensionImageClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", VirtualMachineExtensionImageResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(VirtualMachineExtensionImageResource.ResourceType, out string virtualMachineExtensionImageApiVersion);
            _virtualMachineExtensionImageRestClient = new VirtualMachineExtensionImagesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualMachineExtensionImageApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubscriptionResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubscriptionResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}
        /// Operation Id: VirtualMachineExtensionImages_Get
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineExtensionImageResource>> GetAsync(string type, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(type, nameof(type));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineExtensionImageRestClient.GetAsync(Id.SubscriptionId, _location, _publisherName, type, version, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineExtensionImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}
        /// Operation Id: VirtualMachineExtensionImages_Get
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        public virtual Response<VirtualMachineExtensionImageResource> Get(string type, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(type, nameof(type));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineExtensionImageRestClient.Get(Id.SubscriptionId, _location, _publisherName, type, version, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineExtensionImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of virtual machine extension image types.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types
        /// Operation Id: VirtualMachineExtensionImages_ListTypes
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineExtensionImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineExtensionImageResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineExtensionImageResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineExtensionImageRestClient.ListTypesAsync(Id.SubscriptionId, _location, _publisherName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Select(value => new VirtualMachineExtensionImageResource(Client, value)), null, response.GetRawResponse());
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
        /// Gets a list of virtual machine extension image types.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types
        /// Operation Id: VirtualMachineExtensionImages_ListTypes
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineExtensionImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineExtensionImageResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VirtualMachineExtensionImageResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineExtensionImageRestClient.ListTypes(Id.SubscriptionId, _location, _publisherName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Select(value => new VirtualMachineExtensionImageResource(Client, value)), null, response.GetRawResponse());
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
        /// Gets a list of virtual machine extension image versions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions
        /// Operation Id: VirtualMachineExtensionImages_ListVersions
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> is null. </exception>
        /// <returns> An async collection of <see cref="VirtualMachineExtensionImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineExtensionImageResource> GetAllAsync(string type, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(type, nameof(type));

            async Task<Page<VirtualMachineExtensionImageResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineExtensionImageRestClient.ListVersionsAsync(Id.SubscriptionId, _location, _publisherName, type, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Select(value => new VirtualMachineExtensionImageResource(Client, value)), null, response.GetRawResponse());
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
        /// Gets a list of virtual machine extension image versions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions
        /// Operation Id: VirtualMachineExtensionImages_ListVersions
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> is null. </exception>
        /// <returns> A collection of <see cref="VirtualMachineExtensionImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineExtensionImageResource> GetAll(string type, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(type, nameof(type));

            Page<VirtualMachineExtensionImageResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineExtensionImageRestClient.ListVersions(Id.SubscriptionId, _location, _publisherName, type, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Select(value => new VirtualMachineExtensionImageResource(Client, value)), null, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}
        /// Operation Id: VirtualMachineExtensionImages_Get
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string type, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(type, nameof(type));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(type, version, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}
        /// Operation Id: VirtualMachineExtensionImages_Get
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        public virtual Response<bool> Exists(string type, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(type, nameof(type));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(type, version, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}
        /// Operation Id: VirtualMachineExtensionImages_Get
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        public virtual async Task<Response<VirtualMachineExtensionImageResource>> GetIfExistsAsync(string type, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(type, nameof(type));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualMachineExtensionImageRestClient.GetAsync(Id.SubscriptionId, _location, _publisherName, type, version, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineExtensionImageResource>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineExtensionImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}
        /// Operation Id: VirtualMachineExtensionImages_Get
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        public virtual Response<VirtualMachineExtensionImageResource> GetIfExists(string type, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(type, nameof(type));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using var scope = _virtualMachineExtensionImageClientDiagnostics.CreateScope("VirtualMachineExtensionImageCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachineExtensionImageRestClient.Get(Id.SubscriptionId, _location, _publisherName, type, version, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineExtensionImageResource>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineExtensionImageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualMachineExtensionImageResource> IEnumerable<VirtualMachineExtensionImageResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualMachineExtensionImageResource> IAsyncEnumerable<VirtualMachineExtensionImageResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
