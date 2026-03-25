using System;
using System.Reflection;
using System.Text.Json;

namespace ht8
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction1 = new Transaction(1000, "UAH", "Dmytro_Ostapchyshyn");
            var transaction2 = new Transaction(2000, "UAH", "Petro_Ostapchyshyn");
            var transaction3 = new Transaction(4000, "UAH", "Vidro_Ostapchyshyn");
            var transaction4 = new Transaction(8000, "UAH", "Rebro_Ostapchyshyn");
            var transaction5 = new Transaction(16000, "UAH", "Bedro_Ostapchyshyn");

            InspectObject(transaction5);

            var options = new JsonSerializerOptions { WriteIndented = true,  };
            string jsonString1 = JsonSerializer.Serialize(transaction1, options);
            string jsonString2 = JsonSerializer.Serialize(transaction2, options);
            string jsonString3 = JsonSerializer.Serialize(transaction3, options);
            string jsonString4 = JsonSerializer.Serialize(transaction4, options);
            string jsonString5 = JsonSerializer.Serialize(transaction5, options);

            Console.WriteLine("Serialization result:" +
                $"\n{jsonString1}" +
                $"\n{jsonString2}" +
                $"\n{jsonString3}" +
                $"\n{jsonString4}" +
                $"\n{jsonString5}");

            Transaction restoredTrans1 = JsonSerializer.Deserialize<Transaction>(jsonString1, options);
            Transaction restoredTrans2 = JsonSerializer.Deserialize<Transaction>(jsonString2, options);
            Transaction restoredTrans3 = JsonSerializer.Deserialize<Transaction>(jsonString3, options);
            Transaction restoredTrans4 = JsonSerializer.Deserialize<Transaction>(jsonString4, options);
            Transaction restoredTrans5 = JsonSerializer.Deserialize<Transaction>(jsonString5, options);

            Console.WriteLine("\nDeserialization result for Transaction3:" +
                $"\nSender name: {restoredTrans3.SenderName}" +
                $"\nIs SecretAuthCode restored?: {(restoredTrans3.SecretAuthCode == null)}");
        }

        static void InspectObject(object obj)
        {
            if (obj == null) return;

            Type type = obj.GetType();
            Console.WriteLine($"Object type: {type.Name}");

            var authAttribute = type.GetCustomAttribute<TransactionInfoAttribute>();
            if (authAttribute != null )
            {
                Console.WriteLine($"Attribute found. Author: {authAttribute.AuthorName}, Version: {authAttribute.Version}");
            }
            else
            {
                Console.WriteLine("Attribute was not found");
            }

            PropertyInfo[] properties = type.GetProperties();
            Console.WriteLine("Properties:");
            foreach (var property in properties)
            {
                object value = property.GetValue(obj) ?? " - ";
                Console.WriteLine($" - {property.Name} ({property.PropertyType.Name}): {value}");
            }

            FieldInfo privateField = type.GetField("Id", BindingFlags.NonPublic | BindingFlags.Instance);

            if (privateField != null )
            {
                Console.WriteLine($"\nOriginal value of field: {privateField.GetValue}");

                privateField.SetValue(obj, "1488");
                Console.WriteLine($"New value of field: {privateField.GetValue}");
            }
        }
    }
}