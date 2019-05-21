using System;

namespace NoteBookPlugIn
{
    public class PlugToUpper : MyNoteBookPlugInterfaceProject.IPlugIn
    {

        public string ProcessText(string text)
        {
            return text.ToUpper();
        }
    }
}