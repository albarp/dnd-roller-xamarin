using Android.App;
using Android.Widget;
using Android.OS;
using AwesomeXamarinAndroidRoller.Adapters;
using AwesomeXamarinAndroidRoller.Model;
using System.Collections.Generic;

namespace AwesomeXamarinAndroidRoller
{
    [Activity(Label = "AwesomeXamarinAndroidRoller", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ProgressDialog _progressDialog;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.MainActivity);

            ListView lvMenuList = (ListView)FindViewById(Resource.Id.lvMenuList);

            MenuItemListViewAdapter lvMenuListAdapter = new MenuItemListViewAdapter(this, Resource.Layout.ItemMenuMain, ApplicationModel.Instance.MenuItems);

            lvMenuList.Adapter = lvMenuListAdapter;

            lvMenuList.ItemClick += lvMenuList_ItemClick;

            _progressDialog = new ProgressDialog(this);
        }

        void lvMenuList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.Content.Intent intent = new Android.Content.Intent(this, typeof(RollerActivity));

            StartActivity(intent);
        }

        protected override void OnStart()
        {
            base.OnStart();

            _progressDialog.Show();

            ApplicationModel.Instance.GetDndDesign().ContinueWith(res => {
                _progressDialog.Dismiss();
            });
        }
    }
}

