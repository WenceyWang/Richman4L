﻿using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Maps
{
	/// <summary>
	/// 指示地图的绘制器
	/// </summary>
	public interface IMapDrawer
	{

		void DrawerCatched ( );


		void SetMap ( Map map ) ;

		Map Target { get; }
	}
}
