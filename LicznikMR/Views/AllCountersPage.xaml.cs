using LicznikMR.Models;

namespace LicznikMR.Views;

public partial class AllCountersPage : ContentPage
{
    public AllCountersPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllCounters();
    }

    protected override void OnAppearing()
    {
        ((Models.AllCounters)BindingContext).LoadCounters();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CounterPage));
    }

    private void Plus_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        Models.Counter counter =
            (Models.Counter)button.CommandParameter;

        counter.Value++;

        SaveCounter(counter);
    }

    private void Minus_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        Models.Counter counter =
            (Models.Counter)button.CommandParameter;

        counter.Value--;

        SaveCounter(counter);
    }
    private void SaveCounter(Models.Counter counter)
    {
        File.WriteAllText(
            counter.Filename,
            counter.Name + Environment.NewLine + counter.Value
        );

        ((Models.AllCounters)BindingContext).LoadCounters();
    }
}