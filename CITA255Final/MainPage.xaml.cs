using Javax.Xml.Transform;
using QuestLog;
using System.Collections.ObjectModel;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
namespace CITA255Final
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Game> gameList { get; } = new ObservableCollection<Game>();

        Game[] pool =
        {
           new Game {Title = "Clear the cellar rats", Giver = "Shopkeep", Reward = 5 },
           new Game {Title = "Escort the merchant to Dunmoor", Giver="The Wizard", Reward = 25 }
        };

        int next = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Load();
        }

        string path = Path.Combine(FileSystem.AppDataDirectory, "gamelist.json");
        void Save()
        {
            string json = JsonSerializer.Serialize(gameList);
            File.WriteAllText(path, json);
        }
        void Load()
        {
            if (!File.Exists(path)) return;
            string json = File.ReadAllText(path);
            List<Game> saved =
            JsonSerializer.Deserialize<List<Game>>(json);
            foreach (Game q in saved)
                gameList.Add(q);
            
        }

        private async void onDetailsClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("gameDesc");
        }

        private async void onAddGame(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("addGame");
            Game template = pool[next];
            gameList.Add(item: new Game
            {
                Title = template.Title,
                Giver = template.Giver,
                Reward = template.Reward
            });
            Save();
        }
    }
}
