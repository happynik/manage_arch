using System;
using System.IO;
using Core;
using Newtonsoft.Json;

namespace TestGenerator
{
    class Program
    {
        private const int TestInstructionCount = 10;
        private const int TestCount = 100;

        static void Main(string[] args)
        {
            var generator = new TestGenerator();
            var ib = new InviromentBuild()
            {
                Instructions = new Component[TestInstructionCount],
                Components = new Component[TestCount],
            };

            for (int i = 0; i < TestInstructionCount; i++)
            {
                var instruction = generator.Generate("Instruction" + i, true);
                ib.Instructions[i] = instruction;
            }
            for (var i = 0; i < TestCount; i++)
            {
                var component = generator.Generate("Component" + i, false);
                ib.Components[i] = component;
            }

            using (var file = File.CreateText("database.json"))
            {
                var componentString = JsonConvert.SerializeObject(ib);
                file.Write(componentString);
            }
            Console.Read();
        }
    }
}
