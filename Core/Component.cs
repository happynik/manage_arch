using System;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class Component
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "isExecute")]
        public bool IsExecute { get; set; }

        [DataMember(Name = "roles")]
        public string[] Roles { get; set; }

        [DataMember(Name = "dependencies")]
        public string[] Dependencies { get; set; }

        public int DependenciesCount { get { return Dependencies.Length; } }

        public Component() : this("", false)
        {
            
        }

       public Component(string name, bool isExecute)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
            IsExecute = isExecute;
        }
    }
}