using System;
using System.Collections.Generic;
using System.Text;

namespace ht8
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TransactionInfoAttribute : Attribute
    {
        public string AuthorName { get; }
        public string Version { get; set; }

        public TransactionInfoAttribute(string author, string version)
        {
            AuthorName = author;
            Version = version;
        }
    }
}
