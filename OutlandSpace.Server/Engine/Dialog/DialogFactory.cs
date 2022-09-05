using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Dialog
{
    public class DialogFactory: IDialogFactory
    {
        private JsonSerializer serializer = new JsonSerializer();

        public DialogsStorage Initialize(string dialogsRootFolder = "Data")
        {            
            var dialogs = new List<IDialog>();

            foreach (var fileContent in Universe.Tools.FilesFactory.GetFilesContentFromDirectory(dialogsRootFolder + @"/Dialogs"))
            {
                var jsonDialogs = JsonConvert.DeserializeObject<List<CommonDialog>>(value: fileContent);
                dialogs.AddRange(jsonDialogs);
            }

            return new DialogsStorage(dialogs);
        }

        public IDialog ParseDialog(string body)
        {
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            IDialog result = JsonConvert.DeserializeObject<CommonDialog>(value: body);

            return result;
        }

        
    }
}
