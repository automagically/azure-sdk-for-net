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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing a ServerDnsAlias along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ServerDnsAliasResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetServerDnsAliasResource method.
    /// Otherwise you can get one from its parent resource <see cref="SqlServerResource" /> using the GetServerDnsAlias method.
    /// </summary>
    public partial class ServerDnsAliasResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ServerDnsAliasResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string dnsAliasName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _serverDnsAliasClientDiagnostics;
        private readonly ServerDnsAliasesRestOperations _serverDnsAliasRestClient;
        private readonly ServerDnsAliasData _data;

        /// <summary> Initializes a new instance of the <see cref="ServerDnsAliasResource"/> class for mocking. </summary>
        protected ServerDnsAliasResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ServerDnsAliasResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ServerDnsAliasResource(ArmClient client, ServerDnsAliasData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ServerDnsAliasResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ServerDnsAliasResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverDnsAliasClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string serverDnsAliasApiVersion);
            _serverDnsAliasRestClient = new ServerDnsAliasesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, serverDnsAliasApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/servers/dnsAliases";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ServerDnsAliasData Data
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
        /// Gets a server DNS alias.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ServerDnsAliasResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasResource.Get");
            scope.Start();
            try
            {
                var response = await _serverDnsAliasRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerDnsAliasResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a server DNS alias.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ServerDnsAliasResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasResource.Get");
            scope.Start();
            try
            {
                var response = _serverDnsAliasRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerDnsAliasResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the server DNS alias with the given name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasResource.Delete");
            scope.Start();
            try
            {
                var response = await _serverDnsAliasRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation(_serverDnsAliasClientDiagnostics, Pipeline, _serverDnsAliasRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Deletes the server DNS alias with the given name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}
        /// Operation Id: ServerDnsAliases_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasResource.Delete");
            scope.Start();
            try
            {
                var response = _serverDnsAliasRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SqlArmOperation(_serverDnsAliasClientDiagnostics, Pipeline, _serverDnsAliasRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Acquires server DNS alias from another server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}/acquire
        /// Operation Id: ServerDnsAliases_Acquire
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="parameters"> The ServerDnsAliasAcquisition to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ServerDnsAliasResource>> AcquireAsync(WaitUntil waitUntil, ServerDnsAliasAcquisition parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasResource.Acquire");
            scope.Start();
            try
            {
                var response = await _serverDnsAliasRestClient.AcquireAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<ServerDnsAliasResource>(new ServerDnsAliasOperationSource(Client), _serverDnsAliasClientDiagnostics, Pipeline, _serverDnsAliasRestClient.CreateAcquireRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Acquires server DNS alias from another server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/dnsAliases/{dnsAliasName}/acquire
        /// Operation Id: ServerDnsAliases_Acquire
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="parameters"> The ServerDnsAliasAcquisition to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ServerDnsAliasResource> Acquire(WaitUntil waitUntil, ServerDnsAliasAcquisition parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _serverDnsAliasClientDiagnostics.CreateScope("ServerDnsAliasResource.Acquire");
            scope.Start();
            try
            {
                var response = _serverDnsAliasRestClient.Acquire(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, parameters, cancellationToken);
                var operation = new SqlArmOperation<ServerDnsAliasResource>(new ServerDnsAliasOperationSource(Client), _serverDnsAliasClientDiagnostics, Pipeline, _serverDnsAliasRestClient.CreateAcquireRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, parameters).Request, response, OperationFinalStateVia.Location);
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
    }
}
