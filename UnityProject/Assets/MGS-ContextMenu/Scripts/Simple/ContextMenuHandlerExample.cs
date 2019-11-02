/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuHandlerExample.cs
 *  Description  :  Example of context menu handler.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/26/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UIForm;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.ContextMenu
{
    [AddComponentMenu("MGS/ContextMenu/ContextMenuHandlerExample")]
    public class ContextMenuHandlerExample : ContextMenuTriggerHandler, IContextMenuFormHandler
    {
        #region Field and Property
        private IContextMenuForm menuForm;
        private Transform target;
        private int maxOffset = 3;
        #endregion

        #region Private Method
        private void Start()
        {
            //Open menu by UIFormManager to create form instance.
            menuForm = UIFormManager.Instance.OpenForm<ContextMenuForm>();

            //Close it to hide the form instance.
            menuForm.Close();

            //Set the handler of menu form so that we can received the event on menu item click.
            menuForm.Handler = this;
        }

        private IEnumerable<string> CheckDisableMenuItems()
        {
            var disableItems = new List<string>();
            if (target.localPosition.x >= maxOffset)
            {
                disableItems.Add(ContextMenuItemTags.ADD_POS_X);
            }
            else if (target.localPosition.x <= -maxOffset)
            {
                disableItems.Add(ContextMenuItemTags.REDUCE_POS_X);
            }

            if (target.localPosition.y >= maxOffset)
            {
                disableItems.Add(ContextMenuItemTags.ADD_POS_Y);
            }
            else if (target.localPosition.y <= -maxOffset)
            {
                disableItems.Add(ContextMenuItemTags.REDUCE_POS_Y);
            }
            return disableItems;
        }
        #endregion

        #region Public Method
        public override IContextMenuForm OnMenuTriggerEnter(RaycastHit hitInfo)
        {
            //Use hitInfo to decide open menu form or not if need.
            //Open menu form for any object just for example.

            target = hitInfo.transform;

            var disableItems = CheckDisableMenuItems();
            menuForm.DisableItems(disableItems);

            menuForm.Open();
            menuForm.SetPosition(Input.mousePosition);
            return menuForm;
        }

        public void OnMenuItemClick(string tag)
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
            target.localPosition += offset;
        }
        #endregion
    }
}