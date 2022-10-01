using System.Collections.Generic;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.UI.Prototype
{
    public class Global
    {
        public static IGameTurnSnapshot GetGameSnapshot()
        {

            return null;
        }

        public static IDialog GetDialog()
        {
            IDialog result = new CommonDialog(
                id: "x90adc8a-eca5-4c84-b4a1-682098bb4829",
                turn: 10,
                action: "window_dialog_common",
                exits: new List<DialogExit>
                {
                    new DialogExit("2c052641-3a37-451e-a593-198be707efa7", "Temporary text for dialog option selection 1", "xd35df2c-2018-4a90-8fd7-af3cc0b1f914"),
                    new DialogExit("3c052641-3a37-451e-a593-198be707efa7", "Temporary text for dialog option selection 2", "yd35df2c-2018-4a90-8fd7-af3cc0b1f914"),
                    new DialogExit("4c052641-3a37-451e-a593-198be707efa7", "Temporary text for dialog option selection 3", "zd35df2c-2018-4a90-8fd7-af3cc0b1f914")
                },
                text: "Good morning captain.\r\n\r\nDuring the training, I will tell you how to control the spacecraft, use rocket launchers and repair damaged compartments. Just follow my instructions and at the end of the training you will be able to stand up for yourself in our dangerous world. \r\n\r\nIn any case, you can try."
            );

            return result;
        }
    }
}