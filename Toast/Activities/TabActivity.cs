
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
using AndroidX.AppCompat.App;
using Google.Android.Material.Tabs;
using Toast.Fragments;

namespace Toast.Activities
{
    [Activity(Label = "TabActivity")]
    public class TabActivity : AppCompatActivity
    {
        TabLayout tabLayout;
        TabItem tabItem1;
        TabItem tabItem2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tabbed_activity);
            this.SupportActionBar?.SetDisplayHomeAsUpEnabled(true);

            tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayoutG);
            tabItem1 = FindViewById<TabItem>(Resource.Id.fragmentTab1);
            tabItem2 = FindViewById<TabItem>(Resource.Id.fragmentTab2);

            tabItem1.Click += TabItem1_Click;
            tabItem2.Click += TabItem2_Click;

            SupportFragmentManager.BeginTransaction()
               .Add(Resource.Id.frameFragmentsTabbed, new FragmentOne(), "item_fragment_one")
               .Commit();
        }

        private void TabItem2_Click(object sender, EventArgs e)
        {
            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.frameFragmentsTabbed,new FragmentOne(),"item_fragment_one")
                .Commit();
        }

        private void TabItem1_Click(object sender, EventArgs e)
        {
            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.frameFragmentsTabbed, new FragmentTwo(), "item_fragment_two")
               .Commit();
        }
    }
}
