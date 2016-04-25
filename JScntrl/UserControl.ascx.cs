using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JScntrl
{
    public partial class CommonParameterControl : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void InitializeFields(string id, string name, string description, string type, string value)
        {
            Id.Text = id;
            Name.Text = name;
            Description.Text = description;
            parType.Text = type;
            if (type == "System.Boolean")
            {
                var boolBox = new CheckBox();

                typeValue.Controls.Add(boolBox);
                boolBox.Checked = Convert.ToBoolean(value);
                boolBox.AutoPostBack = true;
                boolBox.CheckedChanged += UpdateBox;
            }
            else
               if (type == "System.String")
            {
                var textBox = new TextBox();

                typeValue.Controls.Add(textBox);
                textBox.Text = value;
                textBox.Attributes["maxLength"] = "10";
            }
            else
                   if (type == "System.Int32")
            {
                var textBox = new TextBox();

                typeValue.Controls.Add(textBox);
                textBox.Text = value;
                textBox.Attributes["onKeyUp"] = "javascript:IntegerValidation(this);";
            }
        }

        protected void UpdateBox(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                var field = (CheckBox)sender;
                var count = 0;
                if (field.Checked) count++;
                
            }
            else
            {
                throw new NotImplementedException();
            }    
        }
    
    }
}