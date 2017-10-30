using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Preferences;
using System;
using System.Timers;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.Media;
using Android.Content.PM;
using System.Threading;

namespace PillPilot_v3
{

    [Activity(Label = "PillPilot_v3", MainLauncher = true, ScreenOrientation = ScreenOrientation.Landscape)]
    //maybe later, for icon: [Activity(Label = "PillPilot_v3", MainLauncher = true, Icon = "@drawable/Icon", ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText morgenNavn1 = FindViewById<EditText>(Resource.Id.morgenNavn1);
            EditText morgenDosis1 = FindViewById<EditText>(Resource.Id.morgenDosis1);
            EditText morgenAntal1 = FindViewById<EditText>(Resource.Id.morgenAntal1);
            EditText morgenAlarm1 = FindViewById<EditText>(Resource.Id.morgenAlarm1);
            CheckBox morgenTaget1 = FindViewById<CheckBox>(Resource.Id.morgenTaget1);
            EditText morgenHvornår1 = FindViewById<EditText>(Resource.Id.morgenHvornår1);

            EditText morgenNavn2 = FindViewById<EditText>(Resource.Id.morgenNavn2);
            EditText morgenDosis2 = FindViewById<EditText>(Resource.Id.morgenDosis2);
            EditText morgenAntal2 = FindViewById<EditText>(Resource.Id.morgenAntal2);
            EditText morgenAlarm2 = FindViewById<EditText>(Resource.Id.morgenAlarm2);
            CheckBox morgenTaget2 = FindViewById<CheckBox>(Resource.Id.morgenTaget2);
            EditText morgenHvornår2 = FindViewById<EditText>(Resource.Id.morgenHvornår2);

            EditText middagNavn1 = FindViewById<EditText>(Resource.Id.middagNavn1);
            EditText middagDosis1 = FindViewById<EditText>(Resource.Id.middagDosis1);
            EditText middagAntal1 = FindViewById<EditText>(Resource.Id.middagAntal1);
            EditText middagAlarm1 = FindViewById<EditText>(Resource.Id.middagAlarm1);
            CheckBox middagTaget1 = FindViewById<CheckBox>(Resource.Id.middagTaget1);
            EditText middagHvornår1 = FindViewById<EditText>(Resource.Id.middagHvornår1);

            EditText middagNavn2 = FindViewById<EditText>(Resource.Id.middagNavn2);
            EditText middagDosis2 = FindViewById<EditText>(Resource.Id.middagDosis2);
            EditText middagAntal2 = FindViewById<EditText>(Resource.Id.middagAntal2);
            EditText middagAlarm2 = FindViewById<EditText>(Resource.Id.middagAlarm2);
            CheckBox middagTaget2 = FindViewById<CheckBox>(Resource.Id.middagTaget2);
            EditText middagHvornår2 = FindViewById<EditText>(Resource.Id.middagHvornår2);

            EditText aftenNavn1 = FindViewById<EditText>(Resource.Id.aftenNavn1);
            EditText aftenDosis1 = FindViewById<EditText>(Resource.Id.aftenDosis1);
            EditText aftenAntal1 = FindViewById<EditText>(Resource.Id.aftenAntal1);
            EditText aftenAlarm1 = FindViewById<EditText>(Resource.Id.aftenAlarm1);
            CheckBox aftenTaget1 = FindViewById<CheckBox>(Resource.Id.aftenTaget1);
            EditText aftenHvornår1 = FindViewById<EditText>(Resource.Id.aftenHvornår1);

            EditText aftenNavn2 = FindViewById<EditText>(Resource.Id.aftenNavn2);
            EditText aftenDosis2 = FindViewById<EditText>(Resource.Id.aftenDosis2);
            EditText aftenAntal2 = FindViewById<EditText>(Resource.Id.aftenAntal2);
            EditText aftenAlarm2 = FindViewById<EditText>(Resource.Id.aftenAlarm2);
            CheckBox aftenTaget2 = FindViewById<CheckBox>(Resource.Id.aftenTaget2);
            EditText aftenHvornår2 = FindViewById<EditText>(Resource.Id.aftenHvornår2);

            CheckBox checkBoxSTART = FindViewById<CheckBox>(Resource.Id.checkBoxSTART);

            MediaPlayer badinerie;
            badinerie = MediaPlayer.Create(this, Resource.Raw.Badinerie);

            MediaPlayer taagenLetter;
            taagenLetter = MediaPlayer.Create(this, Resource.Raw.TaagenLetter);

            MediaPlayer oSoleMio;
            oSoleMio = MediaPlayer.Create(this, Resource.Raw.OSoleMio);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();

            morgenNavn1.Text = prefs.GetString("morgenNavn1", "");
            morgenDosis1.Text = prefs.GetString("morgenDosis1", "");
            morgenAntal1.Text = prefs.GetString("morgenAntal1", "");
            morgenAlarm1.Text = prefs.GetString("morgenAlarm1", "");
            morgenHvornår1.Text = prefs.GetString("morgenHvornår1", "");

            morgenNavn2.Text = prefs.GetString("morgenNavn2", "");
            morgenDosis2.Text = prefs.GetString("morgenDosis2", "");
            morgenAntal2.Text = prefs.GetString("morgenAntal2", "");
            morgenAlarm2.Text = prefs.GetString("morgenAlarm2", "");
            morgenHvornår2.Text = prefs.GetString("morgenHvornår2", "");

            middagNavn1.Text = prefs.GetString("middagNavn1", "");
            middagDosis1.Text = prefs.GetString("middagDosis1", "");
            middagAntal1.Text = prefs.GetString("middagAntal1", "");
            middagAlarm1.Text = prefs.GetString("middagAlarm1", "");
            middagHvornår1.Text = prefs.GetString("middagHvornår1", "");

            middagNavn2.Text = prefs.GetString("middagNavn2", "");
            middagDosis2.Text = prefs.GetString("middagDosis2", "");
            middagAntal2.Text = prefs.GetString("middagAntal2", "");
            middagAlarm2.Text = prefs.GetString("middagAlarm2", "");
            middagHvornår2.Text = prefs.GetString("middagHvornår2", "");

            aftenNavn1.Text = prefs.GetString("aftenNavn1", "");
            aftenDosis1.Text = prefs.GetString("aftenDosis1", "");
            aftenAntal1.Text = prefs.GetString("aftenAntal1", "");
            aftenAlarm1.Text = prefs.GetString("aftenAlarm1", "");
            aftenHvornår1.Text = prefs.GetString("aftenHvornår1", "");

            aftenNavn2.Text = prefs.GetString("aftenNavn2", "");
            aftenDosis2.Text = prefs.GetString("aftenDosis2", "");
            aftenAntal2.Text = prefs.GetString("aftenAntal2", "");
            aftenAlarm2.Text = prefs.GetString("aftenAlarm2", "");
            aftenHvornår2.Text = prefs.GetString("aftenHvornår2", "");

            morgenNavn1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("morgenNavn1", e.Text.ToString());
                editor.Apply();
            };



            morgenDosis1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("morgenDosis1", e.Text.ToString());
                editor.Apply();
            };

            morgenAntal1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("morgenAntal1", e.Text.ToString());
                editor.Apply();
            };

            /*
            morgenAlarm1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                editor.PutString("morgenAlarm1", e.Text.ToString());
                editor.Apply();
            };
            */


            morgenAlarm1.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(TimePickerActivity));
                StartActivity(intent);
            };

            morgenAlarm1.Text = UserData.morgenAlarm1Text;

            morgenNavn2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("morgenNavn2", e.Text.ToString());
                editor.Apply();
            };

            morgenDosis2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("morgenDosis2", e.Text.ToString());
                editor.Apply();
            };

            morgenAntal2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("morgenAntal2", e.Text.ToString());
                editor.Apply();
            };

            morgenAlarm2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("morgenAlarm2", e.Text.ToString());
                editor.Apply();
            };

            middagNavn1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("middagNavn1", e.Text.ToString());
                editor.Apply();
            };

            middagDosis1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("middagDosis1", e.Text.ToString());
                editor.Apply();
            };

            middagAntal1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("middagAntal1", e.Text.ToString());
                editor.Apply();
            };

            middagAlarm1.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(TimePickerTwoActivity));
                StartActivity(intent);
            };

            middagAlarm1.Text = UserData.middagAlarm1Text;


            middagAlarm1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {

                editor.PutString("middagAlarm1", e.Text.ToString());
                editor.Apply();
            };

            middagNavn2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("middagNavn2", e.Text.ToString());
                editor.Apply();
            };

            middagDosis2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("middagDosis2", e.Text.ToString());
                editor.Apply();
            };

            middagAntal2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("middagAntal2", e.Text.ToString());
                editor.Apply();
            };

            middagAlarm2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("middagAlarm2", e.Text.ToString());
                editor.Apply();
            };

            aftenNavn1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("aftenNavn1", e.Text.ToString());
                editor.Apply();
            };

            aftenDosis1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("aftenDosis1", e.Text.ToString());
                editor.Apply();
            };

            aftenAntal1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("aftenAntal1", e.Text.ToString());
                editor.Apply();
            };

            aftenAlarm1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("aftenAlarm1", e.Text.ToString());
                editor.Apply();
            };

            aftenNavn2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("aftenNavn2", e.Text.ToString());
                editor.Apply();
            };

            aftenDosis2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("aftenDosis2", e.Text.ToString());
                editor.Apply();
            };

            aftenAntal2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("aftenAntal2", e.Text.ToString());
                editor.Apply();
            };

            aftenAlarm2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                editor.PutString("aftenAlarm2", e.Text.ToString());
                editor.Apply();
            };

            morgenTaget1.Click += (o, e) =>
            {
                if (morgenTaget1.Checked)
                {
                    morgenHvornår1.Text = DateTime.Now.ToString("HH:mm");
                    badinerie.Stop();
                }

                else
                {
                    morgenHvornår1.Text = "";
                    MediaPlayer badinerieNew;
                    badinerieNew = MediaPlayer.Create(this, Resource.Raw.Badinerie);
                    badinerie = badinerieNew;
                }
            };

            middagTaget1.Click += (o, e) =>
            {
                if (middagTaget1.Checked)
                {
                    middagHvornår1.Text = DateTime.Now.ToString("HH:mm");
                    oSoleMio.Stop();
                }
                else
                {
                    middagHvornår1.Text = "";
                    MediaPlayer oSoleMioNew;
                    oSoleMioNew = MediaPlayer.Create(this, Resource.Raw.OSoleMio);
                    oSoleMio = oSoleMioNew;
                }
            };

            aftenTaget1.Click += (o, e) =>
            {
                if (aftenTaget1.Checked)
                {
                    aftenHvornår1.Text = DateTime.Now.ToString("HH:mm");
                    taagenLetter.Stop();
                }
                else
                {
                    aftenHvornår1.Text = "";
                    MediaPlayer taagenLetterNew;
                    taagenLetterNew = MediaPlayer.Create(this, Resource.Raw.TaagenLetter);
                    taagenLetter = taagenLetterNew;
                }
            };

            TextView labelNAVN = FindViewById<TextView>(Resource.Id.labelNAVN);
            TextView labelDOSIS = FindViewById<TextView>(Resource.Id.labelDOSIS);



            System.Timers.Timer mainTimer = new System.Timers.Timer();
            mainTimer.Interval = 2000;

            //tip from: https://developer.xamarin.com/guides/android/advanced_topics/writing_responsive_applications/
            //ThreadPool.QueueUserWorkItem(o => slowMethod());

            checkBoxSTART.Click += (o, e) =>
            {
                if (checkBoxSTART.Checked)
                {
                    String mA1 = morgenAlarm1.Text;
                    mainTimer.AutoReset = true;
                    mainTimer.Enabled = true;
                    mainTimer.Elapsed += OnTimedEvent;
                }
                else
                { mainTimer.Enabled = false; };
            };

            void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                RunOnUiThread(() =>
                {
                    if (DateTime.Now.ToString("HH:mm") == morgenAlarm1.Text)
                    {
                        badinerie.Start();
                    }

                    else if (DateTime.Now.ToString("HH:mm") == middagAlarm1.Text)
                    {
                        oSoleMio.Start();
                    }

                    else if (DateTime.Now.ToString("HH:mm") == aftenAlarm1.Text)
                    {
                        taagenLetter.Start();
                    }
                });
            }
        }
    }
}














    






