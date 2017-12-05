using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SwipeGesture.Effects
{
    public class SwipeGestureEffect : RoutingEffect
    {
        public SwipeGestureEffect() : base("Ricky.SwipeGestureEffect")
        {
        }

        public static readonly BindableProperty NumberOfTouchesProperty =
            BindableProperty.CreateAttached("NumberOfTouches", typeof(double), typeof(SwipeGestureEffect), 1.0);

        public static readonly BindableProperty CommandProperty =
            BindableProperty.CreateAttached("Command", typeof(ICommand), typeof(SwipeGestureEffect), (object)null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.CreateAttached("CommandParameter", typeof(object), typeof(SwipeGestureEffect), (object)null);

        public static double GetNumberOfTouches(BindableObject view)
        {
            return (double)view.GetValue(NumberOfTouchesProperty);
        }

        public static void SetNumberOfTouches(BindableObject view, double value)
        {
            view.SetValue(NumberOfTouchesProperty, value);
        }

        public static Command GetCommand(BindableObject view)
        {
            return (Command)view.GetValue(CommandProperty);
        }

        public static void SetCommand(BindableObject view, bool value)
        {
            view.SetValue(CommandProperty, value);
        }

        public static object GetCommandParameter(BindableObject view)
        {
            return view.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(BindableObject view, bool value)
        {
            view.SetValue(CommandParameterProperty, value);
        }
    }
}
