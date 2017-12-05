using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwipeGesture
{
    public partial class SwipeGesturePage : ContentPage
    {
        public Command<object> SwipeCommand { get; set; }
        public SwipeGesturePage()
        {
            InitializeComponent();
            SwipeCommand = new Command<object>(SwipeEvent);
            BindingContext = this;
        }

        public async void SwipeEvent(object obj)
        {
            lblswipe.IsVisible = true;
            await Task.Delay(2000);
            lblswipe.IsVisible = false;
        }
    }
}
