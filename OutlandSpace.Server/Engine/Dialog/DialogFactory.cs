using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Dialog
{
    public class DialogFactory: IDialogFactory
    {
        private JsonSerializer serializer = new();

        public DialogsStorage Initialize(string rootFolder = "Data")
        {            
            var dialogs = new List<IDialog>();

            dialogs.AddRange(Universe.Tools.ResourceLoader<CommonDialog>.LoadFromFolder(
                Path.Combine(Environment.CurrentDirectory, rootFolder, "Dialogs")
                ));

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
