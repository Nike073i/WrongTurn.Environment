using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WrongTurn.StateManagement.Actions.Base;

namespace WrongTurn.API.Converters
{
    public class PlayerActionConverter : JsonConverter<IEnumerable<IPlayerAction>>
    {
        public override IEnumerable<IPlayerAction>? ReadJson(JsonReader reader, Type objectType, IEnumerable<IPlayerAction>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var assembly = typeof(IPlayerAction).Assembly;
            var jsonActions = JArray.Load(reader);
            var listActions = new List<IPlayerAction>();
            foreach (var item in jsonActions.Children<JObject>())
            {
                var type = assembly.GetType(item["type"].ToString());
                var action = item["object"].ToObject(type);
                listActions.Add(action as IPlayerAction);
            }
            return listActions;
        }

        public override void WriteJson(JsonWriter writer, IEnumerable<IPlayerAction>? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
