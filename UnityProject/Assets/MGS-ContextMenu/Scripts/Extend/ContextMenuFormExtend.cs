/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuFormExtend.cs
 *  Description  :  Example of context menu form extend.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/4/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.ContextMenu
{
    [AddComponentMenu("MGS/ContextMenu/ContextMenuFormExtend")]
    [RequireComponent(typeof(Image))]
    public class ContextMenuFormExtend : ContextMenuForm
    {
        #region Field and Property
        private Image bgImage;

        public Color BgColor
        {
            set { bgImage.color = value; }
            get { return bgImage.color; }
        }
        #endregion

        #region Protected Method
        protected override void Awake()
        {
            base.Awake();

            bgImage = GetComponent<Image>();
        }
        #endregion
    }
}