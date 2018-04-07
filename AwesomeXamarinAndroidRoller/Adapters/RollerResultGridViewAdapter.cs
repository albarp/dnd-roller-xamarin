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
using AwesomeXamarinAndroidRoller;

public class RollerResultGridViewAdapter : ArrayAdapter<ApplicationStat> {

    private ApplicationStat[] _stats;

    public RollerResultGridViewAdapter(Context context, int resource, ApplicationStat[] stats) : base(context, resource, stats) {
        
        _stats = stats;
    }

   
    public override View GetView(int position, View convertView, ViewGroup parent) {

        View v = convertView;

        ApplicationStat currentStat = _stats[position];

        if(v == null){
            LayoutInflater vi = LayoutInflater.From(Context);

            v = vi.Inflate(Resource.Layout.ItemGridRoller, null);
        }

        TextView itemGridDescription = (TextView)v.FindViewById(Resource.Id.itemGridDescription);

        String description = currentStat.Name + ": " + currentStat.Value + " (" + currentStat.Bonus + ")";

        itemGridDescription.Text = description;

        RatingBar ratingBar = (RatingBar) v.FindViewById(Resource.Id.ratingBar);

        ratingBar.Rating = currentStat.Rating;

        if(currentStat.Rating == 0){
            v.SetBackgroundResource(Resource.Color.NotSet);
        }
        else if(currentStat.Rating == 1){
            v.SetBackgroundResource(Resource.Color.Low);
        }
        else if(currentStat.Rating == 2) {
            v.SetBackgroundResource(Resource.Color.Med);
        }
        else if(currentStat.Rating == 3){
            v.SetBackgroundResource(Resource.Color.High);
        }

        return v;
    }
}