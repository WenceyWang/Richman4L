﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;

using Windows . ApplicationModel ;
using Windows . ApplicationModel . Activation ;
using Windows . UI . Xaml ;
using Windows . UI . Xaml . Controls ;
using Windows . UI . Xaml . Navigation ;

using Microsoft . VisualStudio . TestPlatform . TestExecutor ;

namespace WenceyWang . Richman4L . Apps . Uni . UnitTests
{

	/// <summary>
	///     Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	internal sealed partial class App : Application
	{

		/// <summary>
		///     Initializes the singleton application object.  This is the first line of authored code
		///     executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App ( )
		{
			InitializeComponent ( ) ;
			Suspending += OnSuspending ;
		}

		/// <summary>
		///     Invoked when the application is launched normally by the end user.  Other entry points
		///     will be used such as when the application is launched to open a specific file.
		/// </summary>
		/// <param name="e">Details about the launch request and process.</param>
		protected override void OnLaunched ( LaunchActivatedEventArgs e )
		{
#if DEBUG
			if ( Debugger . IsAttached )
			{
				DebugSettings . EnableFrameRateCounter = true ;
			}
#endif

			Frame rootFrame = Window . Current . Content as Frame ;

			// Do not repeat app initialization when the Window already has content,
			// just ensure that the window is active
			if ( rootFrame == null )
			{
				// Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = new Frame ( ) ;

				rootFrame . NavigationFailed += OnNavigationFailed ;

				if ( e . PreviousExecutionState == ApplicationExecutionState . Terminated )
				{
					//TODO: Load state from previously suspended application
				}

				// Place the frame in the current Window
				Window . Current . Content = rootFrame ;
			}

			UnitTestClient . CreateDefaultUI ( ) ;

			// Ensure the current window is active
			Window . Current . Activate ( ) ;

			UnitTestClient . Run ( e . Arguments ) ;
		}

		/// <summary>
		///     Invoked when Navigation to a certain page fails
		/// </summary>
		/// <param name="sender">The Frame which failed navigation</param>
		/// <param name="e">Details about the navigation failure</param>
		private void OnNavigationFailed ( object sender , NavigationFailedEventArgs e )
		{
			throw new Exception ( "Failed to load Page " + e . SourcePageType . FullName ) ;
		}

		/// <summary>
		///     Invoked when application execution is being suspended.  Application state is saved
		///     without knowing whether the application will be terminated or resumed with the contents
		///     of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		private void OnSuspending ( object sender , SuspendingEventArgs e )
		{
			SuspendingDeferral deferral = e . SuspendingOperation . GetDeferral ( ) ;

			//TODO: Save application state and stop any background activity
			deferral . Complete ( ) ;
		}

	}

}