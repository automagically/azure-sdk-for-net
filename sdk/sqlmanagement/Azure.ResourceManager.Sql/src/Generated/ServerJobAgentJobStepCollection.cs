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

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="ServerJobAgentJobStepResource" /> and their operations.
    /// Each <see cref="ServerJobAgentJobStepResource" /> in the collection will belong to the same instance of <see cref="SqlJobResource" />.
    /// To get a <see cref="ServerJobAgentJobStepCollection" /> instance call the GetServerJobAgentJobSteps method from an instance of <see cref="SqlJobResource" />.
    /// </summary>
    public partial class ServerJobAgentJobStepCollection : ArmCollection, IEnumerable<ServerJobAgentJobStepResource>, IAsyncEnumerable<ServerJobAgentJobStepResource>
    {
        private readonly ClientDiagnostics _serverJobAgentJobStepJobStepsClientDiagnostics;
        private readonly JobStepsRestOperations _serverJobAgentJobStepJobStepsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ServerJobAgentJobStepCollection"/> class for mocking. </summary>
        protected ServerJobAgentJobStepCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ServerJobAgentJobStepCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ServerJobAgentJobStepCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverJobAgentJobStepJobStepsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ServerJobAgentJobStepResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ServerJobAgentJobStepResource.ResourceType, out string serverJobAgentJobStepJobStepsApiVersion);
            _serverJobAgentJobStepJobStepsRestClient = new JobStepsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, serverJobAgentJobStepJobStepsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlJobResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlJobResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a job step. This will implicitly create a new job version.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps/{stepName}
        /// Operation Id: JobSteps_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="stepName"> The name of the job step. </param>
        /// <param name="data"> The requested state of the job step. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="stepName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="stepName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ServerJobAgentJobStepResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string stepName, JobStepData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(stepName, nameof(stepName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _serverJobAgentJobStepJobStepsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, stepName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<ServerJobAgentJobStepResource>(Response.FromValue(new ServerJobAgentJobStepResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates a job step. This will implicitly create a new job version.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps/{stepName}
        /// Operation Id: JobSteps_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="stepName"> The name of the job step. </param>
        /// <param name="data"> The requested state of the job step. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="stepName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="stepName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ServerJobAgentJobStepResource> CreateOrUpdate(WaitUntil waitUntil, string stepName, JobStepData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(stepName, nameof(stepName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _serverJobAgentJobStepJobStepsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, stepName, data, cancellationToken);
                var operation = new SqlArmOperation<ServerJobAgentJobStepResource>(Response.FromValue(new ServerJobAgentJobStepResource(Client, response), response.GetRawResponse()));
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
        /// Gets a job step in a job&apos;s current version.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps/{stepName}
        /// Operation Id: JobSteps_Get
        /// </summary>
        /// <param name="stepName"> The name of the job step. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="stepName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="stepName"/> is null. </exception>
        public virtual async Task<Response<ServerJobAgentJobStepResource>> GetAsync(string stepName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(stepName, nameof(stepName));

            using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.Get");
            scope.Start();
            try
            {
                var response = await _serverJobAgentJobStepJobStepsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, stepName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerJobAgentJobStepResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a job step in a job&apos;s current version.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps/{stepName}
        /// Operation Id: JobSteps_Get
        /// </summary>
        /// <param name="stepName"> The name of the job step. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="stepName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="stepName"/> is null. </exception>
        public virtual Response<ServerJobAgentJobStepResource> Get(string stepName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(stepName, nameof(stepName));

            using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.Get");
            scope.Start();
            try
            {
                var response = _serverJobAgentJobStepJobStepsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, stepName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerJobAgentJobStepResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all job steps for a job&apos;s current version.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps
        /// Operation Id: JobSteps_ListByJob
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServerJobAgentJobStepResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServerJobAgentJobStepResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ServerJobAgentJobStepResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverJobAgentJobStepJobStepsRestClient.ListByJobAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerJobAgentJobStepResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ServerJobAgentJobStepResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverJobAgentJobStepJobStepsRestClient.ListByJobNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerJobAgentJobStepResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all job steps for a job&apos;s current version.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps
        /// Operation Id: JobSteps_ListByJob
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServerJobAgentJobStepResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServerJobAgentJobStepResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ServerJobAgentJobStepResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverJobAgentJobStepJobStepsRestClient.ListByJob(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerJobAgentJobStepResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ServerJobAgentJobStepResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverJobAgentJobStepJobStepsRestClient.ListByJobNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerJobAgentJobStepResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps/{stepName}
        /// Operation Id: JobSteps_Get
        /// </summary>
        /// <param name="stepName"> The name of the job step. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="stepName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="stepName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string stepName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(stepName, nameof(stepName));

            using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(stepName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps/{stepName}
        /// Operation Id: JobSteps_Get
        /// </summary>
        /// <param name="stepName"> The name of the job step. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="stepName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="stepName"/> is null. </exception>
        public virtual Response<bool> Exists(string stepName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(stepName, nameof(stepName));

            using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(stepName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps/{stepName}
        /// Operation Id: JobSteps_Get
        /// </summary>
        /// <param name="stepName"> The name of the job step. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="stepName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="stepName"/> is null. </exception>
        public virtual async Task<Response<ServerJobAgentJobStepResource>> GetIfExistsAsync(string stepName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(stepName, nameof(stepName));

            using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _serverJobAgentJobStepJobStepsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, stepName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ServerJobAgentJobStepResource>(null, response.GetRawResponse());
                return Response.FromValue(new ServerJobAgentJobStepResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps/{stepName}
        /// Operation Id: JobSteps_Get
        /// </summary>
        /// <param name="stepName"> The name of the job step. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="stepName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="stepName"/> is null. </exception>
        public virtual Response<ServerJobAgentJobStepResource> GetIfExists(string stepName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(stepName, nameof(stepName));

            using var scope = _serverJobAgentJobStepJobStepsClientDiagnostics.CreateScope("ServerJobAgentJobStepCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _serverJobAgentJobStepJobStepsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, stepName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ServerJobAgentJobStepResource>(null, response.GetRawResponse());
                return Response.FromValue(new ServerJobAgentJobStepResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ServerJobAgentJobStepResource> IEnumerable<ServerJobAgentJobStepResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ServerJobAgentJobStepResource> IAsyncEnumerable<ServerJobAgentJobStepResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
