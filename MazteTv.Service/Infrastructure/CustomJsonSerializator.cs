using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace MazteTv.Service.Infrastructure
{
    public class CustomJsonSerializator : ICustomJsonSerializator
    {
        private readonly JsonSerializerOptions options;
        public CustomJsonSerializator()
        {
        }
        public CustomJsonSerializator(JsonSerializerOptions options)
        {
            this.options = options;
        }
        public Task<string> Serialize(object obj)
        {
            var serializationSettings = options ?? GetJsonSerializerOptions();
            var result = JsonSerializer.Serialize(obj, serializationSettings);
            return Task.FromResult(result);
        }

        public Task Serialize(Stream writer, object value, Type type)
        {
            return JsonSerializer.SerializeAsync(writer, value, type);
        }

        public Task<T> Deserialize<T>(string value)
        {
            try
            {
                var serializationSettings = options ?? GetJsonSerializerOptions();
                var result = JsonSerializer.Deserialize<T>(value, serializationSettings);
                return Task.FromResult(result);
            }
            catch (JsonException ex)
            {
                throw ex;
            }
        }

        public Task<object> Deserialize(Stream reader, Type type)
        {
            var result = JsonSerializer.Deserialize(reader, type);
            return Task.FromResult<object>(result);
        }

        public static JsonSerializerOptions GetJsonSerializerOptions()
        {
            var serializerSettings = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                WriteIndented = true,
                PropertyNamingPolicy = null,
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                IgnoreNullValues = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            };
            return serializerSettings;
        }
    }
}
