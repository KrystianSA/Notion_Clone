using Newtonsoft.Json;

namespace Notion_Clone.Extensions
{
    public static class DataSerializerToJson
    {
        public static string Serialize(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
