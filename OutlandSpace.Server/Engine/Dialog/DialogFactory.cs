using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Dialog
{
    public class DialogFactory: IDialogFactory
    {
        JsonSerializer serializer = new JsonSerializer();
        

        public DialogFactory()
        {
        }

        public IDialog GetDialog(string body)
        {
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            IDialog result = JsonConvert.DeserializeObject<CommonDialog>(value: body);

            return result;
        }
    }
}
