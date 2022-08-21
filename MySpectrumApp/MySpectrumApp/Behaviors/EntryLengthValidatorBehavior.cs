using System;
using Xamarin.Forms;

namespace MySpectrumApp.Behaviors
{
    public class EntryLengthValidatorBehavior : Behavior<Entry>
    {
        int _minLength = 2;
        Color _originalColor = Color.LightGray;

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            var text = entry.Text;

            if (string.IsNullOrEmpty(text) ||
                text.Length > _minLength)
                entry.BackgroundColor = _originalColor;
            else
                entry.BackgroundColor = Color.Red;
        }
    }
}

