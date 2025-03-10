// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A Class representing a MsixPackage along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="MsixPackageResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetMsixPackageResource method.
    /// Otherwise you can get one from its parent resource <see cref="HostPoolResource" /> using the GetMsixPackage method.
    /// </summary>
    public partial class MsixPackageResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="MsixPackageResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName, string msixPackageFullName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/msixPackages/{msixPackageFullName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _msixPackageMSIXPackagesClientDiagnostics;
        private readonly MsixPackagesRestOperations _msixPackageMSIXPackagesRestClient;
        private readonly MsixPackageData _data;

        /// <summary> Initializes a new instance of the <see cref="MsixPackageResource"/> class for mocking. </summary>
        protected MsixPackageResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "MsixPackageResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal MsixPackageResource(ArmClient client, MsixPackageData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="MsixPackageResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MsixPackageResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _msixPackageMSIXPackagesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.DesktopVirtualization", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string msixPackageMSIXPackagesApiVersion);
            _msixPackageMSIXPackagesRestClient = new MsixPackagesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, msixPackageMSIXPackagesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DesktopVirtualization/hostPools/msixPackages";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual MsixPackageData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a msixpackage.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/msixPackages/{msixPackageFullName}
        /// Operation Id: MSIXPackages_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MsixPackageResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _msixPackageMSIXPackagesClientDiagnostics.CreateScope("MsixPackageResource.Get");
            scope.Start();
            try
            {
                var response = await _msixPackageMSIXPackagesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MsixPackageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a msixpackage.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/msixPackages/{msixPackageFullName}
        /// Operation Id: MSIXPackages_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MsixPackageResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _msixPackageMSIXPackagesClientDiagnostics.CreateScope("MsixPackageResource.Get");
            scope.Start();
            try
            {
                var response = _msixPackageMSIXPackagesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MsixPackageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Remove an MSIX Package.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/msixPackages/{msixPackageFullName}
        /// Operation Id: MSIXPackages_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _msixPackageMSIXPackagesClientDiagnostics.CreateScope("MsixPackageResource.Delete");
            scope.Start();
            try
            {
                var response = await _msixPackageMSIXPackagesRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new DesktopVirtualizationArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Remove an MSIX Package.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/msixPackages/{msixPackageFullName}
        /// Operation Id: MSIXPackages_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _msixPackageMSIXPackagesClientDiagnostics.CreateScope("MsixPackageResource.Delete");
            scope.Start();
            try
            {
                var response = _msixPackageMSIXPackagesRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new DesktopVirtualizationArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update an  MSIX Package.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/msixPackages/{msixPackageFullName}
        /// Operation Id: MSIXPackages_Update
        /// </summary>
        /// <param name="data"> Object containing MSIX Package definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<MsixPackageResource>> UpdateAsync(PatchableMsixPackageData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _msixPackageMSIXPackagesClientDiagnostics.CreateScope("MsixPackageResource.Update");
            scope.Start();
            try
            {
                var response = await _msixPackageMSIXPackagesRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new MsixPackageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update an  MSIX Package.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/msixPackages/{msixPackageFullName}
        /// Operation Id: MSIXPackages_Update
        /// </summary>
        /// <param name="data"> Object containing MSIX Package definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<MsixPackageResource> Update(PatchableMsixPackageData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _msixPackageMSIXPackagesClientDiagnostics.CreateScope("MsixPackageResource.Update");
            scope.Start();
            try
            {
                var response = _msixPackageMSIXPackagesRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken);
                return Response.FromValue(new MsixPackageResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
