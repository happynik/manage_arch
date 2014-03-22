using System;
using System.Threading;
using Core;

namespace TestGenerator
{
    public class TestGenerator
    {
        private const int RolesCount = 20;
        private const int ComponentRolesMaxCount = 5;
        private const int ComponentDependenciesMaxCount = 20;

        public Component Generate(string name, bool isExecute)
        {
            Thread.Sleep(100);
            var rnd = new Random();
            var currentComponent = new Component(name, isExecute)
                                    {
                                        Roles = new string[rnd.Next(1, ComponentRolesMaxCount)],
                                        Dependencies = new string[rnd.Next(isExecute ? 1 : 0, ComponentDependenciesMaxCount)]
                                    };
            if (isExecute)
            {
                currentComponent.Roles = null;
            }
            else
            {
                for (var i = 0; i < currentComponent.Roles.Length; i++)
                {
                    currentComponent.Roles[i] = "R" + rnd.Next(RolesCount);
                }
            }

            for (var i = 0; i < currentComponent.Dependencies.Length; i++)
            {
                currentComponent.Dependencies[i] = "R" + rnd.Next(i, RolesCount);
            }

            Console.WriteLine(currentComponent.Name + " Complete");
            return currentComponent;
        }
    }
}