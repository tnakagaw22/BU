using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service
{
    public class AwsSnsService
    {
        string accessKey = "AKIAJDXEK2NQFZVS6CCA";
        string secretAccessKey = "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";

        public bool PublishMessage(string subject, string body, string topicArn)
        {
            var sns = new AmazonSimpleNotificationServiceClient(accessKey, secretAccessKey, RegionEndpoint.USWest2);

            PublishRequest publishRequest = new PublishRequest();
            publishRequest.Subject = subject;
            publishRequest.Message = body;
            publishRequest.TopicArn = topicArn;

            PublishResponse result = sns.Publish(publishRequest);
            return result.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
