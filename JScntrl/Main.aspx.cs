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
        protected void Page_Load(object sender, EventArgs e)
        {
            XMLSerializer ser = new XMLSerializer();
            List<Parameter> parametersList = ser.DeserializeXml("W:/C#/JScntrl/JScntrl/Input.xml");
            foreach (var parameter in parametersList)
            {
                if (parameter.Type == "System.Boolean")
                    AddBoleanParameter(parameter);
                else
                    AddStringOrIntParameter(parameter);
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

        public void SaveClick(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Parameter>));
            Parameter par = new Parameter();
            List<Parameter> outputList = new List<Parameter>();
            using (FileStream fs = new FileStream("W:/C#/JScntrl/JScntrl/Output.xml", FileMode.OpenOrCreate))
            {
                //foreach (var control in form1.Controls)
                //{            
                    //par.Id = "a";
                    //par.Name = "a";
                    //par.Type = "g";
                    //par.Value = "lol";
                    //outputList.Add(par);               
                //}
                
                    serializer.Serialize(fs,outputList);

            }

        }
    }
}