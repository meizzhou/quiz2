using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebRole1
{
    /// <summary>
    /// Summary description for Admin
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Admin : System.Web.Services.WebService
    {
        public static CloudTable table;
        public static CloudQueue queue;
        

        [WebMethod]
        public void InsertQueue(string input1, string input2, string input3)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            queue = queueClient.GetQueueReference("myurls");
            queue.CreateIfNotExists();

            //Add message
            CloudQueueMessage message = new CloudQueueMessage(input1+input2+input3);
            queue.AddMessage(message);
        }

        [WebMethod]
        public void ReadSumFromTableStorage()
        {
            CloudStorageAccount storageAccount2 = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudTableClient tableClient = storageAccount2.CreateCloudTableClient();
            table = tableClient.GetTableReference("myurls");
            table.CreateIfNotExists();

        }

        

    }

}
