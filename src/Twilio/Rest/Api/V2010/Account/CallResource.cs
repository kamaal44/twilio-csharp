using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    /// <summary>
    /// CallResource
    /// </summary>
    public class CallResource : Resource 
    {
        public sealed class EventEnum : StringEnum 
        {
            private EventEnum(string value) : base(value) {}
            public EventEnum() {}

            public static readonly EventEnum Initiated = new EventEnum("initiated");
            public static readonly EventEnum Ringing = new EventEnum("ringing");
            public static readonly EventEnum Answered = new EventEnum("answered");
            public static readonly EventEnum Completed = new EventEnum("completed");
        }

        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}

            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum Ringing = new StatusEnum("ringing");
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
            public static readonly StatusEnum Busy = new StatusEnum("busy");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
            public static readonly StatusEnum NoAnswer = new StatusEnum("no-answer");
            public static readonly StatusEnum Canceled = new StatusEnum("canceled");
        }

        public sealed class UpdateStatusEnum : StringEnum 
        {
            private UpdateStatusEnum(string value) : base(value) {}
            public UpdateStatusEnum() {}

            public static readonly UpdateStatusEnum Canceled = new UpdateStatusEnum("canceled");
            public static readonly UpdateStatusEnum Completed = new UpdateStatusEnum("completed");
        }

        private static Request BuildCreateRequest(CreateCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls.json",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        ///
        /// <param name="options"> Create Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static CallResource Create(CreateCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        ///
        /// <param name="options"> Create Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<CallResource> CreateAsync(CreateCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackEvent"> The status_callback_event </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <param name="sendDigits"> Digits to send </param>
        /// <param name="ifMachine"> Action to take if a machine has answered the call </param>
        /// <param name="timeout"> Number of seconds to wait for an answer </param>
        /// <param name="record"> Whether or not to record the Call </param>
        /// <param name="recordingChannels"> The recording_channels </param>
        /// <param name="recordingStatusCallback"> The recording_status_callback </param>
        /// <param name="recordingStatusCallbackMethod"> The recording_status_callback_method </param>
        /// <param name="sipAuthUsername"> The sip_auth_username </param>
        /// <param name="sipAuthPassword"> The sip_auth_password </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static CallResource Create(IEndpoint to, Types.PhoneNumber from, string pathAccountSid = null, Uri url = null, string applicationSid = null, Twilio.Http.HttpMethod method = null, Uri fallbackUrl = null, Twilio.Http.HttpMethod fallbackMethod = null, Uri statusCallback = null, List<string> statusCallbackEvent = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string sendDigits = null, string ifMachine = null, int? timeout = null, bool? record = null, string recordingChannels = null, string recordingStatusCallback = null, Twilio.Http.HttpMethod recordingStatusCallbackMethod = null, string sipAuthUsername = null, string sipAuthPassword = null, ITwilioRestClient client = null)
        {
            var options = new CreateCallOptions(to, from){PathAccountSid = pathAccountSid, Url = url, ApplicationSid = applicationSid, Method = method, FallbackUrl = fallbackUrl, FallbackMethod = fallbackMethod, StatusCallback = statusCallback, StatusCallbackEvent = statusCallbackEvent, StatusCallbackMethod = statusCallbackMethod, SendDigits = sendDigits, IfMachine = ifMachine, Timeout = timeout, Record = record, RecordingChannels = recordingChannels, RecordingStatusCallback = recordingStatusCallback, RecordingStatusCallbackMethod = recordingStatusCallbackMethod, SipAuthUsername = sipAuthUsername, SipAuthPassword = sipAuthPassword};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackEvent"> The status_callback_event </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <param name="sendDigits"> Digits to send </param>
        /// <param name="ifMachine"> Action to take if a machine has answered the call </param>
        /// <param name="timeout"> Number of seconds to wait for an answer </param>
        /// <param name="record"> Whether or not to record the Call </param>
        /// <param name="recordingChannels"> The recording_channels </param>
        /// <param name="recordingStatusCallback"> The recording_status_callback </param>
        /// <param name="recordingStatusCallbackMethod"> The recording_status_callback_method </param>
        /// <param name="sipAuthUsername"> The sip_auth_username </param>
        /// <param name="sipAuthPassword"> The sip_auth_password </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<CallResource> CreateAsync(IEndpoint to, Types.PhoneNumber from, string pathAccountSid = null, Uri url = null, string applicationSid = null, Twilio.Http.HttpMethod method = null, Uri fallbackUrl = null, Twilio.Http.HttpMethod fallbackMethod = null, Uri statusCallback = null, List<string> statusCallbackEvent = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string sendDigits = null, string ifMachine = null, int? timeout = null, bool? record = null, string recordingChannels = null, string recordingStatusCallback = null, Twilio.Http.HttpMethod recordingStatusCallbackMethod = null, string sipAuthUsername = null, string sipAuthPassword = null, ITwilioRestClient client = null)
        {
            var options = new CreateCallOptions(to, from){PathAccountSid = pathAccountSid, Url = url, ApplicationSid = applicationSid, Method = method, FallbackUrl = fallbackUrl, FallbackMethod = fallbackMethod, StatusCallback = statusCallback, StatusCallbackEvent = statusCallbackEvent, StatusCallbackMethod = statusCallbackMethod, SendDigits = sendDigits, IfMachine = ifMachine, Timeout = timeout, Record = record, RecordingChannels = recordingChannels, RecordingStatusCallback = recordingStatusCallback, RecordingStatusCallbackMethod = recordingStatusCallbackMethod, SipAuthUsername = sipAuthUsername, SipAuthPassword = sipAuthPassword};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls/" + options.PathSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Once the record is deleted, it will no longer appear in the API and Account Portal logs.
        /// </summary>
        ///
        /// <param name="options"> Delete Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static bool Delete(DeleteCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Once the record is deleted, it will no longer appear in the API and Account Portal logs.
        /// </summary>
        ///
        /// <param name="options"> Delete Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Once the record is deleted, it will no longer appear in the API and Account Portal logs.
        /// </summary>
        ///
        /// <param name="pathSid"> Call Sid that uniquely identifies the Call to delete </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static bool Delete(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteCallOptions(pathSid){PathAccountSid = pathAccountSid};
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Once the record is deleted, it will no longer appear in the API and Account Portal logs.
        /// </summary>
        ///
        /// <param name="pathSid"> Call Sid that uniquely identifies the Call to delete </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteCallOptions(pathSid){PathAccountSid = pathAccountSid};
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildFetchRequest(FetchCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls/" + options.PathSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch the Call specified by the provided Call Sid
        /// </summary>
        ///
        /// <param name="options"> Fetch Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static CallResource Fetch(FetchCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch the Call specified by the provided Call Sid
        /// </summary>
        ///
        /// <param name="options"> Fetch Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<CallResource> FetchAsync(FetchCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch the Call specified by the provided Call Sid
        /// </summary>
        ///
        /// <param name="pathSid"> Call Sid that uniquely identifies the Call to fetch </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static CallResource Fetch(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchCallOptions(pathSid){PathAccountSid = pathAccountSid};
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch the Call specified by the provided Call Sid
        /// </summary>
        ///
        /// <param name="pathSid"> Call Sid that uniquely identifies the Call to fetch </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<CallResource> FetchAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchCallOptions(pathSid){PathAccountSid = pathAccountSid};
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieves a collection of Calls made to and from your account
        /// </summary>
        ///
        /// <param name="options"> Read Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static ResourceSet<CallResource> Read(ReadCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<CallResource>.FromJson("calls", response.Content);
            return new ResourceSet<CallResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieves a collection of Calls made to and from your account
        /// </summary>
        ///
        /// <param name="options"> Read Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<CallResource>> ReadAsync(ReadCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<CallResource>.FromJson("calls", response.Content);
            return new ResourceSet<CallResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieves a collection of Calls made to and from your account
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="to"> Phone number or Client identifier to filter `to` on </param>
        /// <param name="from"> Phone number or Client identifier to filter `from` on </param>
        /// <param name="parentCallSid"> Parent Call Sid to filter on </param>
        /// <param name="status"> Status to filter on </param>
        /// <param name="startTimeBefore"> StartTime to filter on </param>
        /// <param name="startTime"> StartTime to filter on </param>
        /// <param name="startTimeAfter"> StartTime to filter on </param>
        /// <param name="endTimeBefore"> EndTime to filter on </param>
        /// <param name="endTime"> EndTime to filter on </param>
        /// <param name="endTimeAfter"> EndTime to filter on </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static ResourceSet<CallResource> Read(string pathAccountSid = null, Types.PhoneNumber to = null, Types.PhoneNumber from = null, string parentCallSid = null, CallResource.StatusEnum status = null, DateTime? startTimeBefore = null, DateTime? startTime = null, DateTime? startTimeAfter = null, DateTime? endTimeBefore = null, DateTime? endTime = null, DateTime? endTimeAfter = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCallOptions{PathAccountSid = pathAccountSid, To = to, From = from, ParentCallSid = parentCallSid, Status = status, StartTimeBefore = startTimeBefore, StartTime = startTime, StartTimeAfter = startTimeAfter, EndTimeBefore = endTimeBefore, EndTime = endTime, EndTimeAfter = endTimeAfter, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieves a collection of Calls made to and from your account
        /// </summary>
        ///
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="to"> Phone number or Client identifier to filter `to` on </param>
        /// <param name="from"> Phone number or Client identifier to filter `from` on </param>
        /// <param name="parentCallSid"> Parent Call Sid to filter on </param>
        /// <param name="status"> Status to filter on </param>
        /// <param name="startTimeBefore"> StartTime to filter on </param>
        /// <param name="startTime"> StartTime to filter on </param>
        /// <param name="startTimeAfter"> StartTime to filter on </param>
        /// <param name="endTimeBefore"> EndTime to filter on </param>
        /// <param name="endTime"> EndTime to filter on </param>
        /// <param name="endTimeAfter"> EndTime to filter on </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<CallResource>> ReadAsync(string pathAccountSid = null, Types.PhoneNumber to = null, Types.PhoneNumber from = null, string parentCallSid = null, CallResource.StatusEnum status = null, DateTime? startTimeBefore = null, DateTime? startTime = null, DateTime? startTimeAfter = null, DateTime? endTimeBefore = null, DateTime? endTime = null, DateTime? endTimeAfter = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCallOptions{PathAccountSid = pathAccountSid, To = to, From = from, ParentCallSid = parentCallSid, Status = status, StartTimeBefore = startTimeBefore, StartTime = startTime, StartTimeAfter = startTimeAfter, EndTimeBefore = endTimeBefore, EndTime = endTime, EndTimeAfter = endTimeAfter, PageSize = pageSize, Limit = limit};
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
        public static Page<CallResource> NextPage(Page<CallResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<CallResource>.FromJson("calls", response.Content);
        }

        private static Request BuildUpdateRequest(UpdateCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls/" + options.PathSid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Initiates a call redirect or terminates a call
        /// </summary>
        ///
        /// <param name="options"> Update Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static CallResource Update(UpdateCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Initiates a call redirect or terminates a call
        /// </summary>
        ///
        /// <param name="options"> Update Call parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<CallResource> UpdateAsync(UpdateCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Initiates a call redirect or terminates a call
        /// </summary>
        ///
        /// <param name="pathSid"> Call Sid that uniquely identifies the Call to update </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="url"> URL that returns TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="status"> Status to update the Call with </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Call </returns> 
        public static CallResource Update(string pathSid, string pathAccountSid = null, Uri url = null, Twilio.Http.HttpMethod method = null, CallResource.UpdateStatusEnum status = null, Uri fallbackUrl = null, Twilio.Http.HttpMethod fallbackMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateCallOptions(pathSid){PathAccountSid = pathAccountSid, Url = url, Method = method, Status = status, FallbackUrl = fallbackUrl, FallbackMethod = fallbackMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Initiates a call redirect or terminates a call
        /// </summary>
        ///
        /// <param name="pathSid"> Call Sid that uniquely identifies the Call to update </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="url"> URL that returns TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="status"> Status to update the Call with </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Call </returns> 
        public static async System.Threading.Tasks.Task<CallResource> UpdateAsync(string pathSid, string pathAccountSid = null, Uri url = null, Twilio.Http.HttpMethod method = null, CallResource.UpdateStatusEnum status = null, Uri fallbackUrl = null, Twilio.Http.HttpMethod fallbackMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateCallOptions(pathSid){PathAccountSid = pathAccountSid, Url = url, Method = method, Status = status, FallbackUrl = fallbackUrl, FallbackMethod = fallbackMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return await UpdateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a CallResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CallResource object represented by the provided JSON </returns> 
        public static CallResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CallResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The unique id of the Account responsible for creating this Call
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The annotation provided for the Call
        /// </summary>
        [JsonProperty("annotation")]
        public string Annotation { get; private set; }
        /// <summary>
        /// If this call was initiated with answering machine detection, either `human` or `machine`. Empty otherwise.
        /// </summary>
        [JsonProperty("answered_by")]
        public string AnsweredBy { get; private set; }
        /// <summary>
        /// The API Version the Call was created through
        /// </summary>
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        /// <summary>
        /// If this call was an incoming call to a phone number with Caller ID Lookup enabled, the caller's name. Empty otherwise.
        /// </summary>
        [JsonProperty("caller_name")]
        public string CallerName { get; private set; }
        /// <summary>
        /// The date that this resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date that this resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// A string describing the direction of the call. `inbound` for inbound calls, `outbound-api` for calls initiated via the REST API or `outbound-dial` for calls initiated by a `Dial` verb.
        /// </summary>
        [JsonProperty("direction")]
        public string Direction { get; private set; }
        /// <summary>
        /// The duration
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; private set; }
        /// <summary>
        /// The end time of the Call. Null if the call did not complete successfully.
        /// </summary>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; private set; }
        /// <summary>
        /// If this Call was an incoming call forwarded from another number, the forwarding phone number (depends on carrier supporting forwarding). Empty otherwise.
        /// </summary>
        [JsonProperty("forwarded_from")]
        public string ForwardedFrom { get; private set; }
        /// <summary>
        /// The phone number, SIP address or Client identifier that made this Call. Phone numbers are in E.164 format (e.g. +16175551212). SIP addresses are formatted as `name@company.com`. Client identifiers are formatted `client:name`.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; private set; }
        /// <summary>
        /// The phone number, SIP address or Client identifier that made this Call. Formatted for display.
        /// </summary>
        [JsonProperty("from_formatted")]
        public string FromFormatted { get; private set; }
        /// <summary>
        /// A 34 character Group Sid associated with this Call. Empty if no Group is associated with the Call.
        /// </summary>
        [JsonProperty("group_sid")]
        public string GroupSid { get; private set; }
        /// <summary>
        /// A 34 character string that uniquely identifies the Call that created this leg.
        /// </summary>
        [JsonProperty("parent_call_sid")]
        public string ParentCallSid { get; private set; }
        /// <summary>
        /// If the call was inbound, this is the Sid of the IncomingPhoneNumber that received the call. If the call was outbound, it is the Sid of the OutgoingCallerId from which the call was placed.
        /// </summary>
        [JsonProperty("phone_number_sid")]
        public string PhoneNumberSid { get; private set; }
        /// <summary>
        /// The charge for this call, in the currency associated with the account. Populated after the call is completed. May not be immediately available.
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; private set; }
        /// <summary>
        /// The currency in which `Price` is measured.
        /// </summary>
        [JsonProperty("price_unit")]
        public string PriceUnit { get; private set; }
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The start time of the Call. Null if the call has not yet been dialed.
        /// </summary>
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; private set; }
        /// <summary>
        /// The status
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CallResource.StatusEnum Status { get; private set; }
        /// <summary>
        /// Call Instance Subresources
        /// </summary>
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }
        /// <summary>
        /// The phone number, SIP address or Client identifier that received this Call. Phone numbers are in E.164 format (e.g. +16175551212). SIP addresses are formatted as `name@company.com`. Client identifiers are formatted `client:name`.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; private set; }
        /// <summary>
        /// The phone number, SIP address or Client identifier that received this Call. Formatted for display.
        /// </summary>
        [JsonProperty("to_formatted")]
        public string ToFormatted { get; private set; }
        /// <summary>
        /// The URI for this resource, relative to `https://api.twilio.com`
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; private set; }

        private CallResource()
        {

        }
    }

}