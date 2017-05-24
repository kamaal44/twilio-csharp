using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1 
{

    /// <summary>
    /// ServiceResource
    /// </summary>
    public class ServiceResource : Resource 
    {
        private static Request BuildCreateRequest(CreateServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Notify,
                "/v1/Services",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static ServiceResource Create(CreateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(CreateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="apnCredentialSid"> The apn_credential_sid </param>
        /// <param name="gcmCredentialSid"> The gcm_credential_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="facebookMessengerPageId"> The facebook_messenger_page_id </param>
        /// <param name="defaultApnNotificationProtocolVersion"> The default_apn_notification_protocol_version </param>
        /// <param name="defaultGcmNotificationProtocolVersion"> The default_gcm_notification_protocol_version </param>
        /// <param name="fcmCredentialSid"> The fcm_credential_sid </param>
        /// <param name="defaultFcmNotificationProtocolVersion"> The default_fcm_notification_protocol_version </param>
        /// <param name="logEnabled"> The log_enabled </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static ServiceResource Create(string friendlyName = null, string apnCredentialSid = null, string gcmCredentialSid = null, string messagingServiceSid = null, string facebookMessengerPageId = null, string defaultApnNotificationProtocolVersion = null, string defaultGcmNotificationProtocolVersion = null, string fcmCredentialSid = null, string defaultFcmNotificationProtocolVersion = null, bool? logEnabled = null, ITwilioRestClient client = null)
        {
            var options = new CreateServiceOptions{FriendlyName = friendlyName, ApnCredentialSid = apnCredentialSid, GcmCredentialSid = gcmCredentialSid, MessagingServiceSid = messagingServiceSid, FacebookMessengerPageId = facebookMessengerPageId, DefaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion, DefaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion, FcmCredentialSid = fcmCredentialSid, DefaultFcmNotificationProtocolVersion = defaultFcmNotificationProtocolVersion, LogEnabled = logEnabled};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="apnCredentialSid"> The apn_credential_sid </param>
        /// <param name="gcmCredentialSid"> The gcm_credential_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="facebookMessengerPageId"> The facebook_messenger_page_id </param>
        /// <param name="defaultApnNotificationProtocolVersion"> The default_apn_notification_protocol_version </param>
        /// <param name="defaultGcmNotificationProtocolVersion"> The default_gcm_notification_protocol_version </param>
        /// <param name="fcmCredentialSid"> The fcm_credential_sid </param>
        /// <param name="defaultFcmNotificationProtocolVersion"> The default_fcm_notification_protocol_version </param>
        /// <param name="logEnabled"> The log_enabled </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(string friendlyName = null, string apnCredentialSid = null, string gcmCredentialSid = null, string messagingServiceSid = null, string facebookMessengerPageId = null, string defaultApnNotificationProtocolVersion = null, string defaultGcmNotificationProtocolVersion = null, string fcmCredentialSid = null, string defaultFcmNotificationProtocolVersion = null, bool? logEnabled = null, ITwilioRestClient client = null)
        {
            var options = new CreateServiceOptions{FriendlyName = friendlyName, ApnCredentialSid = apnCredentialSid, GcmCredentialSid = gcmCredentialSid, MessagingServiceSid = messagingServiceSid, FacebookMessengerPageId = facebookMessengerPageId, DefaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion, DefaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion, FcmCredentialSid = fcmCredentialSid, DefaultFcmNotificationProtocolVersion = defaultFcmNotificationProtocolVersion, LogEnabled = logEnabled};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Notify,
                "/v1/Services/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static bool Delete(DeleteServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteServiceOptions(pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteServiceOptions(pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildFetchRequest(FetchServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Notify,
                "/v1/Services/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static ServiceResource Fetch(FetchServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(FetchServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static ServiceResource Fetch(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchServiceOptions(pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchServiceOptions(pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Notify,
                "/v1/Services",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static ResourceSet<ServiceResource> Read(ReadServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<ServiceResource>.FromJson("services", response.Content);
            return new ResourceSet<ServiceResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(ReadServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ServiceResource>.FromJson("services", response.Content);
            return new ResourceSet<ServiceResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static ResourceSet<ServiceResource> Read(string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions{FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(string friendlyName = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions{FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<ServiceResource> NextPage(Page<ServiceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Notify,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<ServiceResource>.FromJson("services", response.Content);
        }

        private static Request BuildUpdateRequest(UpdateServiceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Notify,
                "/v1/Services/" + options.PathSid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static ServiceResource Update(UpdateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(UpdateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="apnCredentialSid"> The apn_credential_sid </param>
        /// <param name="gcmCredentialSid"> The gcm_credential_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="facebookMessengerPageId"> The facebook_messenger_page_id </param>
        /// <param name="defaultApnNotificationProtocolVersion"> The default_apn_notification_protocol_version </param>
        /// <param name="defaultGcmNotificationProtocolVersion"> The default_gcm_notification_protocol_version </param>
        /// <param name="fcmCredentialSid"> The fcm_credential_sid </param>
        /// <param name="defaultFcmNotificationProtocolVersion"> The default_fcm_notification_protocol_version </param>
        /// <param name="logEnabled"> The log_enabled </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns> 
        public static ServiceResource Update(string pathSid, string friendlyName = null, string apnCredentialSid = null, string gcmCredentialSid = null, string messagingServiceSid = null, string facebookMessengerPageId = null, string defaultApnNotificationProtocolVersion = null, string defaultGcmNotificationProtocolVersion = null, string fcmCredentialSid = null, string defaultFcmNotificationProtocolVersion = null, bool? logEnabled = null, ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(pathSid){FriendlyName = friendlyName, ApnCredentialSid = apnCredentialSid, GcmCredentialSid = gcmCredentialSid, MessagingServiceSid = messagingServiceSid, FacebookMessengerPageId = facebookMessengerPageId, DefaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion, DefaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion, FcmCredentialSid = fcmCredentialSid, DefaultFcmNotificationProtocolVersion = defaultFcmNotificationProtocolVersion, LogEnabled = logEnabled};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="apnCredentialSid"> The apn_credential_sid </param>
        /// <param name="gcmCredentialSid"> The gcm_credential_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="facebookMessengerPageId"> The facebook_messenger_page_id </param>
        /// <param name="defaultApnNotificationProtocolVersion"> The default_apn_notification_protocol_version </param>
        /// <param name="defaultGcmNotificationProtocolVersion"> The default_gcm_notification_protocol_version </param>
        /// <param name="fcmCredentialSid"> The fcm_credential_sid </param>
        /// <param name="defaultFcmNotificationProtocolVersion"> The default_fcm_notification_protocol_version </param>
        /// <param name="logEnabled"> The log_enabled </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns> 
        public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(string pathSid, string friendlyName = null, string apnCredentialSid = null, string gcmCredentialSid = null, string messagingServiceSid = null, string facebookMessengerPageId = null, string defaultApnNotificationProtocolVersion = null, string defaultGcmNotificationProtocolVersion = null, string fcmCredentialSid = null, string defaultFcmNotificationProtocolVersion = null, bool? logEnabled = null, ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(pathSid){FriendlyName = friendlyName, ApnCredentialSid = apnCredentialSid, GcmCredentialSid = gcmCredentialSid, MessagingServiceSid = messagingServiceSid, FacebookMessengerPageId = facebookMessengerPageId, DefaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion, DefaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion, FcmCredentialSid = fcmCredentialSid, DefaultFcmNotificationProtocolVersion = defaultFcmNotificationProtocolVersion, LogEnabled = logEnabled};
            return await UpdateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a ServiceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ServiceResource object represented by the provided JSON </returns> 
        public static ServiceResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ServiceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The apn_credential_sid
        /// </summary>
        [JsonProperty("apn_credential_sid")]
        public string ApnCredentialSid { get; private set; }
        /// <summary>
        /// The gcm_credential_sid
        /// </summary>
        [JsonProperty("gcm_credential_sid")]
        public string GcmCredentialSid { get; private set; }
        /// <summary>
        /// The fcm_credential_sid
        /// </summary>
        [JsonProperty("fcm_credential_sid")]
        public string FcmCredentialSid { get; private set; }
        /// <summary>
        /// The messaging_service_sid
        /// </summary>
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; private set; }
        /// <summary>
        /// The facebook_messenger_page_id
        /// </summary>
        [JsonProperty("facebook_messenger_page_id")]
        public string FacebookMessengerPageId { get; private set; }
        /// <summary>
        /// The default_apn_notification_protocol_version
        /// </summary>
        [JsonProperty("default_apn_notification_protocol_version")]
        public string DefaultApnNotificationProtocolVersion { get; private set; }
        /// <summary>
        /// The default_gcm_notification_protocol_version
        /// </summary>
        [JsonProperty("default_gcm_notification_protocol_version")]
        public string DefaultGcmNotificationProtocolVersion { get; private set; }
        /// <summary>
        /// The default_fcm_notification_protocol_version
        /// </summary>
        [JsonProperty("default_fcm_notification_protocol_version")]
        public string DefaultFcmNotificationProtocolVersion { get; private set; }
        /// <summary>
        /// The log_enabled
        /// </summary>
        [JsonProperty("log_enabled")]
        public bool? LogEnabled { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The links
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        private ServiceResource()
        {

        }
    }

}