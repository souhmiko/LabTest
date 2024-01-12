namespace LabTest;

public partial class Q2 : ContentPage
{
	public Q2()
	{
		InitializeComponent();
	}

    private void OnPhoneEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // Validate phone number
        bool isValidPhoneNumber = !string.IsNullOrWhiteSpace(e.NewTextValue) && e.NewTextValue.All(char.IsDigit);

        InvalidPhoneLabel.IsVisible = !isValidPhoneNumber;
        UpdateRegisterButtonEnabled();
    }

    private void OnPasswordEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // Validate password length
        bool isValidPassword = e.NewTextValue.Length > 5;

        InvalidPasswordLabel.IsVisible = !isValidPassword;
        UpdateRegisterButtonEnabled();
    }

    private void OnCheckboxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Checkbox changed, update Register button state
        UpdateRegisterButtonEnabled();
    }

    private void UpdateRegisterButtonEnabled()
    {
        // Enable Register button only if phone number is valid, password is valid, and checkbox is checked
        RegisterButton.IsEnabled = !InvalidPhoneLabel.IsVisible && !InvalidPasswordLabel.IsVisible && TermandConditionCheckbox.IsChecked;
    }

    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Handle Register button click
        // Add your registration logic?here
    }

    private async void OnGoToQ3Clicked(object sender, EventArgs e)
    {
        // Navigate to Q3 page
        await Shell.Current.GoToAsync("//Q3");
    }
}