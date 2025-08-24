using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoList.Enums
{
    public enum PriorityLevel
    {
        [JsonStringEnumMemberName( "低")]
        Low,

        [JsonStringEnumMemberName("中")]
        Medium,

        [JsonStringEnumMemberName("高")]
        High
    }
}
