/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuHandlerExample2.cs
 *  Description  :  Example of context menu handler.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/26/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UIForm;
using UnityEngine;

namespace MGS.ContextMenu
{
    [AddComponentMenu("MGS/ContextMenu/ContextMenuHandlerExample2")]
    public class ContextMenuHandlerExample2 : ContextMenuTriggerHandler
    {
        #region Field and Property
        private readonly IContextMenuElementData[] menuElementDatas = new IContextMenuElementData[]
        {
            new ContextMenuItemData("PositionX+", ContextMenuItemTags.ADD_POS_X),
            new ContextMenuItemData("PositionX-", ContextMenuItemTags.REDUCE_POS_X),
            new ContextMenuItemData("PositionY+", ContextMenuItemTags.ADD_POS_Y),
            new ContextMenuItemData("PositionY-", ContextMenuItemTags.REDUCE_POS_Y),
            new ContextMenuSeparatorData(),
            new ContextMenuItemData("Blue Color", ContextMenuItemTags.SET_COLOR_BLUE),
            new ContextMenuItemData("Green Color", ContextMenuItemTags.SET_COLOR_GREEN),
            new ContextMenuItemData("Red Color", ContextMenuItemTags.SET_COLOR_RED),
        };

        private IContextMenuForm menuForm;
        #endregion

        #region Private Method
        private void Start()
        {
            //Open menu by UIFormManager to create form instance.
            var formData = new ContextMenuFormData(Vector2.zero, menuElementDatas);
            menuForm = UIFormManager.Instance.OpenForm<ContextMenuForm>(formData);

            //Close it to hide the form instance.
            menuForm.Close();
        }
        #endregion

        #region Public Method
        public override IContextMenuForm OnMenuTriggerEnter(RaycastHit hitInfo)
        {
            var menuObject = hitInfo.transform.GetComponent<ContextMenuObjectExample>();
            if (menuObject == null)
            {
                return null;
            }

            var disableItems = menuObject.CheckDisableMenuItems();
            var formInfo = new ContextMenuFormInfo(Input.mousePosition, disableItems);
            menuForm.Open(formInfo);

            //Set the handler of menu form so that we can received the event on menu item click.
            menuForm.Handler = menuObject;
            return menuForm;
        }
        #endregion
    }
}