namespace XamarinClient.Models
{
    public class User : RaisePropertyChangeModel
    {
        private string _userName;

        public string Username
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(Username));
            }
        }
    }
}