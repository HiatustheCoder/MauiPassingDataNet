namespace MauiPassingDataNet;

public partial class SecondPage : ContentPage
{
    public SecondPage(
        decimal firstValue,
        decimal secondValue,
        string operation,
        decimal result)
    {
        InitializeComponent();

        NumbersLabel.Text =
            $"The numbers entered are {firstValue} and {secondValue}.";

        ResultLabel.Text = operation == "Addition"
            ? $"The sum of the numbers is {result}"
            : $"The difference of the numbers is {result}";
    }

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}