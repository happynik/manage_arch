using System.Collections.Generic;
using System.Linq;
using Core;

namespace SchemaGenerator
{
    public static class ResolvedAlgorithm
    {
        public static Component SimpleResolved(IList<Component> components)
        {
            var minDependenciesCount = int.MaxValue;
            var minComponent = components.First();
            foreach (var component in components)
            {
                if (component.DependenciesCount < minDependenciesCount)
                {
                    minDependenciesCount = component.DependenciesCount;
                    minComponent = component;
                }
            }
            return minComponent;
        }

        public static void SimpleResolved(Component instruction, ref Schema schema)
        {
            var dependencies = instruction.Dependencies;
            foreach (var dependency in dependencies)
            {
                var componentTo = FindComponent(dependency);
                schema.Components.Add(componentTo.Name);
                schema.AddConnection(instruction.Name, dependency, componentTo.Name);

                SimpleResolved(componentTo, ref schema);
            }
        }
    }
}