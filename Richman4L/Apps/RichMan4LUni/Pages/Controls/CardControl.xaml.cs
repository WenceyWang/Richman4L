﻿using System ;

using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Media ;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WenceyWang . Richman4L . Apps . Uni . Pages . Controls
{
    public sealed partial class CardControl : UserControl
    {
        public CardControl ( )
        {
	        InitializeComponent ( );
        }

        public event EventHandler UseCard;

        public string Title
        {
            get
            {
                return TitleTextBlock?.Text;
            }
            set
            {
                if ( TitleTextBlock != null )
                {
                    TitleTextBlock . Text = value;
                }
            }
        }
        public string Text
        {
            get
            {
                return TextTextBlock?.Text;
            }
            set
            {
                if ( TextTextBlock != null )
                {
                    TextTextBlock . Text = value;
                }
            }
        }

        public ImageSource Image
        {
            get
            {
                return ImageImage . Source;
            }
            set
            {
                if ( TextTextBlock != null )
                {
                    ImageImage . Source = value;
                }
            }
        }

        private void UseButton_Click ( object sender , RoutedEventArgs e )
        {
            UseCard?.Invoke ( this , new EventArgs ( ) );
        }

        private void UserControl_Loaded ( object sender , RoutedEventArgs e )
        {

        }
    }
}
