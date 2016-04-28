using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace JScntrl
{
    public class Validation
    {
        public List<Parameter> parameterList;
        public Dictionary<string, Label> boolLabelsDict;
        public Dictionary<string, Label> stringLabelsDict;
        public Dictionary<string, Label> intLabelsDict;

        public Validation(List<Parameter> parameterList)
        {
            this.parameterList = new List<Parameter>(parameterList);
            boolLabelsDict = new Dictionary<string, Label>();
            stringLabelsDict = new Dictionary<string, Label>();
            intLabelsDict = new Dictionary<string, Label>();
        }

        public void ValidateBooleanEditField(bool checkBoxCheked, string checkBoxID)
        {
            //Находим в списке контролов наш чекбокс по id, изменяем его значение (в статическом поле, чтобы все остальные экземпляры знали это).
            foreach (var parameter in parameterList)
            {
                if (parameter.Id == checkBoxID)
                {
                    parameter.Value = checkBoxCheked ? "True" : "False";  
                    break;
                }
            }
            //Если галка была снята при нажатии, то нужно проверить, есть ли вообще хоть одна галка среди всех чекбоксов.
            if (!checkBoxCheked)
            {
                foreach (var parameter in parameterList)
                    if (parameter.Type == "System.Boolean" && parameter.Value == "True")
                        return;
                boolLabelsDict[checkBoxID].Text = "Oh, nooo!!! At least one checkBox should be True!";
            }
            //А если галка была установлена, то надо во всех лейблах текст стереть.
            else
                foreach (var keyValuePair in boolLabelsDict)
                    keyValuePair.Value.Text = "";
        }

        public void ValidateStringEditField(string text, string textBoxID)
        {
            if (text.Length > 10)
                stringLabelsDict[textBoxID].Text = "String length is over than 10 symbols";
            else
                stringLabelsDict[textBoxID].Text = "";
        }

        public void ValidateIntEditField(string numberStr, string textBoxID)
        {
            double userNumber = Double.Parse(numberStr);
            if (userNumber < -1000 || userNumber > 1000)
                intLabelsDict[textBoxID].Text = "Number in this field should be in range [-1000, 1000]! Change it!";
            else
                intLabelsDict[textBoxID].Text = "";
        }

        public void RemoveById(string ID)
        {
            Parameter p = parameterList[0];
            foreach (var parameter in parameterList)
                if (parameter.Id == ID)
                {
                    p = parameter;
                    break;
                }
            parameterList.Remove(p);
            if (boolLabelsDict.ContainsKey(ID))
                boolLabelsDict.Remove(ID);
            if (stringLabelsDict.ContainsKey(ID))
                stringLabelsDict.Remove(ID);
            if (intLabelsDict.ContainsKey(ID))
                intLabelsDict.Remove(ID);
        }

        //Если на форме есть несколько булевых контролов, и только у одного стоит галка, то его можно удалить. Останутся контролы без галок.
        //Тогда надо это отловить.
        public void ValidateBooleanEditFieldsAfterRemoving()
        {
            foreach (var parameter in parameterList)
                if (parameter.Type == "System.Boolean" && parameter.Value == "True")
                    return;
            if (boolLabelsDict.Count > 0)
                boolLabelsDict.ElementAt(0).Value.Text = "Oh, nooo!!! At least one checkBox should be True!";
        }
    }
}