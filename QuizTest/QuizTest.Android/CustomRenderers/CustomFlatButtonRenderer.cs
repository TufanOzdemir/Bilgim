using Android.Content;
using QuizTest.CustomComponents;
using QuizTest.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomFlatButton), typeof(CustomFlatButtonRenderer))]
namespace QuizTest.Droid.CustomRenderers
{
    public class CustomFlatButtonRenderer : ButtonRenderer
    {
        public CustomFlatButtonRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffffff"));
                Control.SetTextColor(Android.Graphics.Color.ParseColor("#ffffff"));
                //

            }
        }
    }
}