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
            var disables = new List<string>();
            if (transform.localPosition.x >= maxOffset)
            {
                disables.Add(ContextMenuItemTags.ADD_POS_X);
            }
            else if (transform.localPosition.x <= -maxOffset)
            {
                disables.Add(ContextMenuItemTags.REDUCE_POS_X);
            }

            if (transform.localPosition.y >= maxOffset)
            {
                disables.Add(ContextMenuItemTags.ADD_POS_Y);
            }
            else if (transform.localPosition.y <= -maxOffset)
            {
                disables.Add(ContextMenuItemTags.REDUCE_POS_Y);
            }
            return disables;
        }

        public override void OnMenuItemClick(string tag)
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
        #endregion
    }
}