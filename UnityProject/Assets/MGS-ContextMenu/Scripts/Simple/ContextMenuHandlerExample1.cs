/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuHandlerExample1.cs
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
    [AddComponentMenu("MGS/ContextMenu/ContextMenuHandlerExample1")]
    public class ContextMenuHandlerExample1 : ContextMenuTriggerHandler, IContextMenuFormHandler
    {
        #region Field and Property
        private readonly ContextMenuElementData[] menuElementDatas = new ContextMenuElementData[]
        {
            new ContextMenuItemData("Blue Color", ContextMenuItemTags.SET_COLOR_BLUE),
            new ContextMenuItemData("Green Color", ContextMenuItemTags.SET_COLOR_GREEN),
            new ContextMenuItemData("Red Color", ContextMenuItemTags.SET_COLOR_RED),
        };

        private IContextMenuForm menuForm;
        private Transform target;
        #endregion

        #region Private Method
        private void Start()
        {
            //Open menu by UIFormManager to create form instance.
            menuForm = UIFormManager.Instance.OpenForm<ContextMenuForm>();
            menuForm.RefreshElements(menuElementDatas);

            //Close it to hide the form instance.
            menuForm.Close();

            //Set the handler of menu form so that we can received the event on menu item click.
            menuForm.Handler = this;
        }
        #endregion

        #region Public Method
        public override IContextMenuForm OnMenuTriggerEnter(RaycastHit hitInfo)
        {
            //Use hitInfo to decide open menu form or not if need.
            //Open menu form for any object just for example.

            target = hitInfo.transform;
            menuForm.SetPosition(Input.mousePosition);
            menuForm.Open();
            return menuForm;
        }

        public void OnMenuItemClick(string tag)
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
            target.GetComponent<Renderer>().material.color = newColor;
        }
        #endregion
    }
}