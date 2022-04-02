using Microservice.Core.Utilities.ReturnData.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microservice.Core.Utilities.ReturnData
{
    public class ReturnData<T>
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ReturnDataStatusEnum Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public DateTime ServerTime { get; set; } = DateTime.Now;
    }
}
