using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ht8
{
    [TransactionInfo("Vitalii", "Version = 1.0")]
    internal class Transaction
    {
        private int Id { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        [JsonPropertyName("sender_full_name")]
        public string SenderName { get; set; }
        [JsonIgnore]
        public string SecretAuthCode { get; set; }
        private static int _counter = 0;

        [JsonConstructor]
        public Transaction(double amount, string currency, string senderName)
        {
            _counter++;
            Id = _counter;
            Amount = amount;
            Currency = currency;
            SenderName = senderName;
        }
    }
}
