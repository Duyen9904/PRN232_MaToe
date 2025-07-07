using System.Text.Json.Serialization;
using System.Text.Json;

namespace DrugPrevention.SoapApiServices.DuyenCTT
{
    public static class JsonMapper
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true
        };

        public static TTarget Map<TSource, TTarget>(TSource source)
        {
            var json = JsonSerializer.Serialize(source, _options);
            return JsonSerializer.Deserialize<TTarget>(json, _options);
        }
    }
}
