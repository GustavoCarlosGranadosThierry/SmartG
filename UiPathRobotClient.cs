using Newtonsoft.Json;
using System;
using System.IO;
using System.ServiceModel;
using SmartG.UiPathRobotApi;

namespace SmartG
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class UiPathRobotClient : IUiPathRemoteDuplexContractCallback
    {
        private IUiPathRemoteDuplexContract Channel = null;
        private DuplexChannelFactory<IUiPathRemoteDuplexContract> DuplexChannelFactory = null;
        public UiPathRobotClient()
        {
            DuplexChannelFactory = new DuplexChannelFactory<IUiPathRemoteDuplexContract>(new InstanceContext(this), "DefaultDuplexEndpoint");
            DuplexChannelFactory.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            Channel = DuplexChannelFactory.CreateChannel();
        }

        #region Service methods
        public Guid StartJob(string serializedJob)
        {
            return Guid.Parse(Channel.StartJob(SerializeStringToStream(serializedJob)));
        }

        public static Stream SerializeStringToStream(string jobValue)
        {
            if (jobValue == null) return null;

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(jobValue);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        #endregion

        #region Duplex callbacks
        public bool OnTrackReceived(string serializedTrackingRecord)
        {
            return false;
        }

        public void OnJobCompleted(string invokeCompletedInfo)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None
            };
            var completedResult = JsonConvert.DeserializeObject<InvokeCompletedArgs>(invokeCompletedInfo, settings);
            if (completedResult.State == System.Activities.ActivityInstanceState.Faulted)
            {
                Console.WriteLine(completedResult.Error.Message);
            }
            else if (completedResult.State == System.Activities.ActivityInstanceState.Canceled)
            {
                Console.WriteLine("Process cancelled");
            }
            else
            {
                Console.WriteLine("Completed without errors");
            }
        }

        public void OnLog(string logMessage)
        {
        }

        public void OnPackagesUpdated()
        {
        }
        #endregion Duplex callback
    }
}
