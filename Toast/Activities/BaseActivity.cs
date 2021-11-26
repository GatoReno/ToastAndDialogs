using System;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;

namespace Toast.Activities
{
    public abstract class BaseActivity : AppCompatActivity
    {
        public BaseActivity()
        {
            SetUpUI();
        }

        private void SetUpUI()
        {
            this.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);          
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
