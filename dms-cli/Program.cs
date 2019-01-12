using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dms.Core;
using Dms.Core.FileSystemRepository;
using Manatee.Json;
using Manatee.Json.Schema;
using Manatee.Json.Serialization;

namespace Dms.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonValue boolJson = true;
            JsonValue stringJson = "Anand";
            JsonValue numJson = 100.848;

            var json = new JsonObject
            {
                {"boolean", true},
                {"number", 42},
                {"string", "a string"},
                {"null", JsonValue.Null},
                {"array", new JsonArray {6.7, true, "a value"}},
                {"object", new JsonObject
                    {
                        {"aKey", 42},
                        {"anotherKey", false}
                    }
                }
            };

            var joe = new Child { Name = "Joe" };
            var sue = new Child { Name = "Sue" };
            var alex = new Parent
            {
                Name = "Alex",
                Children = new[] { joe, sue, joe }
            };

            JsonSerializer serializer = new JsonSerializer();
            var alexJson = serializer.Serialize(alex);
            Console.WriteLine(alexJson);

            var objJson = serializer.Deserialize<Parent>(alexJson);

            // JSON Schema
            var text = File.ReadAllText("parent-schema.json");
            
            var testJson = File.ReadAllText("parent.json");
            var testValue = JsonValue.Parse(testJson);
            var o = serializer.Deserialize(typeof(object), testValue);

            DataType parentType = new DataType(text);

            var schemaJson = JsonValue.Parse(text);
            var parentSchema = serializer.Deserialize<JsonSchema>(schemaJson);
            JsonSchemaOptions.OutputFormat = SchemaValidationOutputFormat.Hierarchy;

            var result = parentSchema.Validate(alexJson);

            Console.WriteLine($"{alexJson}");
        }
    }

    class Child
    {
        public string Name { get; set; }
    }

    class Parent
    {
        public string Name { get; set; }
        public IEnumerable<Child> Children { get; set; }
    }
}
