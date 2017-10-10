using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using BlobBindingFunction.Messages;

namespace BlobBindingFunction.Function
{
    public static class ServiceBusQueueTriggered
    {
        [FunctionName("ServiceBusQueueTriggered")]
        public static void Run(
            [ServiceBusTrigger("myqueuename", AccessRights.Manage, Connection = "ServiceBusConnectionString")] Message serviceBusMessage,
            [Blob(blobPath: "mycontainer/{BlobLocation}", access: FileAccess.Read)] string blobContents,
            TraceWriter log)
        {
            log.Info($"ServiceBus queue triggered and blob contents were: {blobContents}");
        }
    }
}
