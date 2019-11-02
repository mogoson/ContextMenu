/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuItemExtend.cs
 *  Description  :  Example of context menu item extend.
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
    [AddComponentMenu("MGS/ContextMenu/ContextMenuItemExtend")]
    [RequireComponent(typeof(LayoutElement))]
    public class ContextMenuItemExtend : ContextMenuItem
    {
        #region Field and Property
        private LayoutElement layoutElement;
        #endregion

        #region Protected Method
        protected override void Awake()
        {
            base.Awake();

            layoutElement = GetComponent<LayoutElement>();
        }
        #endregion

        #region Public Method
        public override bool Refresh(ContextMenuElementData data)
        {
            if (data is ContextMenuItemExtendData)
            {
                var itemData = data as ContextMenuItemExtendData;

                var colors = button.colors;
                colors.normalColor = itemData.normalColor;
                colors.highlightedColor = itemData.highlightedColor;

                button.colors = colors;
                itemText.color = itemData.textColor;
                layoutElement.preferredHeight = itemData.height;
            }
            return base.Refresh(data);
        }
        #endregion
    }

    public class ContextMenuItemExtendData : ContextMenuItemData
    {
        #region Field and Property
        public Color normalColor;
        public Color highlightedColor;
        public Color textColor;
        public int height;
        #endregion

        #region Public Method
        public ContextMenuItemExtendData(Color normalColor, Color highlightedColor, Color textColor, int height, string name, string tag, bool interactable = true) :
            base(name, tag, interactable)
        {
            this.normalColor = normalColor;
            this.highlightedColor = highlightedColor;
            this.textColor = textColor;
            this.height = height;
        }
        #endregion
    }
}