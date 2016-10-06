﻿using System ;
using System . Security ;

using FoggyConsole . Controls . Renderers ;

namespace FoggyConsole .Controls
{

	public class PasswordBox : Control
	{

		private int _cursorPosition ;

		private string _hintText ;

		private ConsoleColor _hintTextColor = ConsoleColor . Gray ;

		private char _passwordChar = '*' ;

		public ConsoleColor HintTextColor
		{
			get { return _hintTextColor ; }
			set
			{
				if ( _hintTextColor != value )
				{
					_hintTextColor = value ;
					Draw ( ) ;
				}
			}
		}

		public string HintText
		{
			get { return _hintText ; }
			set
			{
				if ( _hintText != value )
				{
					_hintText = value ;
					Draw ( ) ;
				}
			}
		}

		public SecureString Text { get ; set ; }


		/// <summary>
		///     The position of the cursor within the textbox
		/// </summary>
		public int CursorPosition
		{
			get { return _cursorPosition ; }
			private set
			{
				_cursorPosition = value ;
				Draw ( ) ;
			}
		}

		/// <summary>
		///     The char as which all characters should be rendered if <code>PasswordMode</code> is true
		/// </summary>
		public char PasswordChar
		{
			get { return _passwordChar ; }
			set
			{
				if ( _passwordChar != value )
				{
					_passwordChar = value ;
					Draw ( ) ;
				}
			}
		}

		public override bool CanFocus => Enabled ;


		public PasswordBox ( ControlRenderer < PasswordBox > renderer = null )
			: base ( renderer ?? new PasswordBoxRenderer ( ) ) { }

		/// <summary>
		/// </summary>
		public event EventHandler EnterPressed ;

		public override void KeyPressed ( KeyPressedEventArgs args )
		{
			if ( ! Enabled )
			{
				return ;
			}

			switch ( args . KeyInfo . Key )
			{
				case ConsoleKey . Tab :
				case ConsoleKey . Escape :
				{
					break ;
				}
				case ConsoleKey . Enter :
				{
					args . Handled = true ;
					EnterPressed ? . Invoke ( this , EventArgs . Empty ) ;
					break ;
				}
				case ConsoleKey . RightArrow :
				{
					args . Handled = true ;
					if ( CursorPosition < Text . Length )
					{
						CursorPosition++ ;
					}
					break ;
				}
				case ConsoleKey . LeftArrow :
				{
					args . Handled = true ;
					if ( CursorPosition > 0 )
					{
						CursorPosition-- ;
					}
					break ;
				}
				case ConsoleKey . Backspace :
				{
					args . Handled = true ;
					if ( Text . Length != 0 )
					{
						if ( CursorPosition > 0 )
						{
							Text . RemoveAt ( CursorPosition - 1 ) ;
							CursorPosition-- ;
						}
					}
					break ;
				}
				default :
				{
					args . Handled = true ;
					char newChar = args . KeyInfo . KeyChar ;
					Text . InsertAt ( CursorPosition , newChar ) ;
					CursorPosition++ ;
					break ;
				}
			}
		}

	}

}