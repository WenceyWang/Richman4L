﻿using System . Collections . Generic ;

using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole .Controls
{

	public class Grid : ItemsControl
	{

		public override bool CanFocus => false ;

		public override IList < Control > Items { get ; } = new List < Control > ( ) ;

		public Grid ( IControlRenderer renderer ) : base ( renderer ?? new GridRanderer ( ) ) { }

	}

}
