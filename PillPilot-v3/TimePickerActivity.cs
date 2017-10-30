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
using Android.Text.Format;

namespace PillPilot_v3
{
    [Activity(Label = "TimePickerActivity")]
    public class TimePickerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TimePickerLayout);

            //UserData.middagAlarm1Text = "20:99";

            TimePicker timePicker = FindViewById<TimePicker>(Resource.Id.timePicker);
            Button TimePickerDone = FindViewById<Button>(Resource.Id.TimePickerDone);
          
            timePicker.Hour = 24;
            timePicker.Minute = 0;
            timePicker.Is24HourView();
            TimePickerDone.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                int hh = timePicker.Hour;
                int mm = timePicker.Minute;
                UserData.middagAlarm1Text = hh.ToString()+":"+mm.ToString();


            };



        }
    }
}