using BU.Stock.Core.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Stock.Service
{
    public abstract class AwsBaseService
    {
        private readonly string _credentialFile = @"D:\Repositories\BU Stock\AwsAccessInfo.json";

        public AwsCredentialModel GetAwsCredentials()
        {
            Logger logger = LogManager.GetLogger("foo");

            try
            {
                using (StreamReader r = new StreamReader(_credentialFile))
                {
                    string json = r.ReadToEnd();
                    AwsCredentialModel awsCredentialModel = JsonConvert.DeserializeObject<AwsCredentialModel>(json);

                    return awsCredentialModel;
                }

            }
            catch (FileNotFoundException ex)
            {
                // TODO - notify me
                logger.Info($"AWS Credential file was not fould : {ex.Message}");

                return null;
            }
        }
    }
}
