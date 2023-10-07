using System;
using System.Collections.Generic;
using System.Text;

namespace PROGRAMSS.FieldValidators
{
   // public delegate bool FieldValidatorDel(int fieldIndex,  int update , string fieldValue, string[] fieldArray, out string fieldInvalidMessage);
    public delegate bool FieldValidatorDel(int fieldIndex,  string fieldValue,  out string fieldInvalidMessage);

    public interface IFieldValidator
    {
        void InitialiseValidatorDelegates();
       // string[] FieldArray { get; }
        FieldValidatorDel ValidatorDel { get; }

    }
}
