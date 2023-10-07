using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace  PROGRAMSS.FieldValidators
{
    public class ApplicationValidator:IFieldValidator
    {


        FieldValidatorDel  _fieldValidatorDel = null;
        RequiredValidDel _requiredValidDel = null;
        StringLengthValidDel _stringLenthValidDel = null;
        DateValidDel _dateValidDel = null;
    
        
       // string[] _fieldArray = null;
      //  IRegister _register = null;

      /*  public string[] FieldArray
        {
            get
            {
                if (_fieldArray == null)
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.PROGRAMField)).Length];
                return _fieldArray;
            }
        }*/

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

        public ApplicationValidator()
        {
            InitialiseValidatorDelegates();
        }

        public void InitialiseValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidField);
            _requiredValidDel = CommonFieldValidatorFunctions.RequiredFieldValidDel;
            _stringLenthValidDel = CommonFieldValidatorFunctions.StringLengthFieldValidDel;
            _dateValidDel = CommonFieldValidatorFunctions.DateFieldValidDel;
        
        }

        private bool ValidField(int fieldIndex, string fieldValue,  out string fieldInvalidMessage)
        {

            fieldInvalidMessage = "";

           FieldConstant.APPLICATIONField programValidationField = (FieldConstant.APPLICATIONField)fieldIndex;

            switch (programValidationField)
            {
                case FieldConstant.APPLICATIONField.FirstName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.APPLICATIONField.LastName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
               case FieldConstant.APPLICATIONField.Email:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.APPLICATIONField.Date_of_Birth:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDel(fieldValue, out DateTime validDateTime)) ? $"You did not enter a valid date" : fieldInvalidMessage;
                    break;          
                 case FieldConstant.APPLICATIONField.Current_Residence:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.APPLICATIONField.PhoneNumber:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.APPLICATIONField.Gender:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.APPLICATIONField.Nationality:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.APPLICATIONField.ProgramId:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
               case FieldConstant.APPLICATIONField.Education_Description:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstant.APPLICATIONField.Experience_Description:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstant.APPLICATIONField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                default:
                    throw new ArgumentException("This field does not exists");

            }

            return (fieldInvalidMessage == "");
 
        }
    }
}
