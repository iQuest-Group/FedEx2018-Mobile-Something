using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinClient.Dto;
using XamarinClient.Models;
using XamarinClient.Pages;
using XamarinClient.Services;
using Timer = System.Timers.Timer;

namespace XamarinClient.ViewModels
{
    public class GameViewModel
    {
        private GameService _gameService;
        private Timer _gameTimer;
        public Game Game { get; }
        public INavigation Navigation { get; set; }

        public GameViewModel(User user)
        {
            Game = new Game(user);
            MakeMove = new Command(OnMakeMove);
            _gameService = new GameService();

            StartGameStatusListener();
        }

        private void StartGameStatusListener()
        {

            _gameTimer = new Timer(1000);
            _gameTimer.Elapsed += GameTimerOnElapsed;
            _gameTimer.Start();
        }

        private async void GameTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Game.StateMessage = "Waiting for opponent";
            GameStateDto gameState = await _gameService.GetGameStatus();
            UpdateGameState(gameState);
            RefreshUi();

            if (Game.GameState == GameState.InProgress && Game.User.Id == Game.NextPlayerId)
            {
                _gameTimer.Stop();
                Game.StateMessage = "Your turn";
            }

            if (Game.GameState == GameState.Finished)
            {
                try
                {
                    _gameTimer.Stop();

                    var message = gameState.Winner == Game.User.Id ? "Won" : "Lost";
                    await _gameService.Reset();

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.DisplayAlert("Game over", $"You {message}!", "Ok");
                        Navigation.PushModalAsync(new LoginPage(new LoginViewModel()));

                    });

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        private void RefreshUi()
        {
            var positions = Game.Board.Split(',').ToList();
            for (int i = 0; i < positions.Count; i++)
            {
                if (positions[i] == "1")
                {
                    Game.GetType().GetProperty($"Pos{i + 1}").SetValue(Game, "X");
                }
                if (positions[i] == "2")
                {
                    Game.GetType().GetProperty($"Pos{i + 1}").SetValue(Game, "O");
                }
            }
        }

        private async void OnMakeMove(object pos)
        {
            if (Game.GameState == GameState.InProgress && Game.User.Id == Game.NextPlayerId)
            {
                var position = int.Parse(pos.ToString()) - 1;
                int x = position % 3;
                int y = position / 3;
                var gameStateDto = await _gameService.MakeMove(new MoveDto
                {
                    PlayerId = Game.User.Id,
                    X = x,
                    Y = y
                });

                UpdateGameState(gameStateDto);
                RefreshUi();

                _gameTimer.Start();

            }
            //Game.GetType().GetProperty($"Pos{pos}").SetValue(Game, "O");
        }

        private void UpdateGameState(GameStateDto gameStateDto)
        {
            Game.GameState = gameStateDto.GameState;
            Game.NextPlayerId = gameStateDto.NextPlayer;
            Game.Board = gameStateDto.Board;
        }


        public ICommand MakeMove { get; set; }
    }
}
