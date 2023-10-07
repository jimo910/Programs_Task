using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace  PROGRAMSS.FieldValidators
{
    public class ProgramValidator:IFieldValidator
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

        public ProgramValidator()
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

            FieldConstants.PROGRAMField programValidationField = (FieldConstants.PROGRAMField)fieldIndex;

            switch (programValidationField)
            {
                case FieldConstants.PROGRAMField.Type:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.PROGRAMField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.PROGRAMField.Title:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.PROGRAMField), programValidationField)}{Environment.NewLine}" : "";
                    break;
               case FieldConstants.PROGRAMField.Description:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.PROGRAMField), programValidationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.PROGRAMField.Application_closes:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.PROGRAMField), programValidationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDel(fieldValue, out DateTime validDateTime)) ? $"You did not enter a valid date" : fieldInvalidMessage;
                    break;
                case FieldConstants.PROGRAMField.Application_opens:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.PROGRAMField), programValidationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDel(fieldValue, out DateTime opeValidDateTime)) ? $"You did not enter a valid date" : fieldInvalidMessage;
                    break;
                case FieldConstants.PROGRAMField.Program_locations:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.PROGRAMField), programValidationField)}{Environment.NewLine}" : "";
                    break;
           
                default:
                    throw new ArgumentException("This field does not exists");

            }

            return (fieldInvalidMessage == "");
 
        }
    }
}
