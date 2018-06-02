using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;

namespace ChatApplication.Custom
{
    public class CustomItemListFriends: SimpleListViewVisualItem
    {
        private RadLabelElement _name;
        private LightVisualElement _image;
        private StackLayoutPanel _panel;

        protected override void CreateChildElements()
        {
            base.CreateChildElements();
            _panel = new StackLayoutPanel()
            {
                Orientation = System.Windows.Forms.Orientation.Horizontal,
                //AutoSize = true,
                EqualChildrenWidth = true,
                ShouldHandleMouseInput = false,
                NotifyParentOnMouseInput = true
            };
            _image = new LightVisualElement();
            _panel.Children.Add(_image);
            _name = new RadLabelElement();
            _panel.Children.Add(_name);

        }

        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();
            this.Text = "";
            this._image.Image = (Image)this.Data[0];
            this._name.Text = Convert.ToString(this.Data[1]);
        }

        protected override Type ThemeEffectiveType => typeof(SimpleListViewVisualItem);
    }
}
