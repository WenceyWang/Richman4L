﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Windows ;
using System . Windows . Controls ;
using System . Windows . Media ;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WenceyWang . Richman4L . Apps . Wpf . UI . Controls
{

	public sealed partial class CardControl : UserControl
	{

		public string Title
		{
			get => TitleTextBlock ? . Text ;
			set
			{
				if ( TitleTextBlock != null )
				{
					TitleTextBlock . Text = value ;
				}
			}
		}

		public string Text
		{
			get => TextTextBlock ? . Text ;
			set
			{
				if ( TextTextBlock != null )
				{
					TextTextBlock . Text = value ;
				}
			}
		}

		public ImageSource Image
		{
			get => ImageImage . Source ;
			set
			{
				if ( TextTextBlock != null )
				{
					ImageImage . Source = value ;
				}
			}
		}

		public CardControl ( ) { InitializeComponent ( ) ; }

		public event EventHandler UseCard ;

		private void UseButton_Click ( object sender , RoutedEventArgs e )
		{
			UseCard ? . Invoke ( this , EventArgs . Empty ) ;
		}

		private void UserControl_Loaded ( object sender , RoutedEventArgs e ) { }

	}

}
