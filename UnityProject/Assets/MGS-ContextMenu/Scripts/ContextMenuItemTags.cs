﻿/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuItemTags.cs
 *  Description  :  Define tags of context menu items.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/26/2019
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.ContextMenu
{
    public static class ContextMenuItemTags
    {
        //Position.
        public const string ADD_POS_X = "PositionX+";
        public const string REDUCE_POS_X = "PositionX-";
        public const string ADD_POS_Y = "PositionY+";
        public const string REDUCE_POS_Y = "PositionY-";

        //Color.
        public const string SET_COLOR_BLUE = "BlueColor";
        public const string SET_COLOR_GREEN = "GreenColor";
        public const string SET_COLOR_RED = "RedColor";
    }
}