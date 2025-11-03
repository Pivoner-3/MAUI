namespace Laba18_MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
            this.BackgroundColor = Colors.White;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private void OnCounterClicked1(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn1.Text = $"Clicked {count} time";
            else
                CounterBtn1.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
