﻿/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace WenceyWang . Richman4L . Maps
{
	public class MapObjectType
	{

		public virtual string Name { get; }

		public virtual Type EntryType { get; }

		internal MapObjectType ( string name , Type entryType )
		{
			#region Check Argument

			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) );
			}
			if ( entryType == null )
			{
				throw new ArgumentNullException ( nameof ( entryType ) );
			}

			#endregion

			Name = name;
			EntryType = entryType;
		}

	}
}
