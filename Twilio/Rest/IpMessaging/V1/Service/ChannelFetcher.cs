using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.IpMessaging.V1.Service {

    public class ChannelFetcher : Fetcher<ChannelResource> {
        private string serviceSid;
        private string sid;
    
        /**
         * Construct a new ChannelFetcher
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         */
        public ChannelFetcher(string serviceSid, string sid) {
            this.serviceSid = serviceSid;
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched ChannelResource
         */
        public override async Task<ChannelResource> FetchAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.sid + ""
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("ChannelResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to fetch record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return ChannelResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched ChannelResource
         */
        public override ChannelResource Fetch(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.sid + ""
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ChannelResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to fetch record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return ChannelResource.FromJson(response.GetContent());
        }
    }
}