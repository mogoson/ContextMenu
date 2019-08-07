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

using System.Collections.Generic;
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
        #endregion

        #region Protected Method
        protected override void Initialize()
        {
            base.Initialize();
            bgImage = GetComponent<Image>();
        }
        #endregion

        #region Public Method
        public override bool Refresh(object data)
        {
            if (data is ContextMenuFormExtendData)
            {
                var formData = data as ContextMenuFormExtendData;
                bgImage.color = formData.bgColor;
            }
            return base.Refresh(data);
        }
        #endregion
    }

    public class ContextMenuFormExtendData : ContextMenuFormData
    {
        #region Field and Property
        public Color bgColor;
        #endregion

        #region Public Method
        public ContextMenuFormExtendData(Color bgColor, Vector2 position, IEnumerable<IContextMenuElementData> elementDatas)
            : base(position, elementDatas)
        {
            this.bgColor = bgColor;
        }
        #endregion
    }
}