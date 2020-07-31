using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DriveMobile.Behaviors
{
    class TextChangedBehavior : Behavior<SearchBar>
    {
        protected override void OnAttachedTo(SearchBar bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChange;
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChange;
        }

        private void Bindable_TextChange(object sender, TextChangedEventArgs e)
        {
            ((Xamarin.Forms.SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
        }
    }
}
