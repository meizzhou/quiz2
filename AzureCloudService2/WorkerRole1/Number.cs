using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkerRole1
{
    public class Number : TableEntity
    {

        public Number(string name, int sum)
        {
            this.PartitionKey = name;
            this.RowKey = Guid.NewGuid().ToString();

            this.sum = sum;
        }

        public Number()
        {

        }

        public int sum { get; set; }
    }
}