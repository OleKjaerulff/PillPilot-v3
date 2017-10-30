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
    [Activity(Label = "TimePickerTwoActivity")]
    public class TimePickerTwoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TimePickerTwoLayout);

            TimePicker timePickerTwo = FindViewById<TimePicker>(Resource.Id.timePickerTwo);
            Button TimePickerTwoDone = FindViewById<Button>(Resource.Id.TimePickerTwoDone);

            timePickerTwo.SetIs24HourView(Java.Lang.Boolean.True);
            timePickerTwo.Hour = 24;
            timePickerTwo.Minute = 0;
            TimePickerTwoDone.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                int hh = timePickerTwo.Hour;
                int mm = timePickerTwo.Minute;
                UserData.middagAlarm1Text = timePickerTwo.Hour.ToString("D2") + ":" + timePickerTwo.Minute.ToString("D2");
            };
        }
    }
}