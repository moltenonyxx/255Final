using Org.W3c.Dom;
using QuestLog;

namespace CITA255Final;

public partial class GameListPage : ContentPage
{
    public Game SelectedGame { get; set; }
    public GameListPage()
	{
        InitializeComponent();
	}

    private void OnGameSelected(object sender, SelectionChangedEventArgs e)
    {
        SelectedGame = e.CurrentSelection.FirstOrDefault() as Game;
    }

    public void ClearSelection()
    {
        GameList.SelectedItem = null;
        SelectedGame = null;
    }
}