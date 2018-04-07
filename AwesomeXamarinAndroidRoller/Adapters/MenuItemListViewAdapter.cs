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

namespace AwesomeXamarinAndroidRoller.Adapters
{
    public class MenuItemListViewAdapter : ArrayAdapter<MenuItemDefinition> 
    {

        private List<MenuItemDefinition> menuItems = null;

        private Context _context = null;

        public MenuItemListViewAdapter(Context context, int resource, List<MenuItemDefinition> objects)
            : base(context, resource, objects)
        {

            menuItems = objects;

            _context = context;
        }

    public override View GetView(int position, View convertView, ViewGroup parent) {

        View v = convertView;

        if(v == null){
            LayoutInflater vi = LayoutInflater.From(_context);
            v = vi.Inflate(Resource.Layout.ItemMenuMain, null);
        }

        MenuItemDefinition currentMenuItemDefinition = menuItems[position];

        TextView itemMenuTitle = (TextView)v.FindViewById(Resource.Id.itemMenuTitle);
        TextView itemMenuDescription = (TextView)v.FindViewById(Resource.Id.itemMenuDescription);

        itemMenuTitle.Text = currentMenuItemDefinition.Title;
        itemMenuDescription.Text = currentMenuItemDefinition.Description;

        return v;
    }
}
}