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
        static public bool serializeFlag = true;
        static public List<Parameter> outputList = new List<Parameter>();
        static public List<Parameter> parameterList = new List<Parameter>();



        protected void Page_Load(object sender, EventArgs e)
        {
                XMLSerializer ser = new XMLSerializer();
                parameterList = ser.DeserializeXml(@"W:/C#/JScntrl/JScntrl/Input.xml");
                foreach (var parameter in parameterList)
                {
                    outputList.Add(parameter);
                    AddUserParameter(parameter);
                }

            Button save = new Button();
            save.Text = "Сохранить";
            save.ID = "saveButton";
            save.Click += SaveClick;
            form1.Controls.Add(save);
        }


        private void AddUserParameter(Parameter parameter)
        {
            var parameterControl = (CommonParameterControl)LoadControl("UserControl.ascx");
            parameterControl.InitializeFields(parameter.Id, parameter.Name, parameter.Description, parameter.Type, parameter.Value);
            form1.Controls.Add(parameterControl);
        }

        private void SaveClick(object sender, EventArgs e)
        {

            if (serializeFlag)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Parameter>), new XmlRootAttribute("Parameters"));
                Parameter par = new Parameter();
                using (FileStream fs = new FileStream(@"W:/C#/JScntrl/JScntrl/Output.xml", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fs, outputList);
                }
            }
        }

    }
}