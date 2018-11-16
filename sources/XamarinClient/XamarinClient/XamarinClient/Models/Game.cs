namespace XamarinClient.Models
{
    public class Game : RaisePropertyChangeModel
    {
        private string _pos1;

        private string _pos2;

        private string _pos3;

        private string _pos4;

        private string _pos5;

        private string _pos6;

        private string _pos7;


        private string _pos8;

        private string _pos9;

        private GameState _gameState;

        public GameState GameState
        {
            get { return _gameState; }
            set { _gameState = value; }
        }


        public Game(User user)
        {
            User = user;

            GameState = GameState.New;
        }

        public User User { get; }

        public string NextPlayerId { get; set; }

        public string Pos1
        {
            get => _pos1;
            set
            {
                _pos1 = value;
                OnPropertyChanged(nameof(Pos1));
            }
        }

        public string Pos2
        {
            get => _pos2;
            set
            {
                _pos2 = value;
                OnPropertyChanged(nameof(Pos2));
            }
        }

        public string Pos3
        {
            get => _pos3;
            set
            {
                _pos3 = value;
                OnPropertyChanged(nameof(Pos3));
            }
        }

        public string Pos4
        {
            get => _pos4;
            set
            {
                _pos4 = value;
                OnPropertyChanged(nameof(Pos4));
            }
        }

        public string Pos5
        {
            get => _pos5;
            set
            {
                _pos5 = value;
                OnPropertyChanged(nameof(Pos5));
            }
        }

        public string Pos6
        {
            get => _pos6;
            set
            {
                _pos6 = value;
                OnPropertyChanged(nameof(Pos6));
            }
        }

        public string Pos7
        {
            get => _pos7;
            set
            {
                _pos7 = value;
                OnPropertyChanged(nameof(Pos7));
            }
        }

        public string Pos8
        {
            get => _pos8;
            set
            {
                _pos8 = value;
                OnPropertyChanged(nameof(Pos8));
            }
        }

        public string Pos9
        {
            get => _pos9;
            set
            {
                _pos9 = value;
                OnPropertyChanged(nameof(Pos9));
            }
        }

        public string Board { get; set; }

        private string _stateMessage;

        public string StateMessage
        {
            get { return _stateMessage; }
            set
            {
                _stateMessage = value; 
                OnPropertyChanged(nameof(StateMessage));
            }
        }

    }
}