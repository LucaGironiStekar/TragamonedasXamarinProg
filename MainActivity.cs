using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using TragamonedasXamarinProg.ImageViewScrolling;

namespace TragamonedasXamarinProg
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity,IEventEnd
    {

        ImageView btn_up, btn_down;
        ImageViewScrolling.ImageViewScrolling image, image2, image3;
        TextView txt_score;

        int count_down = 0;

        public void EventEnd(int value, int count)
        {
            if (count_down < 2)
                count_down++;
            else
            {
                btn_down.Visibility = Android.Views.ViewStates.Gone;
                btn_up.Visibility = Android.Views.ViewStates.Visible;

                count_down = 0;

                if(image.GetValue() == image2.GetValue() && image2.GetValue() == image3.GetValue()) 
                {
                    Toast.MakeText(this, "SACASTE UN 5 ESTRELLAS", ToastLength.Short).Show();
                    Common.SCORE += 800;
                    txt_score.Text = Common.SCORE.ToString();
                }
                else if (image.GetValue() == image2.GetValue() || image2.GetValue() == image3.GetValue() 
                     || image.GetValue() == image3.GetValue()
                     )
                {
                    Toast.MakeText(this, "Sacaste un 4 estrellas", ToastLength.Short).Show();
                    Common.SCORE += 160;
                    txt_score.Text = Common.SCORE.ToString();
                }
                else 
                {
                    Toast.MakeText(this, "No sacaste nada", ToastLength.Short).Show();
                }
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;

            btn_down = FindViewById<ImageView>(Resource.Id.down);
            btn_up = FindViewById<ImageView>(Resource.Id.up);

            image = FindViewById<ImageViewScrolling.ImageViewScrolling>(Resource.Id.image);
            image2 = FindViewById<ImageViewScrolling.ImageViewScrolling>(Resource.Id.image2);
            image3 = FindViewById<ImageViewScrolling.ImageViewScrolling>(Resource.Id.image3);

            txt_score = FindViewById<TextView>(Resource.Id.txt_score);

            image2.SetEventEnd(this);
            image3.SetEventEnd(this);
            image.SetEventEnd(this);

            btn_up.Click += delegate
            {
                if(Common.SCORE >= 160) 
                {
                    btn_up.Visibility = Android.Views.ViewStates.Gone;
                    btn_down.Visibility = Android.Views.ViewStates.Visible;

                    image.SetValueRandom(new Random(DateTime.Now.Millisecond).Next(7),
                        new Random(DateTime.Now.Millisecond).Next(5, 15));

                    image2.SetValueRandom(new Random(DateTime.Now.Millisecond).Next(7),
                        new Random(DateTime.Now.Millisecond).Next(5, 15));

                    image3.SetValueRandom(new Random(DateTime.Now.Millisecond).Next(7),
                        new Random(DateTime.Now.Millisecond).Next(5, 15));

                    Common.SCORE -= 160;
                    txt_score.Text = Common.SCORE.ToString();
                }
                else 
                {
                    Toast.MakeText(this, "No tenes suficientes protos", ToastLength.Short).Show();
                }

            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}