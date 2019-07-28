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
        #region Protected Method
        protected virtual void Start()
        {
            //ContextMenuForm is already built complete in editor.
            //Just open it by UIFormManager to create form instance.
            currentMenuForm = UIFormManager.Instance.OpenForm<ContextMenuForm>();

            //Close it to hide the form instance.
            currentMenuForm.Close();
        }
        #endregion

        #region Public Method
        public override void OnMenuTriggerEnter(RaycastHit hitInfo)
        {
            var menuObject = hitInfo.transform.GetComponent<ContextMenuObjectExample>();
            if (menuObject == null)
            {
                return;
            }

            //Set the handler of menu form so that we can received the event on menu item click.
            currentMenuForm.Handler = menuObject;

            var disables = menuObject.CheckDisableMenuItems();
            var formInfo = new ContextMenuFormInfo(Input.mousePosition, disables);
            currentMenuForm.Open(formInfo);
        }
        #endregion
    }
}