﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace WenceyWang . Richman4L . Logics . Players . Events
{

	public class PlayerGetEventArgs : PlayerEventArgs
	{

		public virtual long Money { get ; }

		public PlayerGetEventArgs ( long money ) { Money = money ; }

		protected PlayerGetEventArgs ( ) { }

	}

}
