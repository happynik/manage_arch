using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class InviromentBuild
    {
        [DataMember(Name = "instructions")]
        public Component[] Instructions { get; set; }

        [DataMember(Name = "components")]
        public Component[] Components { get; set; }
    }
}