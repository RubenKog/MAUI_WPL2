using ClassLibTeam10.Business;
using ClassLibTeam10.Business.Entities;
using Newtonsoft.Json;
using Plugin.Maui.Audio;

namespace MauiGameApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IAudioManager audioManager;
        List<Game> gameList = new List<Game>();
        
        
        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            this.audioManager = audioManager;
        }
               
        private async void LoadData(object sender, EventArgs e)
        {
            try
            {
                RestService restService = new RestService();
                gameList = await restService.getGames();                
                GameListV.ItemsSource = gameList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }
        private async void PlayMusic(object sender, EventArgs e)
        {            
            
            var musicPlayer = audioManager.CreatePlayer( await FileSystem.OpenAppPackageFileAsync(((Button)sender).CommandParameter.ToString()));
            musicPlayer.Play();
        }


    }
}