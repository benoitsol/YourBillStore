
using Android.App;
using Android.OS;

namespace Benoit.YBS.App.Droid
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //System.Threading.Thread.Sleep(100);
            StartActivity(typeof(MainActivity));
        }
    }
}