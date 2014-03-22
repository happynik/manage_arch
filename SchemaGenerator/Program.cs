using System;
using System.IO;
using Newtonsoft.Json;

namespace SchemaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin schema generated");
            Console.WriteLine();

            Console.WriteLine("Generation");
            var generator = new SchemaGenerator("database.json");
            var schemaResult = generator.GenerateSchema("Instruction0");
            Console.WriteLine();

            Console.WriteLine("Save schema file");
            using (var file = File.CreateText("schema.json"))
            {
                var componentString = JsonConvert.SerializeObject(new { schema = schemaResult });
                file.Write(componentString);
            }
        }
    }
}
