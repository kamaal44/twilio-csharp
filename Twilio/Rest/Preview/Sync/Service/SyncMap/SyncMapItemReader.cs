using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Sync.Service.SyncMap {

    public class SyncMapItemReader : Reader<SyncMapItemResource> {
        private string serviceSid;
        private string mapSid;
        private SyncMapItemResource.QueryResultOrder order;
        private string from;
        private SyncMapItemResource.QueryFromBoundType bounds;
    
        /**
         * Construct a new SyncMapItemReader
         * 
         * @param serviceSid The service_sid
         * @param mapSid The map_sid
         */
        public SyncMapItemReader(string serviceSid, string mapSid) {
            this.serviceSid = serviceSid;
            this.mapSid = mapSid;
        }
    
        /**
         * The order
         * 
         * @param order The order
         * @return this
         */
        public SyncMapItemReader ByOrder(SyncMapItemResource.QueryResultOrder order) {
            this.order = order;
            return this;
        }
    
        /**
         * The from
         * 
         * @param from The from
         * @return this
         */
        public SyncMapItemReader ByFrom(string from) {
            this.from = from;
            return this;
        }
    
        /**
         * The bounds
         * 
         * @param bounds The bounds
         * @return this
         */
        public SyncMapItemReader ByBounds(SyncMapItemResource.QueryFromBoundType bounds) {
            this.bounds = bounds;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return SyncMapItemResource ResourceSet
         */
        public override Task<ResourceSet<SyncMapItemResource>> ReadAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Maps/" + this.mapSid + "/Items"
            );
            
            AddQueryParams(request);
            
            Page<SyncMapItemResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<SyncMapItemResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return SyncMapItemResource ResourceSet
         */
        public override ResourceSet<SyncMapItemResource> Read(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/Sync/Services/" + this.serviceSid + "/Maps/" + this.mapSid + "/Items"
            );
            
            AddQueryParams(request);
            
            Page<SyncMapItemResource> page = PageForRequest(client, request);
            
            return new ResourceSet<SyncMapItemResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<SyncMapItemResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of SyncMapItemResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<SyncMapItemResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SyncMapItemResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to read records, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            Page<SyncMapItemResource> result = new Page<SyncMapItemResource>();
            result.deserialize("items", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (order != null) {
                request.AddQueryParam("Order", order.ToString());
            }
            
            if (from != null) {
                request.AddQueryParam("From", from);
            }
            
            if (bounds != null) {
                request.AddQueryParam("Bounds", bounds.ToString());
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}