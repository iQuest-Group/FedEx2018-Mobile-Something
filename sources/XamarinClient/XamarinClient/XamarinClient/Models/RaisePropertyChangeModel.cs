using System.ComponentModel;
using System.Runtime.CompilerServices;
using XamarinClient.Annotations;

namespace XamarinClient.Models
{
    public class RaisePropertyChangeModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}