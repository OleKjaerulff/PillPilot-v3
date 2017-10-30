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
    [Activity(Label = "TimePickerThreeActivity")]
    public class TimePickerThreeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TimePickerThreeLayout);

            TimePicker timePickerThree = FindViewById<TimePicker>(Resource.Id.timePickerThree);
            Button TimePickerThreeDone = FindViewById<Button>(Resource.Id.timePickerThreeDone);

            timePickerThree.SetIs24HourView(Java.Lang.Boolean.True);
            timePickerThree.Hour = 24;
            timePickerThree.Minute = 0;

            TimePickerThreeDone.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                int hh = timePickerThree.Hour;
                int mm = timePickerThree.Minute;
                UserData.aftenAlarm1Text = timePickerThree.Hour.ToString("D2") + ":" + timePickerThree.Minute.ToString("D2");
            };
        }
    }
}