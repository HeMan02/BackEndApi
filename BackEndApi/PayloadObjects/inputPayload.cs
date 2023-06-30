using System.Globalization;
using System.Runtime.Serialization;

namespace BackEndApi.PayloadObjects
{
    public class inputPayload
    {

        [DataMember] public string inputText { get; set; }
    }
}
