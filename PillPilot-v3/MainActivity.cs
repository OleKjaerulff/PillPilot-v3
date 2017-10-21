using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Preferences;

namespace PillPilot_v3
{
    [Activity(Label = "PillPilot_v3", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            EditText morgenNavn1 = FindViewById<EditText>(Resource.Id.morgenNavn1);
            TextView labelMorgen = FindViewById<TextView>(Resource.Id.labelMorgen);

            morgenNavn1
                .TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                    labelMorgen.Text = e.Text.ToString();

            };



            /*
            string morgenNavn1val = "Ole";
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("morgenNavn1", morgenNavn1val);
            // editor.Commit();    // applies changes synchronously on older APIs
            editor.Apply();        // applies changes asynchronously on newer APIs



            // mInt = prefs.GetInt("key_for_my_int_value", < default value >);
            morgenNavn1val = prefs.GetString("morgenNavn1", morgenNavn1val);
            morgenNavn1.Text = morgenNavn1val;
            */




        }
    }
}

