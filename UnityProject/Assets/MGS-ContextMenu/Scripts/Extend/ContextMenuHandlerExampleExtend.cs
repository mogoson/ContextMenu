/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuHandlerExampleExtend.cs
 *  Description  :  Example of context menu handler.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/4/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UIForm;
using UnityEngine;

namespace MGS.ContextMenu
{
    [AddComponentMenu("MGS/ContextMenu/ContextMenuHandlerExampleExtend")]
    public class ContextMenuHandlerExampleExtend : ContextMenuTriggerHandler
    {
        #region Field and Property
        private readonly IContextMenuElementData[] menuElementDatas = new IContextMenuElementData[]
        {
            new ContextMenuItemExtendData(Color.black,Color.blue,Color.white,30,"PositionX+", ContextMenuItemTags.ADD_POS_X),
            new ContextMenuItemExtendData(Color.black,Color.blue,Color.white,30,"PositionX-", ContextMenuItemTags.REDUCE_POS_X),
            new ContextMenuSeparatorExtendData(Color.yellow,1),
            new ContextMenuItemExtendData(Color.black,Color.blue,Color.white,30,"PositionY+", ContextMenuItemTags.ADD_POS_Y),
            new ContextMenuItemExtendData(Color.black,Color.blue,Color.white,30,"PositionY-", ContextMenuItemTags.REDUCE_POS_Y),
            new ContextMenuSeparatorExtendData(Color.red,2),
            new ContextMenuItemExtendData(Color.black,Color.blue,Color.white,30,"Blue Color", ContextMenuItemTags.SET_COLOR_BLUE),
            new ContextMenuItemExtendData(Color.black,Color.blue,Color.white,30,"Green Color", ContextMenuItemTags.SET_COLOR_GREEN),
            new ContextMenuItemExtendData(Color.black,Color.blue,Color.white,30,"Red Color", ContextMenuItemTags.SET_COLOR_RED),
        };

        private IContextMenuForm menuForm;
        #endregion

        #region Private Method
        private void Start()
        {
            //Open menu by UIFormManager to create form instance.
            var formData = new ContextMenuFormExtendData(Color.black, Vector2.zero, menuElementDatas);
            menuForm = UIFormManager.Instance.OpenForm<ContextMenuFormExtend>(formData);

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