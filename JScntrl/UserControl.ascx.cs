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
<<<<<<< HEAD
        static int count = -1;
=======
>>>>>>> c3dc9c64e55dee62bb85ed534b644f2c922dc502
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
<<<<<<< HEAD
                if (value == "True")
                    count++;
=======
>>>>>>> c3dc9c64e55dee62bb85ed534b644f2c922dc502
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
<<<<<<< HEAD
                if (field.Checked)
                    count++;
                if (field.Checked == false)
                    count--;
                errorLabel.Text = count == 0 ? "Поставьте галку" : "";
            }

            else
            {
                throw new NotImplementedException();
            }
            count--;
        }

=======
                var count = 0;
                if (field.Checked) count++;
                
            }
            else
            {
                throw new NotImplementedException();
            }    
        }
    
>>>>>>> c3dc9c64e55dee62bb85ed534b644f2c922dc502
    }
}