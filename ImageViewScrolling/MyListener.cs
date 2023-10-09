using Android.Animation;

namespace TragamonedasXamarinProg.ImageViewScrolling
{
    internal class MyListener : Java.Lang.Object,Animator.IAnimatorListener
    {
        private ImageViewScrolling imageViewScrolling;
        private int image;
        private int rotate_count;

        public MyListener (ImageViewScrolling imageViewScrolling, int image, int rotate_count)
        {
            this.imageViewScrolling = imageViewScrolling;
            this.image = image;
            this.rotate_count = rotate_count;
        }

        public void OnAnimationCancel(Animator animation)
        {
            
        }

        public void OnAnimationEnd(Animator animation)
        {
            imageViewScrolling.SetImage(imageViewScrolling.currentImage, imageViewScrolling.old_value % 7);
            imageViewScrolling.currentImage.TranslationY = 0;
            if(imageViewScrolling.old_value != rotate_count) 
            {
              imageViewScrolling.SetValueRandom(image, rotate_count);
                imageViewScrolling.old_value++;
            }
            else
            {
                imageViewScrolling.last_result = 0;
                imageViewScrolling.old_value = 0;
                imageViewScrolling.SetImage(imageViewScrolling.nextImage, image);
                imageViewScrolling.eventEnd.EventEnd(image % 7, rotate_count);
            }
        }

        public void OnAnimationRepeat(Animator animation)
        {
            
        }

        public void OnAnimationStart(Animator animation)
        {
            
        }
    }
}