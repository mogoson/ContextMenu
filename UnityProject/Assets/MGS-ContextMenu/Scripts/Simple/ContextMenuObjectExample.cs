/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuObjectExample.cs
 *  Description  :  Example of context menu object.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/26/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.ContextMenu
{
    [AddComponentMenu("MGS/ContextMenu/ContextMenuObjectExample")]
    public class ContextMenuObjectExample : ContextMenuObject
    {
        #region Field and Property
        protected int maxOffset = 3;
        #endregion

        #region Public Method
        public IEnumerable<string> CheckDisableMenuItems()
        {
            var disableItems = new List<string>();
            if (transform.localPosition.x >= maxOffset)
            {
                disableItems.Add(ContextMenuItemTags.ADD_POS_X);
            }
            else if (transform.localPosition.x <= -maxOffset)
            {
                disableItems.Add(ContextMenuItemTags.REDUCE_POS_X);
            }

            if (transform.localPosition.y >= maxOffset)
            {
                disableItems.Add(ContextMenuItemTags.ADD_POS_Y);
            }
            else if (transform.localPosition.y <= -maxOffset)
            {
                disableItems.Add(ContextMenuItemTags.REDUCE_POS_Y);
            }
            return disableItems;
        }

        public override void OnMenuItemClick(string tag)
        {
            if (tag.StartsWith(ContextMenuItemTags.POS_PREFIX))
            {
                var offset = Vector3.zero;
                switch (tag)
                {
                    case ContextMenuItemTags.ADD_POS_X:
                        offset = new Vector3(1, 0);
                        break;

                    case ContextMenuItemTags.REDUCE_POS_X:
                        offset = new Vector3(-1, 0);
                        break;

                    case ContextMenuItemTags.ADD_POS_Y:
                        offset = new Vector3(0, 1);
                        break;

                    case ContextMenuItemTags.REDUCE_POS_Y:
                        offset = new Vector3(0, -1);
                        break;
                }
                transform.localPosition += offset;
            }
            else if (tag.StartsWith(ContextMenuItemTags.COLOR_PREFIX))
            {
                var newColor = Color.white;
                switch (tag)
                {
                    case ContextMenuItemTags.SET_COLOR_BLUE:
                        newColor = Color.blue;
                        break;

                    case ContextMenuItemTags.SET_COLOR_GREEN:
                        newColor = Color.green;
                        break;

                    case ContextMenuItemTags.SET_COLOR_RED:
                        newColor = Color.red;
                        break;
                }
                transform.GetComponent<Renderer>().material.color = newColor;
            }
        }
        #endregion
    }
}