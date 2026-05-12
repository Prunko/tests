using System.Text.Json.Serialization;
using System.Collections.Generic;
using ht14;

namespace ht14
{
    [JsonSerializable(typeof(List<Order>))]
    [JsonSerializable(typeof(Order))]
    [JsonSerializable(typeof(CreateOrderDto))]
    [JsonSerializable(typeof(UpdateOrderDto))]
    internal partial class AppJsonContext : JsonSerializerContext
    {
        
    }
}