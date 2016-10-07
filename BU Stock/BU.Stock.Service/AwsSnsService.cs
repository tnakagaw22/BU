using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using BU.Stock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service
{
    public class AwsSnsService : AwsBaseService
    {
        public bool PublishMessage(string subject, string body, string topicArn)
        {
            AwsCredentialModel awsCredentialModel = GetAwsCredentials();
            if (awsCredentialModel == null)
                return false;

            var sns = new AmazonSimpleNotificationServiceClient(awsCredentialModel.AccessKey,
                                                                awsCredentialModel.SecretKey,
                                                                RegionEndpoint.GetBySystemName(awsCredentialModel.RegionEndPoint));

            PublishRequest publishRequest = new PublishRequest();
            publishRequest.Subject = subject;
            publishRequest.Message = body;
            publishRequest.TopicArn = topicArn;

            PublishResponse result = sns.Publish(publishRequest);
            return result.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
