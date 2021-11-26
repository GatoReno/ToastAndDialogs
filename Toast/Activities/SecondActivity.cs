
using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Toast.Activities
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second_activity);
            SetUpUI();

        }

        private void SetUpUI()
        {
            Button button = FindViewById<Button>(Resource.Id.navBtnSecondActivity);
            button.Click += Button_Click;

            this.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            base.OnBackPressed();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;
                    
                default:
                    return true;
            }
        }
    }
}
