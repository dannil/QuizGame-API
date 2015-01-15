using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace QuizGame.API
{
    /// <summary>
    /// Class which converts our objects to a JSON presentation.
    /// </summary>
    public class JsonSerializer
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        };

        public string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, settings);
        }

        public class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }
    }
}
