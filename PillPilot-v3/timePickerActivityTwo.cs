using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PillPilot_v3
{
    [Activity(Label = "timePickerActivityTwo")]
    public class timePickerActivityTwo : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TimePickerTwoLayout);
            // Create your application here
        }
    }
}