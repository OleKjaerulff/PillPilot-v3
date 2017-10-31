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
using Android.Preferences;

namespace PillPilot_v3
{
    [Activity(Label = "TimePickerActivity")]
    public class TimePickerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TimePickerLayout);

            TimePicker timePicker = FindViewById<TimePicker>(Resource.Id.timePicker);
            Button TimePickerDone = FindViewById<Button>(Resource.Id.TimePickerDone);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
            ISharedPreferencesEditor editor = prefs.Edit();

            timePicker.SetIs24HourView(Java.Lang.Boolean.True);
            timePicker.Hour = 24;
            timePicker.Minute = 0;

            TimePickerDone.Click += (object sender, EventArgs e) =>
            {

                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    int hh = timePicker.Hour;
                    int mm = timePicker.Minute;
                    UserData.morgenAlarm1Text = timePicker.Hour.ToString("D2") + ":" + timePicker.Minute.ToString("D2");
                    editor.PutString("morgenAlarm1", UserData.morgenAlarm1Text);
                    editor.Apply();

            };

    }


    }
}