using Android.App;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Android.Widget;
using Android.Content;
using Android.Graphics;

namespace mecanumWheelRobot.service
{
    public class toast
    {
        public void toastCustom(string msg, string bgColor, string textColor)
        {
            Context context = Android.App.Application.Context;
            ToastLength duration = ToastLength.Short;

            Toast.MakeText(context, msg, duration).Show();
        }

        public static void toastMessage(string msg)
        {
            Context context = Android.App.Application.Context;
            ToastLength duration = ToastLength.Short;

            Toast.MakeText(context, msg, duration).Show();
        }

        public void toastWarning(string msg)
        {
            Context context = Android.App.Application.Context;
            ToastLength duration = ToastLength.Short;

            Toast.MakeText(context, msg, duration).Show();
        }

        public static void toastSuccess(string msg)
        {
            Context context = Android.App.Application.Context;
            ToastLength duration = ToastLength.Short;

            Toast.MakeText(context, msg, duration).Show();
        }

        public static void toastError(string msg)
        {
            Context context = Android.App.Application.Context;
            ToastLength duration = ToastLength.Short;

            Toast.MakeText(context, msg, duration).Show();
        }


    }
}
