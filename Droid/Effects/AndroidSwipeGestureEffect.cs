using System;
using System.Diagnostics;
using Android.Views;
using SwipeGesture.Droid.Effects;
using SwipeGesture.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.View;

[assembly: ResolutionGroupName("Ricky")]
[assembly: ExportEffect(typeof(AndroidSwipeGestureEffect), "SwipeGestureEffect")]
namespace SwipeGesture.Droid.Effects
{
    public class AndroidSwipeGestureEffect : PlatformEffect
    {
        MyTouchListener touchListener;
        protected override void OnAttached()
        {
            touchListener = new MyTouchListener();
            var numberOfTouches = (int)SwipeGestureEffect.GetNumberOfTouches(Element);
            touchListener.NumberOfTouch = numberOfTouches;
            touchListener.InvokeSwipeDetected += TouchListener_InvokeSwipeDetected;
            this.Container.SetOnTouchListener(touchListener);
        }

        protected override void OnDetached()
        {
            touchListener.InvokeSwipeDetected = null;
        }

        private void TouchListener_InvokeSwipeDetected()
        {
            InvokeSwipeEvent();
        }

        private void InvokeSwipeEvent()
        {
            var command = SwipeGestureEffect.GetCommand(Element);
            if (command != null)
                command.Execute(SwipeGestureEffect.GetCommandParameter(Element));
        }


        public class MyTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
        {
            public int NumberOfTouch { get; set; }
            public Action InvokeSwipeDetected { get; set; }

            int startPositionX = 0;
            int currentPositionX = 0;
            int minDistance = 200;
            public bool OnTouch(Android.Views.View v, MotionEvent e)
            {
                HandleTouch(e);
                return true;
            }

            private void HandleTouch(MotionEvent m)
            {
                int pointerCount = m.PointerCount;
                if (pointerCount == NumberOfTouch)
                {
                    var action = m.ActionMasked;
                    int actionIndex = m.ActionIndex;
                    switch (action)
                    {
                        case MotionEventActions.Down:
                            startPositionX = (int)m.GetX();
                            break;
                        case MotionEventActions.Up:
                            currentPositionX = 0;
                            break;
                        case MotionEventActions.Move:
                            currentPositionX = (int)m.GetX();
                            int diff = startPositionX - currentPositionX;
                            if (Math.Abs(diff) > minDistance)
                            {
                                InvokeSwipeDetected?.Invoke();
                            }
                            break;
                        case MotionEventActions.PointerDown:
                            startPositionX = (int)m.GetX();
                            break;
                    }
                    pointerCount = 0;
                }
                else
                {
                    startPositionX = 0;
                    currentPositionX = 0;
                }
            }
        }
    }
}
