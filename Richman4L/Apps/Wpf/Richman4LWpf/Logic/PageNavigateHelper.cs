﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Windows . Media . Animation ;

using WenceyWang . Richman4L . Apps . Wpf . UI . Pages ;

namespace WenceyWang . Richman4L . Apps . Wpf . Logic
{

	internal class BlankNavigationTransitionInfo : NavigationTransitionInfo
	{

	}

	public static class PageNavigateHelper
	{

		public static void NavigateTo <T> ( this AnimatePage page , object parameter = null ) where T : AnimatePage
		{
			ColorAnimationUsingKeyFrames ca = new ColorAnimationUsingKeyFrames ( ) ;
			Storyboard . SetTargetName ( ca , "BackgroundRect" ) ;
			Storyboard . SetTargetProperty ( ca , "(Shape.Fill).(SolidColorBrush.Color)" ) ;
			ca . KeyFrames . Add ( new EasingColorKeyFrame
									{
										KeyTime = KeyTime . FromTimeSpan ( TimeSpan . FromSeconds ( 0.25 ) ) ,
										Value = AnimatePage . GetPageColor ( page ) ,
										EasingFunction = Uni . UI . XamlResources . Resources . EasingFunction
									} ) ;

			ca . KeyFrames . Add ( new EasingColorKeyFrame
									{
										KeyTime = KeyTime . FromTimeSpan ( TimeSpan . FromSeconds ( 0.5 ) ) ,
										Value = AnimatePage . GetPageColor <T> ( ) ,
										EasingFunction = Uni . UI . XamlResources . Resources . EasingFunction
									} ) ;

			page . GetLeaveStoryboard . Children . Add ( ca ) ;
			page . GetLeaveStoryboard . Completed += ( obj , ev ) =>
													{
														page . Frame . Navigate ( typeof ( T ) , parameter , new BlankNavigationTransitionInfo ( ) ) ;
														page . GetLeaveStoryboard . Stop ( ) ;
														page . GetLeaveStoryboard . Children . Remove ( ca ) ;
														page . AddControl ( ) ;
													} ;
			page . RemoveControl ( ) ;
			page . GetLeaveStoryboard . Begin ( ) ;
		}

	}

}
