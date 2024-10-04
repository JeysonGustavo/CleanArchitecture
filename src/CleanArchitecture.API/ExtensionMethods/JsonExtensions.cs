using System.Text.Json;

namespace CleanArchitecture.ExtensionMethods
{
    public static class JsonExtensions
    {
        public static string ObjectToJson<T>(this T obj) => JsonSerializer.Serialize(obj);

        public static T? JsonToObject<T>(this string json) => JsonSerializer.Deserialize<T>(json);
    }
}
