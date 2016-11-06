﻿/*
This file is part of FoggyConsole.

FoggyConsole is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as
published by the Free Software Foundation, either version 3 of
the License, or (at your option) any later version.

FoogyConsole is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with FoggyConsole.  If not, see <http://www.gnu.org/licenses/lgpl.html>.
*/

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using WenceyWang . FoggyConsole . Controls . Events ;
using WenceyWang . FoggyConsole . Controls . Renderers ;

namespace WenceyWang . FoggyConsole .Controls
{

	/// <summary>
	///     A very basic <code>Container</code>
	///     It has no appearance, controls within it are aligned using thier top and left values.
	/// </summary>
	public class Canvas : ItemsControl
	{

		public override bool CanFocus => false ;

		public override IList < Control > Items { get ; } = new List < Control > ( ) ;

		public Dictionary < Control , Point > Position { get ; } = new Dictionary < Control , Point > ( ) ;

		public Point this [ Control control ] { get { return Position [ control ] ; } set { Position [ control ] = value ; } }

		/// <summary>
		///     Creates a new <code>Canvas</code>
		/// </summary>
		/// <param name="renderer">
		///     The <code>ControlRenderer</code> to use. If null a new instance of <code>PanelRenderer</code>
		///     will be used.
		/// </param>
		/// <exception cref="ArgumentException">
		///     Thrown if the <code>ControlRenderer</code> which should be set already has an other
		///     Control assigned
		/// </exception>
		public Canvas ( IControlRenderer renderer = null ) : base ( renderer ?? new CanvasRenderer ( ) ) { }

		public override void AddChild ( Control control )
		{
			this [ control ] = new Point ( ) ;
			base . AddChild ( control ) ;
		}

		public override void Arrange ( Rectangle finalRect )
		{
			foreach ( Control control in Items )
			{
				control . Arrange ( new Rectangle ( finalRect . LeftTopPoint . Offset ( new Vector ( Position [ control ] ) ) ,
													control . DesiredSize ) ) ;
			}

			base . Arrange ( finalRect ) ;
		}

		public override void Measure ( Size availableSize )
		{
			foreach ( Control control in Items )
			{
				control . Measure ( availableSize ) ;
			}

			Rectangle rectangle = new Rectangle ( ) ;

			foreach ( Control control in Items )
			{
				rectangle = rectangle . Union ( new Rectangle ( this [ control ] , control . DesiredSize ) ) ;
			}

			DesiredSize = rectangle . Size ;
		}

		/// <summary>
		///     Fired if a control gets added to this container
		/// </summary>
		/// <seealso cref="ControlRemoved" />
		public event EventHandler < ContainerControlEventArgs > ControlAdded ;

		private void OnControlAdded ( Control control )
		{
			control . Container = this ;
			ControlAdded ? . Invoke ( this , new ContainerControlEventArgs ( control ) ) ;
		}

		/// <summary>
		///     Fired if a control gets removed from this container
		/// </summary>
		/// <seealso cref="ControlAdded" />
		public event EventHandler < ContainerControlEventArgs > ControlRemoved ;

		private void OnControlRemoved ( Control control )
		{
			control . Container = null ;
			ControlRemoved ? . Invoke ( this , new ContainerControlEventArgs ( control ) ) ;
		}

	}

}
