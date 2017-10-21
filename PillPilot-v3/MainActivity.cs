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
            
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();

            morgenNavn1.Text = prefs.GetString("morgenNavn1", "");
            
            morgenNavn1
                .TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                    editor.PutString("morgenNavn1", e.Text.ToString());
                    // editor.Commit();    // applies changes synchronously on older APIs
                    editor.Apply();        // applies changes asynchronously on newer APIs

                };
        }
    }
}

