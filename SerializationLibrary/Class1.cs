using System.Text.Json;

namespace SerializationLibrary
{
    public static class Serializer
    {
        public static string Serialize<T>(T data)
        {
            var jsonString = JsonSerializer.Serialize(data);
            return jsonString;
        }

        public static T Deserialize<T>(string jsonString)
        {
            var data = JsonSerializer.Deserialize<T>(jsonString);
            return data;
        }
    }
}
