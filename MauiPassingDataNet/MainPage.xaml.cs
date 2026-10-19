namespace MauiPassingDataNet;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAdditionClicked(object sender, EventArgs e)
    {
        await OpenResultPage("Addition");
    }

    private async void OnSubtractionClicked(object sender, EventArgs e)
    {
        await OpenResultPage("Subtraction");
    }

    private async Task OpenResultPage(string operation)
    {
        MessageLabel.Text = string.Empty;

        if (string.IsNullOrWhiteSpace(FirstValueEntry.Text) ||
            string.IsNullOrWhiteSpace(SecondValueEntry.Text))
        {
            MessageLabel.Text = operation == "Addition"
                ? "Please enter values for both fields to get the sum"
                : "Please enter values for both fields to get the difference";

            return;
        }

        if (!decimal.TryParse(FirstValueEntry.Text, out decimal firstValue) ||
            !decimal.TryParse(SecondValueEntry.Text, out decimal secondValue))
        {
            MessageLabel.Text = "Please enter valid numbers in both fields";
            return;
        }

        try
        {
            decimal result = operation == "Addition"
                ? firstValue + secondValue
                : firstValue - secondValue;

            await Navigation.PushAsync(
                new SecondPage(firstValue, secondValue, operation, result));
        }
        catch (OverflowException)
        {
            MessageLabel.Text =
                "The result is too large. Please enter smaller values.";
        }
    }
}