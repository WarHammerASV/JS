using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

namespace JScntrl
{
    public partial class Main : System.Web.UI.Page
    {
        static public List<Parameter> outputList = new List<Parameter>();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                XMLSerializer ser = new XMLSerializer();
                List<Parameter> parametersList = ser.DeserializeXml("W:/C#/JScntrl/JScntrl/Input.xml");
                foreach (var parameter in parametersList)
                {
                    if (parameter.Type == "System.Boolean")
                    {
                        outputList.Add(parameter);
                        AddBoleanParameter(parameter);
                    }
                    else
                    {
                        outputList.Add(parameter);
                        AddStringOrIntParameter(parameter);
                    }
                }
            }

            Button save = new Button();
            save.Text = "Сохранить";
            save.ID = "saveButton";
            save.Click += SaveClick;
            form1.Controls.Add(save);
        }

        private void AddBoleanParameter(Parameter parameter)
        {
            var boolParameter = (BoolParameterControl)LoadControl("BoolParameterControl.ascx");
            boolParameter.InitializeFields(parameter.Id, parameter.Name, parameter.Description, parameter.Type, IsValueContainTrue(parameter.Value));
            form1.Controls.Add(boolParameter);
        }

        private void AddStringOrIntParameter(Parameter parameter)
        {
            var parameterControl = (CommonParameterControl)LoadControl("UserControl.ascx");
            parameterControl.InitializeFields(parameter.Id, parameter.Name, parameter.Description, parameter.Type, parameter.Value);
            form1.Controls.Add(parameterControl);
        }

        private static bool IsValueContainTrue(string value)
        {
            return value == "True" ? true : false;
        }

        private void SaveClick(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Parameter>), new XmlRootAttribute("Parameters"));
            Parameter par = new Parameter();           
            using (FileStream fs = new FileStream("W:/C#/JScntrl/JScntrl/Output.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs,outputList);
            }
        }
    }
}