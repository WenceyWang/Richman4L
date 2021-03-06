﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Windows ;
using System . Windows . Media ;
using System . Windows . Navigation ;

using WenceyWang . Richman4L . Apps . Wpf . UI . Controls ;
using WenceyWang . Richman4L . Logics ;
using WenceyWang . Richman4L . Logics . Auctions ;
using WenceyWang . Richman4L . Logics . GameEnviroment ;
using WenceyWang . Richman4L . Logics . InfomationCenter ;
using WenceyWang . Richman4L . Logics . Players ;
using WenceyWang . Richman4L . Logics . Players . Commands ;
using WenceyWang . Richman4L . Logics . Players . Models ;

namespace WenceyWang . Richman4L . Apps . Wpf . UI . Pages
{

	/// <summary>
	/// </summary>
	public sealed partial class GamePage : AnimatePage
	{

		private GamePlayerConsole console = new GamePlayerConsole ( ) ;


		private bool CardGridShow { get ; set ; }

		public Game CurrentGame => Game . Current ;

		public static Color PageColor => XamlResources . Resources . Pink ;

		public GamePage ( )
		{
			InitializeComponent ( ) ;
			Loaded += GamePage_Loaded ;
		}

		public void ShowDices ( List <DiceWithValue> dices )
		{
			foreach ( DiceWithValue dice in dices )
			{
				DiceControl diceControl = new DiceControl ( ) ;
			}
		}

		private void GamePage_Loaded ( object sender , RoutedEventArgs e )
		{
			MapRenderer . SetMap ( Game . Current . Map ) ;
			MapRenderer . RendererCatched ( ) ;
		}

		/// <summary>
		///     Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">
		///     Event data that describes how this page was reached.
		///     This parameter is typically used to configure the page.
		/// </param>
		protected override void OnNavigatedTo ( NavigationEventArgs e )
		{
			DataContext = e . Parameter as Game ;
		}

		private void ShowPlayerGridButton_Click ( object sender , RoutedEventArgs e )
		{
			ShowPlayerGridStoryBoard . Begin ( ) ;
			ShowPlayerGridButton . Click -= ShowPlayerGridButton_Click ;

			//HidePlayerGridButton . Click -= HidePlayerGridButton_Click;
		}

		private void HidePlayerGridButton_Click ( object sender , RoutedEventArgs e )
		{
			HidePlayerGridStoryBoard . Begin ( ) ;
			ShowPlayerGridButton . Click -= ShowPlayerGridButton_Click ;

			//HidePlayerGridButton . Click -= HidePlayerGridButton_Click;
		}

		private void ShowPlayerGridStoryBoard_Completed ( object sender , object e )
		{
			//ShowPlayerGridButton . Visibility = Visibility . Collapsed ;
			//ShowPlayerGridButton . RenderTransform = new CompositeTransform { Rotation = 180 } ;

			//PlayerGrid . Visibility = Visibility . Visible;
			//PlayerGrid . Opacity = 100;
			//PlayerGrid . RenderTransform = new CompositeTransform { TranslateY = 0 };
			//HidePlayerGridButton . RenderTransform = new CompositeTransform { TranslateY = 0 , Rotation = 180 };
			ShowPlayerGridButton . Click += ShowPlayerGridButton_Click ;

			//HidePlayerGridButton . Click += HidePlayerGridButton_Click;
		}


		private void HidePlayerGridStoryBoard_Completed ( object sender , object e )
		{
			ShowPlayerGridButton . Visibility = Visibility . Visible ;
			ShowPlayerGridButton . RenderTransform = new CompositeTransform { Rotation = 0 } ;

			// PlayerGrid . Visibility = Visibility . Collapsed;
			//  PlayerGrid . Opacity = 0;
			//  PlayerGrid . RenderTransform = new CompositeTransform { TranslateY = -300 };
			//HidePlayerGridButton . RenderTransform = new CompositeTransform { TranslateY = 300 , Rotation = 0 };
			ShowPlayerGridButton . Click += ShowPlayerGridButton_Click ;

			//HidePlayerGridButton . Click += HidePlayerGridButton_Click;
		}


		private void ShowPropertyGridButton_Click ( object sender , RoutedEventArgs e )
		{
			ShowPropertyGridStoryBoard . Begin ( ) ;
			ShowPropertyGridButton . Click -= ShowPropertyGridButton_Click ;
			HidePropertyGridButton . Click -= HidePropertyGridButton_Click ;
		}

		private void HidePropertyGridButton_Click ( object sender , RoutedEventArgs e )
		{
			HidePropertyGridStoryBoard . Begin ( ) ;
			ShowPropertyGridButton . Click -= ShowPropertyGridButton_Click ;
			HidePropertyGridButton . Click -= HidePropertyGridButton_Click ;
		}

		private void ShowPropertyGridStoryBoard_Completed ( object sender , object e )
		{
			ShowPropertyGridButton . Visibility = Visibility . Collapsed ;
			PropertyGrid . Visibility = Visibility . Visible ;
			PropertyGrid . Opacity = 100 ;
			PropertyGrid . RenderTransform = new CompositeTransform { TranslateY = 0 } ;
			HidePropertyGridButton . Visibility = Visibility . Visible ;
			HidePropertyGridButton . RenderTransform = new CompositeTransform { Rotation = 180 } ;
			ShowPropertyGridButton . Click += ShowPropertyGridButton_Click ;
			HidePropertyGridButton . Click += HidePropertyGridButton_Click ;
		}

		private void HidePropertyGridStoryBoard_Completed ( object sender , object e )
		{
			ShowPropertyGridButton . Visibility = Visibility . Visible ;
			PropertyGrid . Visibility = Visibility . Collapsed ;
			PropertyGrid . Opacity = 0 ;
			PropertyGrid . RenderTransform = new CompositeTransform { TranslateY = 300 } ;
			HidePropertyGridButton . Visibility = Visibility . Collapsed ;
			HidePropertyGridButton . RenderTransform = new CompositeTransform { Rotation = 0 } ;
			ShowPropertyGridButton . Click += ShowPropertyGridButton_Click ;
			HidePropertyGridButton . Click += HidePropertyGridButton_Click ;
		}


		private void CardButton_Click ( object sender , RoutedEventArgs e )
		{
			if ( ! CardGridShow )
			{
				ShowCardGridStoryBoard . Begin ( ) ;
			}
			else
			{
				HideCardGridStoryBoard . Begin ( ) ;
			}
			CardGridShow = ! CardGridShow ;
			CardButton . Click -= CardButton_Click ;
		}

		private void ShowCardGridStoryBoard_Completed ( object sender , object e )
		{
			CardGrid . RenderTransform = new CompositeTransform { TranslateX = 0 } ;
			CardButton . RenderTransform = new CompositeTransform { TranslateX = - 160 } ;
			CardButtonRotateTextBlock . RenderTransform = new CompositeTransform { Rotation = 180 } ;
			CardButton . Click += CardButton_Click ;
		}

		private void HideCardGridStoryBoard_Completed ( object sender , object e )
		{
			CardGrid . RenderTransform = new CompositeTransform { TranslateX = 160 } ;
			CardButton . RenderTransform = new CompositeTransform { TranslateX = 0 } ;
			CardButtonRotateTextBlock . RenderTransform = new CompositeTransform { Rotation = 0 } ;
			CardButton . Click += CardButton_Click ;
		}


		private void StartStoryboard_Completed ( object sender , object e ) { }

		private void HideMenuGridStoryBoard_Completed ( object sender , object e )
		{
			//MenuGrid . Visibility = Visibility . Collapsed ;
			//MenuGrid . Opacity = 0 ;
			//MenuGrid . RenderTransform = new CompositeTransform { TranslateY = 600 } ;
			AddMenuControl ( ) ;
		}

		private void ShowMenuGridStoryBoard_Completed ( object sender , object e )
		{
			//MenuGrid . Visibility = Visibility . Visible ;
			//MenuGrid . Opacity = 100 ;
			//MenuGrid . RenderTransform = new CompositeTransform { TranslateY = 0 } ;
			AddMenuControl ( ) ;
		}

		private void ResumeButton_Click ( object sender , RoutedEventArgs e )
		{
			HideMenuGridStoryBoard . Begin ( ) ;
			RemoveMenuControl ( ) ;
		}

		private void SaveButton_Click ( object sender , RoutedEventArgs e ) { }

		private void AddMenuControl ( )
		{
			ResumeButton . Click += ResumeButton_Click ;
			SaveButton . Click += SaveButton_Click ;
			DevButton . Click += DevButton_Click ;
			MainPageButton . Click += MainPageButton_Click ;
			MenuButton . Click += MenuButton_Click ;
			ZoomInButton . Click += ZoomInButton_Click ;
			ZoomOutButton . Click += ZoomOutButton_Click ;
		}

		private void RemoveMenuControl ( )
		{
			ResumeButton . Click -= ResumeButton_Click ;
			SaveButton . Click -= SaveButton_Click ;
			DevButton . Click -= DevButton_Click ;
			MainPageButton . Click -= MainPageButton_Click ;
			MenuButton . Click -= MenuButton_Click ;
			ZoomInButton . Click -= ZoomInButton_Click ;
			ZoomOutButton . Click -= ZoomOutButton_Click ;
		}

		private void DevButton_Click ( object sender , RoutedEventArgs e ) { }

		private void MainPageButton_Click ( object sender , RoutedEventArgs e ) { }

		private void GoButton_Click ( object sender , RoutedEventArgs e ) { }

		private void MenuButton_Click ( object sender , RoutedEventArgs e )
		{
			ShowMenuGridStoryBoard . Begin ( ) ;
			RemoveMenuControl ( ) ;
		}

		private void ZoomInButton_Click ( object sender , RoutedEventArgs e ) { }

		private void ZoomOutButton_Click ( object sender , RoutedEventArgs e ) { }

		private void Page_Loaded ( object sender , RoutedEventArgs e )
		{
			try
			{
				//var uiv= new DirectXPage ( GameMapPresenter );
			}
			catch ( Exception )
			{
				//throw;
			}
		}

		public override void AddControl ( ) { }

		public override void RemoveControl ( ) { }

		public class GamePlayerConsole : PlayerConsole
		{

			public override void ShowDices ( List <DiceWithValue> dices ) { }

			public override void ShowEvent ( Event @event ) { throw new NotImplementedException ( ) ; }

			public override void PlayerSay ( Player player , PlayerSaying saying ) { throw new NotImplementedException ( ) ; }

			public override void ShowFlag ( bool flaged ) { throw new NotImplementedException ( ) ; }

			public override void UpdateGame ( GameObject gameObject ) { throw new NotImplementedException ( ) ; }

			public override void UpdatePlayerCommand ( List <PlayerCommand> commands )
			{
				throw new NotImplementedException ( ) ;
			}

			public override void ShowChatMessage ( Player source , string message ) { throw new NotImplementedException ( ) ; }

			public override void StartSmallGame ( SmallGameType gameType ) { throw new NotImplementedException ( ) ; }

			public override void ShowGameOver ( GameResult info ) { throw new NotImplementedException ( ) ; }

			public override void StartAuction ( AuctionRequest request ) { throw new NotImplementedException ( ) ; }

			public override void UpdateAuction ( AuctionRequest request , Player buyer , long priceRised )
			{
				throw new NotImplementedException ( ) ;
			}

			public override void ShowDice ( DiceType diceType , int value ) { throw new NotImplementedException ( ) ; }

			public override void ShowAuctionResult ( AuctionRequest request , AuctionResult result )
			{
				throw new NotImplementedException ( ) ;
			}

			public override PlayerConsoleAbility GetAbility ( ) { throw new NotImplementedException ( ) ; }

		}

	}

}
