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
using System.Collections.Generic;
using UnityEngine;

namespace MGS.ContextMenu
{
    [AddComponentMenu("MGS/ContextMenu/ContextMenuHandlerExample1")]
    public class ContextMenuHandlerExample1 : ContextMenuTriggerHandler, IContextMenuFormHandler
    {
        #region Field and Property
        protected Transform target;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            //Define items of menu.
            var formData = new ContextMenuFormData(Vector2.zero, new List<ContextMenuItemData>()
            {
                new ContextMenuItemData("Blue Color", ContextMenuItemTags.SET_COLOR_BLUE),
                new ContextMenuItemData("Green Color", ContextMenuItemTags.SET_COLOR_GREEN),
                new ContextMenuItemData("Red Color", ContextMenuItemTags.SET_COLOR_RED),
            });

            //Open menu by UIFormManager to create form instance.
            currentMenuForm = UIFormManager.Instance.OpenForm<ContextMenuForm>(formData);

            //Close it to hide the form instance.
            currentMenuForm.Close();

            //Set the handler of menu form so that we can received the event on menu item click.
            currentMenuForm.Handler = this;
        }
        #endregion

        #region Public Method
        public override void OnMenuTriggerEnter(RaycastHit hitInfo)
        {
            //Use hitInfo to decide open menu form or not if need.
            //Open menu form for any object just for example.

            target = hitInfo.transform;
            currentMenuForm.Open(Input.mousePosition);
        }

        public virtual void OnMenuItemClick(string tag)
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