using Xamarin.Forms;

namespace MySpectrumApp.Effects
{
    public class EntryWithNoUnderlineEffect : RoutingEffect
    {
        public EntryWithNoUnderlineEffect()
            :base($"MySpectrumApp.{nameof(EntryWithNoUnderlineEffect)}")
        {
        }
    }
}

