using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace MyBlockNoteTry1
{
    public class TxtFile : EditorFile
    {
        public TxtFile() : base() { }

        public override bool OpenFile()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text File | *.txt";
            if (open.ShowDialog() == true)
            {
                try
                {
                    this.FileName = open.FileName;
                    this.Contents = File.ReadAllText(this.FileName);
                    this._saved = true;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return false;
        }

        public override bool WriteFile()
        {
            try
            {
                File.WriteAllText(_fileName, _contents);
                this._saved = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public override bool SaveCheck()
        {
            if (Contents.Length > 0 && this._saved == false)
            {
                string messageBoxText = "Do you want to save changes to file?";
                string caption = "BlocknoteForPoor";
                MessageBoxButton msgboxbutton = MessageBoxButton.YesNoCancel;

                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, msgboxbutton);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        return SaveFile();
                    case MessageBoxResult.No:
                        return true;
                    case MessageBoxResult.Cancel:
                        return false;
                }
                return false;
            }
            return true;
        }

        public override bool SaveFile(bool newFile = false)
        {

            if (this.FileName.Length > 0 && this.FileName != "Nameless" && newFile)
            {
                return WriteFile();
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text File | *.txt";
                if (save.ShowDialog() == true)
                {
                    this.FileName = save.FileName;
                    return WriteFile();
                }
                return false;
            }
        }
    }
}
