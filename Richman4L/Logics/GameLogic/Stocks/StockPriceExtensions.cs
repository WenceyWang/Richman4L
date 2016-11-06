﻿using System ;
using System . Collections ;
using System . Linq ;

namespace WenceyWang . Richman4L .Stocks
{

	public static class StockPriceExtensions
	{

		public static long ToLongCelling ( this decimal price ) => Convert . ToInt64 ( decimal . Ceiling ( price ) ) ;

		public static long ToLongFloor ( this decimal price ) => Convert . ToInt64 ( decimal . Floor ( price ) ) ;

	}

}
