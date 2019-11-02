/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuSeparatorExtend.cs
 *  Description  :  Example of context menu separator extend.
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
    [AddComponentMenu("MGS/ContextMenu/ContextMenuSeparatorExtend")]
    [RequireComponent(typeof(Image), typeof(LayoutElement))]
    public class ContextMenuSeparatorExtend : ContextMenuSeparator
    {
        #region Field and Property
        private Image bgImage;
        private LayoutElement layoutElement;
        #endregion

        #region Protected Method
        protected override void Awake()
        {
            base.Awake();

            bgImage = GetComponent<Image>();
            layoutElement = GetComponent<LayoutElement>();
        }
        #endregion

        #region Public Method
        public override bool Refresh(ContextMenuElementData data)
        {
            if (data is ContextMenuSeparatorExtendData)
            {
                var itemData = data as ContextMenuSeparatorExtendData;
                bgImage.color = itemData.bgColor;
                layoutElement.preferredHeight = itemData.height;
            }
            return base.Refresh(data);
        }
        #endregion
    }

    public class ContextMenuSeparatorExtendData : ContextMenuSeparatorData
    {
        #region Field and Property
        public Color bgColor;
        public int height;
        #endregion

        #region Public Method
        public ContextMenuSeparatorExtendData(Color bgColor, int height)
        {
            this.bgColor = bgColor;
            this.height = height;
        }
        #endregion
    }
}