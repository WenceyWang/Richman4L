﻿namespace WenceyWang . FoggyConsole . Controls .Renderers
{

	public class StackPanelRanderer : ControlRenderer < StackPanel >
	{

		public override void Draw ( )
		{
			foreach ( Control control in Control . Items )
			{
				control . Draw ( ) ;
			}
		}

	}

}
