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
using AwesomeXamarinAndroidRoller.Model;

namespace AwesomeXamarinAndroidRoller
{
    [Activity(Label = "RollerActivity")]
    public class RollerActivity : Activity
    {
        private GridView _grRollerResult;
        private GridView GrRollerResult
        {
            get
            {
                if(_grRollerResult == null)
                    _grRollerResult = FindViewById<GridView>(Resource.Id.grRollerResult);
                return _grRollerResult;
            }
        }

        private Button _btnDndDefault;
        private Button BtnDndDefault
        {
            get
            {
                if (_btnDndDefault == null)
                    _btnDndDefault = FindViewById<Button>(Resource.Id.btRollDnDefault);
                return _btnDndDefault;
            }
        }

        private RollerResultGridViewAdapter _rollerResGridAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RollerActivity);

            ActionBar.SetDisplayHomeAsUpEnabled(true);

            _rollerResGridAdapter = new RollerResultGridViewAdapter(this, Resource.Layout.ItemGridRoller, ApplicationModel.Instance.Stats);

            GrRollerResult.Adapter = _rollerResGridAdapter;

            BtnDndDefault.Click += BtnDndDefault_Click;

        }

        async void BtnDndDefault_Click(object sender, EventArgs e)
        {
            await ApplicationModel.Instance.RollDndDefault();

            _rollerResGridAdapter.NotifyDataSetChanged();
        }
    }
}