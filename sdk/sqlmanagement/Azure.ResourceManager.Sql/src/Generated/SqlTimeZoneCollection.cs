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

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="SqlTimeZoneResource" /> and their operations.
    /// Each <see cref="SqlTimeZoneResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="SqlTimeZoneCollection" /> instance call the GetSqlTimeZones method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class SqlTimeZoneCollection : ArmCollection, IEnumerable<SqlTimeZoneResource>, IAsyncEnumerable<SqlTimeZoneResource>
    {
        private readonly ClientDiagnostics _sqlTimeZoneTimeZonesClientDiagnostics;
        private readonly TimeZonesRestOperations _sqlTimeZoneTimeZonesRestClient;
        private readonly string _locationName;

        /// <summary> Initializes a new instance of the <see cref="SqlTimeZoneCollection"/> class for mocking. </summary>
        protected SqlTimeZoneCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SqlTimeZoneCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// <param name="locationName"> The String to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locationName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="locationName"/> is an empty string, and was expected to be non-empty. </exception>
        internal SqlTimeZoneCollection(ArmClient client, ResourceIdentifier id, string locationName) : base(client, id)
        {
            _locationName = locationName;
            _sqlTimeZoneTimeZonesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", SqlTimeZoneResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SqlTimeZoneResource.ResourceType, out string sqlTimeZoneTimeZonesApiVersion);
            _sqlTimeZoneTimeZonesRestClient = new TimeZonesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sqlTimeZoneTimeZonesApiVersion);
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
        /// Gets a managed instance time zone.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/timeZones/{timeZoneId}
        /// Operation Id: TimeZones_Get
        /// </summary>
        /// <param name="timeZoneId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="timeZoneId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="timeZoneId"/> is null. </exception>
        public virtual async Task<Response<SqlTimeZoneResource>> GetAsync(string timeZoneId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(timeZoneId, nameof(timeZoneId));

            using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.Get");
            scope.Start();
            try
            {
                var response = await _sqlTimeZoneTimeZonesRestClient.GetAsync(Id.SubscriptionId, _locationName, timeZoneId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SqlTimeZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a managed instance time zone.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/timeZones/{timeZoneId}
        /// Operation Id: TimeZones_Get
        /// </summary>
        /// <param name="timeZoneId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="timeZoneId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="timeZoneId"/> is null. </exception>
        public virtual Response<SqlTimeZoneResource> Get(string timeZoneId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(timeZoneId, nameof(timeZoneId));

            using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.Get");
            scope.Start();
            try
            {
                var response = _sqlTimeZoneTimeZonesRestClient.Get(Id.SubscriptionId, _locationName, timeZoneId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SqlTimeZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of managed instance time zones by location.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/timeZones
        /// Operation Id: TimeZones_ListByLocation
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlTimeZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlTimeZoneResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlTimeZoneResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlTimeZoneTimeZonesRestClient.ListByLocationAsync(Id.SubscriptionId, _locationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlTimeZoneResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SqlTimeZoneResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlTimeZoneTimeZonesRestClient.ListByLocationNextPageAsync(nextLink, Id.SubscriptionId, _locationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlTimeZoneResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of managed instance time zones by location.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/timeZones
        /// Operation Id: TimeZones_ListByLocation
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlTimeZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlTimeZoneResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SqlTimeZoneResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlTimeZoneTimeZonesRestClient.ListByLocation(Id.SubscriptionId, _locationName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlTimeZoneResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SqlTimeZoneResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlTimeZoneTimeZonesRestClient.ListByLocationNextPage(nextLink, Id.SubscriptionId, _locationName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlTimeZoneResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/timeZones/{timeZoneId}
        /// Operation Id: TimeZones_Get
        /// </summary>
        /// <param name="timeZoneId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="timeZoneId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="timeZoneId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string timeZoneId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(timeZoneId, nameof(timeZoneId));

            using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(timeZoneId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/timeZones/{timeZoneId}
        /// Operation Id: TimeZones_Get
        /// </summary>
        /// <param name="timeZoneId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="timeZoneId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="timeZoneId"/> is null. </exception>
        public virtual Response<bool> Exists(string timeZoneId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(timeZoneId, nameof(timeZoneId));

            using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(timeZoneId, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/timeZones/{timeZoneId}
        /// Operation Id: TimeZones_Get
        /// </summary>
        /// <param name="timeZoneId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="timeZoneId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="timeZoneId"/> is null. </exception>
        public virtual async Task<Response<SqlTimeZoneResource>> GetIfExistsAsync(string timeZoneId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(timeZoneId, nameof(timeZoneId));

            using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _sqlTimeZoneTimeZonesRestClient.GetAsync(Id.SubscriptionId, _locationName, timeZoneId, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SqlTimeZoneResource>(null, response.GetRawResponse());
                return Response.FromValue(new SqlTimeZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/timeZones/{timeZoneId}
        /// Operation Id: TimeZones_Get
        /// </summary>
        /// <param name="timeZoneId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="timeZoneId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="timeZoneId"/> is null. </exception>
        public virtual Response<SqlTimeZoneResource> GetIfExists(string timeZoneId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(timeZoneId, nameof(timeZoneId));

            using var scope = _sqlTimeZoneTimeZonesClientDiagnostics.CreateScope("SqlTimeZoneCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _sqlTimeZoneTimeZonesRestClient.Get(Id.SubscriptionId, _locationName, timeZoneId, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SqlTimeZoneResource>(null, response.GetRawResponse());
                return Response.FromValue(new SqlTimeZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SqlTimeZoneResource> IEnumerable<SqlTimeZoneResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SqlTimeZoneResource> IAsyncEnumerable<SqlTimeZoneResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
