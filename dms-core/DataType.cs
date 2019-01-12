using Manatee.Json;
using Manatee.Json.Schema;
using Manatee.Json.Serialization;

namespace Dms.Core
{
    public class DataType
    {
        public static JsonSerializer _serializer = new JsonSerializer();
        public JsonSchema Schema;

        public DataType(string jsonSchema)
        {
            Schema = _serializer.Deserialize<JsonSchema>(JsonValue.Parse(jsonSchema));
        }
    }
}