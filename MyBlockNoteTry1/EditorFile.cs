using System.ComponentModel;

namespace MyBlockNoteTry1
{
    public abstract class EditorFile : INotifyPropertyChanged
    {
        private protected string _fileName;
        private protected string _contents;
        private protected bool _saved = true;

        public EditorFile() 
        { 
            _fileName = "Nameless";
            _contents = "";
        }

        public abstract bool SaveFile(bool newFile = false);

        public abstract bool WriteFile();

        public abstract bool SaveCheck();

        public abstract bool OpenFile();

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public string Contents
        {
            get { return _contents; }
            set
            {
                _contents = value;
                this._saved = true;
                OnPropertyChanged("Contents");
            }
        }

        private string _fontFamily;
        public string FontFamily
        {
            get
            {
                return _fontFamily;
            }
            set
            {
                _fontFamily = value;
                OnPropertyChanged("FontFamily");
            }
        }

        private double _fontSize;
        public double FontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
