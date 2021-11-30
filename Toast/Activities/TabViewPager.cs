using System;
using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using AndroidX.ViewPager.Widget;
using Google.Android.Material.Tabs;

namespace Toast.Activities
{
    [Activity(Label = "TabViewPager")]
    public class TabViewPager : AppCompatActivity
    {
        TabLayout tabLayout;
        ViewPager pager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
            pager = FindViewById<ViewPager>(Resource.Id.pager);
            
        }

    }
}
