/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// BundleResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Numbers.V2.RegulatoryCompliance
{

    public class BundleResource : Resource
    {
        public sealed class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }

            public static readonly StatusEnum Draft = new StatusEnum("draft");
            public static readonly StatusEnum PendingReview = new StatusEnum("pending-review");
            public static readonly StatusEnum InReview = new StatusEnum("in-review");
            public static readonly StatusEnum TwilioRejected = new StatusEnum("twilio-rejected");
            public static readonly StatusEnum TwilioApproved = new StatusEnum("twilio-approved");
            public static readonly StatusEnum ProvisionallyApproved = new StatusEnum("provisionally-approved");
        }

        public sealed class EndUserTypeEnum : StringEnum
        {
            private EndUserTypeEnum(string value) : base(value) {}
            public EndUserTypeEnum() {}
            public static implicit operator EndUserTypeEnum(string value)
            {
                return new EndUserTypeEnum(value);
            }

            public static readonly EndUserTypeEnum Individual = new EndUserTypeEnum("individual");
            public static readonly EndUserTypeEnum Business = new EndUserTypeEnum("business");
        }

        private static Request BuildCreateRequest(CreateBundleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Numbers,
                "/v2/RegulatoryCompliance/Bundles",
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Create a new Bundle.
        /// </summary>
        /// <param name="options"> Create Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static BundleResource Create(CreateBundleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Create a new Bundle.
        /// </summary>
        /// <param name="options"> Create Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<BundleResource> CreateAsync(CreateBundleOptions options,
                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Create a new Bundle.
        /// </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="email"> The email address </param>
        /// <param name="statusCallback"> The URL we call to inform your application of status changes. </param>
        /// <param name="regulationSid"> The unique string of a regulation. </param>
        /// <param name="isoCountry"> The ISO country code of the country </param>
        /// <param name="endUserType"> The type of End User of the Bundle resource </param>
        /// <param name="numberType"> The type of phone number </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static BundleResource Create(string friendlyName,
                                            string email,
                                            Uri statusCallback = null,
                                            string regulationSid = null,
                                            string isoCountry = null,
                                            BundleResource.EndUserTypeEnum endUserType = null,
                                            string numberType = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateBundleOptions(friendlyName, email){StatusCallback = statusCallback, RegulationSid = regulationSid, IsoCountry = isoCountry, EndUserType = endUserType, NumberType = numberType};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Create a new Bundle.
        /// </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="email"> The email address </param>
        /// <param name="statusCallback"> The URL we call to inform your application of status changes. </param>
        /// <param name="regulationSid"> The unique string of a regulation. </param>
        /// <param name="isoCountry"> The ISO country code of the country </param>
        /// <param name="endUserType"> The type of End User of the Bundle resource </param>
        /// <param name="numberType"> The type of phone number </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<BundleResource> CreateAsync(string friendlyName,
                                                                                    string email,
                                                                                    Uri statusCallback = null,
                                                                                    string regulationSid = null,
                                                                                    string isoCountry = null,
                                                                                    BundleResource.EndUserTypeEnum endUserType = null,
                                                                                    string numberType = null,
                                                                                    ITwilioRestClient client = null)
        {
            var options = new CreateBundleOptions(friendlyName, email){StatusCallback = statusCallback, RegulationSid = regulationSid, IsoCountry = isoCountry, EndUserType = endUserType, NumberType = numberType};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadBundleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                "/v2/RegulatoryCompliance/Bundles",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of all Bundles for an account.
        /// </summary>
        /// <param name="options"> Read Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static ResourceSet<BundleResource> Read(ReadBundleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<BundleResource>.FromJson("results", response.Content);
            return new ResourceSet<BundleResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Bundles for an account.
        /// </summary>
        /// <param name="options"> Read Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<BundleResource>> ReadAsync(ReadBundleOptions options,
                                                                                               ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<BundleResource>.FromJson("results", response.Content);
            return new ResourceSet<BundleResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of all Bundles for an account.
        /// </summary>
        /// <param name="status"> The verification status of the Bundle resource </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="regulationSid"> The unique string of a regulation. </param>
        /// <param name="isoCountry"> The ISO country code of the country </param>
        /// <param name="numberType"> The type of phone number </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static ResourceSet<BundleResource> Read(BundleResource.StatusEnum status = null,
                                                       string friendlyName = null,
                                                       string regulationSid = null,
                                                       string isoCountry = null,
                                                       string numberType = null,
                                                       int? pageSize = null,
                                                       long? limit = null,
                                                       ITwilioRestClient client = null)
        {
            var options = new ReadBundleOptions(){Status = status, FriendlyName = friendlyName, RegulationSid = regulationSid, IsoCountry = isoCountry, NumberType = numberType, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Bundles for an account.
        /// </summary>
        /// <param name="status"> The verification status of the Bundle resource </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="regulationSid"> The unique string of a regulation. </param>
        /// <param name="isoCountry"> The ISO country code of the country </param>
        /// <param name="numberType"> The type of phone number </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<BundleResource>> ReadAsync(BundleResource.StatusEnum status = null,
                                                                                               string friendlyName = null,
                                                                                               string regulationSid = null,
                                                                                               string isoCountry = null,
                                                                                               string numberType = null,
                                                                                               int? pageSize = null,
                                                                                               long? limit = null,
                                                                                               ITwilioRestClient client = null)
        {
            var options = new ReadBundleOptions(){Status = status, FriendlyName = friendlyName, RegulationSid = regulationSid, IsoCountry = isoCountry, NumberType = numberType, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<BundleResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<BundleResource>.FromJson("results", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<BundleResource> NextPage(Page<BundleResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Numbers)
            );

            var response = client.Request(request);
            return Page<BundleResource>.FromJson("results", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<BundleResource> PreviousPage(Page<BundleResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Numbers)
            );

            var response = client.Request(request);
            return Page<BundleResource>.FromJson("results", response.Content);
        }

        private static Request BuildFetchRequest(FetchBundleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                "/v2/RegulatoryCompliance/Bundles/" + options.PathSid + "",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch a specific Bundle instance.
        /// </summary>
        /// <param name="options"> Fetch Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static BundleResource Fetch(FetchBundleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Bundle instance.
        /// </summary>
        /// <param name="options"> Fetch Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<BundleResource> FetchAsync(FetchBundleOptions options,
                                                                                   ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch a specific Bundle instance.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static BundleResource Fetch(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchBundleOptions(pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Bundle instance.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<BundleResource> FetchAsync(string pathSid,
                                                                                   ITwilioRestClient client = null)
        {
            var options = new FetchBundleOptions(pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateBundleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Numbers,
                "/v2/RegulatoryCompliance/Bundles/" + options.PathSid + "",
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Updates a Bundle in an account.
        /// </summary>
        /// <param name="options"> Update Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static BundleResource Update(UpdateBundleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Updates a Bundle in an account.
        /// </summary>
        /// <param name="options"> Update Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<BundleResource> UpdateAsync(UpdateBundleOptions options,
                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Updates a Bundle in an account.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource. </param>
        /// <param name="status"> The verification status of the Bundle resource </param>
        /// <param name="statusCallback"> The URL we call to inform your application of status changes. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="email"> The email address </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static BundleResource Update(string pathSid,
                                            BundleResource.StatusEnum status = null,
                                            Uri statusCallback = null,
                                            string friendlyName = null,
                                            string email = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateBundleOptions(pathSid){Status = status, StatusCallback = statusCallback, FriendlyName = friendlyName, Email = email};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Updates a Bundle in an account.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource. </param>
        /// <param name="status"> The verification status of the Bundle resource </param>
        /// <param name="statusCallback"> The URL we call to inform your application of status changes. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="email"> The email address </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<BundleResource> UpdateAsync(string pathSid,
                                                                                    BundleResource.StatusEnum status = null,
                                                                                    Uri statusCallback = null,
                                                                                    string friendlyName = null,
                                                                                    string email = null,
                                                                                    ITwilioRestClient client = null)
        {
            var options = new UpdateBundleOptions(pathSid){Status = status, StatusCallback = statusCallback, FriendlyName = friendlyName, Email = email};
            return await UpdateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteBundleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Numbers,
                "/v2/RegulatoryCompliance/Bundles/" + options.PathSid + "",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Delete a specific Bundle.
        /// </summary>
        /// <param name="options"> Delete Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static bool Delete(DeleteBundleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Delete a specific Bundle.
        /// </summary>
        /// <param name="options"> Delete Bundle parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteBundleOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Delete a specific Bundle.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Bundle </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteBundleOptions(pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Delete a specific Bundle.
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Bundle </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteBundleOptions(pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a BundleResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> BundleResource object represented by the provided JSON </returns>
        public static BundleResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<BundleResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The unique string that identifies the resource.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The SID of the Account that created the resource
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The unique string of a regulation.
        /// </summary>
        [JsonProperty("regulation_sid")]
        public string RegulationSid { get; private set; }
        /// <summary>
        /// The string that you assigned to describe the resource
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The verification status of the Bundle resource
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BundleResource.StatusEnum Status { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource will be valid until.
        /// </summary>
        [JsonProperty("valid_until")]
        public DateTime? ValidUntil { get; private set; }
        /// <summary>
        /// The email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; private set; }
        /// <summary>
        /// The URL we call to inform your application of status changes.
        /// </summary>
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The absolute URL of the Bundle resource
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The URLs of the Assigned Items of the Bundle resource
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        private BundleResource()
        {

        }
    }

}