namespace LicznikMR.Views;

public partial class CounterPage : ContentPage
{
    public CounterPage()
    {
        InitializeComponent();
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;

        int value = 0;

        int.TryParse(
            ValueEntry.Text,
            out value
        );

        string appDataPath = FileSystem.AppDataDirectory;

        string randomFileName =
            $"{Path.GetRandomFileName()}.counter.txt";

        string filename =
            Path.Combine(appDataPath, randomFileName);

        File.WriteAllText(
            filename,
            name + Environment.NewLine + value
        );

        await Shell.Current.GoToAsync("..");
    }
}