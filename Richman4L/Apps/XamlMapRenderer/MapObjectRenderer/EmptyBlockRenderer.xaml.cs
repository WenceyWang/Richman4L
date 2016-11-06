﻿using System ;
using System . Collections ;
using System . Linq ;

using Windows . Foundation ;
using Windows . UI . Xaml ;

using WenceyWang . Richman4L . Maps ;
using WenceyWang . Richman4L . Properties ;

namespace WenceyWang . Richman4L . App . XamlMapRenderer .MapObjectRenderer
{

	public sealed partial class EmptyBlockRenderer : MapObjectRenderer , IMapObjectRenderer < EmptyBlock >
	{

		public override Size Size => new Size ( 100 , 50 ) ;

		public EmptyBlockRenderer ( ) { InitializeComponent ( ) ; }

		public static readonly DependencyProperty TargetProperty =
			DependencyProperty . Register ( nameof ( Target ) ,
											typeof ( EmptyBlock ) ,
											typeof ( EmptyBlockRenderer ) ,
											new PropertyMetadata ( null ) ) ;

		public EmptyBlock Target
		{
			get { return ( EmptyBlock ) GetValue ( TargetProperty ) ; }
			private set { SetValue ( TargetProperty , value ) ; }
		}

		public void StartUp ( ) { }

		public void SetTarget ( [ NotNull ] EmptyBlock target )
		{
			if ( Target == null )
			{
				Target = target ;
				StartUp ( ) ;
			}
			else
			{
				throw new InvalidOperationException ( ) ;
			}
		}

		public void Update ( ) { }

		public override void Hide ( ) { }

		public override void Show ( ) { }

	}

}
