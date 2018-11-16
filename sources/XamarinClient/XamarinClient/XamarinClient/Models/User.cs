namespace XamarinClient.Models
{
    public class User : RaisePropertyChangeModel
    {
        private string _userName;
        private string _id;

        public string Name
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value; 
                OnPropertyChanged(nameof(Id));
            }
        }
    }
}