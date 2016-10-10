using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1 {

    public class WorkspaceResource : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return WorkspaceFetcher capable of executing the fetch
         */
        public static WorkspaceFetcher Fetcher(string sid) {
            return new WorkspaceFetcher(sid);
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @return WorkspaceUpdater capable of executing the update
         */
        public static WorkspaceUpdater Updater(string sid) {
            return new WorkspaceUpdater(sid);
        }
    
        /**
         * read
         * 
         * @return WorkspaceReader capable of executing the read
         */
        public static WorkspaceReader Reader() {
            return new WorkspaceReader();
        }
    
        /**
         * create
         * 
         * @param friendlyName The friendly_name
         * @return WorkspaceCreator capable of executing the create
         */
        public static WorkspaceCreator Creator(string friendlyName) {
            return new WorkspaceCreator(friendlyName);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return WorkspaceDeleter capable of executing the delete
         */
        public static WorkspaceDeleter Deleter(string sid) {
            return new WorkspaceDeleter(sid);
        }
    
        /**
         * Converts a JSON string into a WorkspaceResource object
         * 
         * @param json Raw JSON string
         * @return WorkspaceResource object represented by the provided JSON
         */
        public static WorkspaceResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkspaceResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("default_activity_name")]
        private readonly string defaultActivityName;
        [JsonProperty("default_activity_sid")]
        private readonly string defaultActivitySid;
        [JsonProperty("event_callback_url")]
        private readonly Uri eventCallbackUrl;
        [JsonProperty("events_filter")]
        private readonly string eventsFilter;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("multi_task_enabled")]
        private readonly bool? multiTaskEnabled;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("timeout_activity_name")]
        private readonly string timeoutActivityName;
        [JsonProperty("timeout_activity_sid")]
        private readonly string timeoutActivitySid;
    
        public WorkspaceResource() {
        
        }
    
        private WorkspaceResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("default_activity_name")]
                                  string defaultActivityName, 
                                  [JsonProperty("default_activity_sid")]
                                  string defaultActivitySid, 
                                  [JsonProperty("event_callback_url")]
                                  Uri eventCallbackUrl, 
                                  [JsonProperty("events_filter")]
                                  string eventsFilter, 
                                  [JsonProperty("friendly_name")]
                                  string friendlyName, 
                                  [JsonProperty("multi_task_enabled")]
                                  bool? multiTaskEnabled, 
                                  [JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("timeout_activity_name")]
                                  string timeoutActivityName, 
                                  [JsonProperty("timeout_activity_sid")]
                                  string timeoutActivitySid) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.defaultActivityName = defaultActivityName;
            this.defaultActivitySid = defaultActivitySid;
            this.eventCallbackUrl = eventCallbackUrl;
            this.eventsFilter = eventsFilter;
            this.friendlyName = friendlyName;
            this.multiTaskEnabled = multiTaskEnabled;
            this.sid = sid;
            this.timeoutActivityName = timeoutActivityName;
            this.timeoutActivitySid = timeoutActivitySid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The default_activity_name
         */
        public string GetDefaultActivityName() {
            return this.defaultActivityName;
        }
    
        /**
         * @return The default_activity_sid
         */
        public string GetDefaultActivitySid() {
            return this.defaultActivitySid;
        }
    
        /**
         * @return The event_callback_url
         */
        public Uri GetEventCallbackUrl() {
            return this.eventCallbackUrl;
        }
    
        /**
         * @return The events_filter
         */
        public string GetEventsFilter() {
            return this.eventsFilter;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The multi_task_enabled
         */
        public bool? GetMultiTaskEnabled() {
            return this.multiTaskEnabled;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The timeout_activity_name
         */
        public string GetTimeoutActivityName() {
            return this.timeoutActivityName;
        }
    
        /**
         * @return The timeout_activity_sid
         */
        public string GetTimeoutActivitySid() {
            return this.timeoutActivitySid;
        }
    }
}