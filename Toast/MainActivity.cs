using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Toast.Activities;
using Android.Content;
using Toast.Factory;
using Toast.Abstractions;
using Toast.Service;

namespace Toast
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            ServiceInitializer.Instance.Initialize(this);
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            SetUpUI();
        }

        private void CreateAlertDialogMethod(object sender, EventArgs e)
        {

            IDialogBuilder dialogBuilder = new SingletonDialogBuilder();
            dialogBuilder
                .SetTitle("title")
                .SetMessage("Message")
                .SetPositiveLabel("OK")
                .SetPositiveAction(()=>
                {
                    string text = "My toast positive ✅";
                    Android.Widget.ToastLength duration = Android.Widget.ToastLength.Short;
                    var toast = Android.Widget.Toast.MakeText(this, text, duration);
                    toast.Show();
                });

            IDialogService dialogService = dialogBuilder.BuildDiaalog();
            dialogService.ShowDialog();
        }

        public void SetUpUI()
        {
            Android.Widget.Button toastBtn =
             FindViewById<Android.Widget.Button>(Resource.Id.toastBtn);
            toastBtn.Click += CreateAlertDialogMethod;

            Android.Widget.Button alertBtn =
                FindViewById<Android.Widget.Button>(Resource.Id.alertBtn);
            alertBtn.Click += AlertBtn_Click;

            Android.Widget.Button navBtn =
                FindViewById<Android.Widget.Button>(Resource.Id.navBtn);
            navBtn.Click += NavBtn_Click;
        }

        private void NavBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            StartActivity(intent);
        }

        private void AlertBtn_Click(object sender, EventArgs e)
        {
            AndroidX.AppCompat.App.AlertDialog.Builder dialog =
                new AndroidX.AppCompat.App.AlertDialog.Builder(this);
            dialog.SetTitle("Title");
            dialog.SetMessage("My message 💀");
            dialog.SetPositiveButton("✅",(ob,args)=>
            {
                string text = "My toast positive ✅";
                Android.Widget.ToastLength duration = Android.Widget.ToastLength.Short;
                var toast = Android.Widget.Toast.MakeText(this, text, duration);
                toast.Show();
            });
            dialog.SetNegativeButton("☠️", (ob, args) =>
            {
                string text = "My toast negative ☠️";
                Android.Widget.ToastLength duration = Android.Widget.ToastLength.Short;
                var toast = Android.Widget.Toast.MakeText(this, text, duration);
                toast.Show();
            });
            dialog.Show();
        }

        private void ToastBtn_Click(object sender, EventArgs e)
        {
            string text = "My toast 💀";
            Android.Widget.ToastLength duration = Android.Widget.ToastLength.Long;
            var toast = Android.Widget.Toast.MakeText(this, text, duration);
            toast.Show();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
