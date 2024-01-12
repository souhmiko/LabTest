namespace LabTest
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGoToQ2Clicked(object sender, EventArgs e)
        {
            // Navigate to Q2 page
            await Shell.Current.GoToAsync("//Q2");
        }

    }

}
