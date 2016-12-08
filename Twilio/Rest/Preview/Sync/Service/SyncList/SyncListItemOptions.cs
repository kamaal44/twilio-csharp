using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Sync.Service.SyncList 
{

    public class FetchSyncListItemOptions : IOptions<SyncListItemResource> 
    {
        public string ServiceSid { get; }
        public string ListSid { get; }
        public int? Index { get; }
    
        /// <summary>
        /// Construct a new FetchSyncListItemOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <param name="index"> The index </param>
        public FetchSyncListItemOptions(string serviceSid, string listSid, int? index)
        {
            ServiceSid = serviceSid;
            ListSid = listSid;
            Index = index;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class DeleteSyncListItemOptions : IOptions<SyncListItemResource> 
    {
        public string ServiceSid { get; }
        public string ListSid { get; }
        public int? Index { get; }
    
        /// <summary>
        /// Construct a new DeleteSyncListItemOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <param name="index"> The index </param>
        public DeleteSyncListItemOptions(string serviceSid, string listSid, int? index)
        {
            ServiceSid = serviceSid;
            ListSid = listSid;
            Index = index;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class CreateSyncListItemOptions : IOptions<SyncListItemResource> 
    {
        public string ServiceSid { get; }
        public string ListSid { get; }
        public object Data { get; }
    
        /// <summary>
        /// Construct a new CreateSyncListItemOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <param name="data"> The data </param>
        public CreateSyncListItemOptions(string serviceSid, string listSid, object data)
        {
            ServiceSid = serviceSid;
            ListSid = listSid;
            Data = data;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Data.ToString()));
            }
            
            return p;
        }
    }

    public class ReadSyncListItemOptions : ReadOptions<SyncListItemResource> 
    {
        public string ServiceSid { get; }
        public string ListSid { get; }
        public SyncListItemResource.QueryResultOrderEnum Order { get; set; }
        public string From { get; set; }
        public SyncListItemResource.QueryFromBoundTypeEnum Bounds { get; set; }
    
        /// <summary>
        /// Construct a new ReadSyncListItemOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        public ReadSyncListItemOptions(string serviceSid, string listSid)
        {
            ServiceSid = serviceSid;
            ListSid = listSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Order != null)
            {
                p.Add(new KeyValuePair<string, string>("Order", Order.ToString()));
            }
            
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From));
            }
            
            if (Bounds != null)
            {
                p.Add(new KeyValuePair<string, string>("Bounds", Bounds.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateSyncListItemOptions : IOptions<SyncListItemResource> 
    {
        public string ServiceSid { get; }
        public string ListSid { get; }
        public int? Index { get; }
        public object Data { get; }
    
        /// <summary>
        /// Construct a new UpdateSyncListItemOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> The list_sid </param>
        /// <param name="index"> The index </param>
        /// <param name="data"> The data </param>
        public UpdateSyncListItemOptions(string serviceSid, string listSid, int? index, object data)
        {
            ServiceSid = serviceSid;
            ListSid = listSid;
            Index = index;
            Data = data;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Data.ToString()));
            }
            
            return p;
        }
    }

}