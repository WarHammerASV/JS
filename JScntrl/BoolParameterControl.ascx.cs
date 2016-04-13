using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JScntrl
{
    public partial class BoolParameterControl : System.Web.DynamicData.FieldTemplateUserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void InitializeFields(string id, string name, string description, string type, bool value)
        {
            Id.Text = id;
            Name.Text = name;
            Description.Text = description;
            parType.Text = type;
            Value.Checked = value;
        }
    }
}