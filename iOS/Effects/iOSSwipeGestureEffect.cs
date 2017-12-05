using System;
using SwipeGesture.Effects;
using SwipeGesture.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Ricky")]
[assembly: ExportEffect(typeof(iOSSwipeGestureEffect), "SwipeGestureEffect")]
namespace SwipeGesture.iOS.Effects
{
    public class iOSSwipeGestureEffect : PlatformEffect
    {
        UISwipeGestureRecognizer uiSwipeGestureRecognizer;

        protected override void OnAttached()
        {
            var numberOfTouches = (int)SwipeGestureEffect.GetNumberOfTouches(Element);

            uiSwipeGestureRecognizer = new UISwipeGestureRecognizer(InvokeSwipeEvent);
            uiSwipeGestureRecognizer.NumberOfTouchesRequired = (uint)numberOfTouches;
            this.Container.AddGestureRecognizer(uiSwipeGestureRecognizer);

        }
        protected override void OnDetached()
        {
            
        }

        public void InvokeSwipeEvent()
        {
            var command = SwipeGestureEffect.GetCommand(Element);
            if (command != null)
                command.Execute(SwipeGestureEffect.GetCommandParameter(Element));
        }
    }
}
