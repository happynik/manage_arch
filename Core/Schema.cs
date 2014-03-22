using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class Schema
    {
        [DataMember(Name = "components")]
        public List<string> Components { get; set; }

        [DataMember(Name = "connections")]
        public List<Connection> Connections { get; set; }

        public Schema()
        {
            Components = new List<string>();
            Connections = new List<Connection>();
        }

        public void AddConnection(string componentFrom, string role, string componentTo)
        {
            Connections.Add(new Connection {ComponentFrom = componentFrom, Role = role, ComponentTo = componentTo});
        }
    }
}