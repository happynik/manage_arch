using System;
using System.IO;
using System.Linq;
using Core;
using Newtonsoft.Json;

namespace SchemaGenerator
{
    public class SchemaGenerator
    {
        private readonly InviromentBuild _db;
        public SchemaGenerator(string dbName)
        {
            using (var dbReader = new StreamReader(File.Open(dbName, FileMode.Open)))
            {
                var dbstring = dbReader.ReadToEnd();
                _db = JsonConvert.DeserializeObject<InviromentBuild>(dbstring);
            }
        }

        public Schema GenerateSchema(string instructionName)
        {
            var instruction = _db.Instructions.FirstOrDefault(i => i.Name == instructionName);
            if (instruction == null)
            {
                throw new Exception("нет такой инструкции");
            }

            var schema = new Schema();
            //ResolvedAlgorithm.SimpleResolved(instruction, ref schema);
            FindDependencies(instruction, ref schema);
            return schema;
        }

        private void FindDependencies(Component instruction, ref Schema schema)
        {
            var dependencies = instruction.Dependencies;
            foreach (var dependency in dependencies)
            {
                var componentTo = FindComponent(dependency);
                schema.Components.Add(componentTo.Name);
                schema.AddConnection(instruction.Name, dependency, componentTo.Name);

                FindDependencies(componentTo, ref schema);
            }
        }

        private Component FindComponent(string role)
        {
            var components = _db.Components.Where(c => c.Roles.Contains(role)).ToList();
            if (components == null)
            {
                throw new Exception("не хватает компонент");
            }
            
            return ResolvedAlgorithm.SimpleResolved(components);
        }
    }
}