using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Text;
using PROGRAMSS.FieldValidators;
using PROGRAMSS.Dtos;

 namespace PROGRAMSS.Validation{

   public  class programValidation{

         ProgramValidator prog = new ProgramValidator();
         ProgramValidationDtos ProgValidDtos = new ProgramValidationDtos();

         public  programValidation( ProgramValidationDtos values){
                ProgValidDtos = values; 
            }

   public  bool isTrue = true;
    public string invalidMessage="";
    public string total_invalid_message= "";

        private void Validate(){

            isTrue = prog.ValidatorDel((int)FieldConstants.PROGRAMField.Type, ProgValidDtos.Type.ToString(), out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;
            isTrue = prog.ValidatorDel((int)FieldConstants.PROGRAMField.Title, ProgValidDtos.Title, out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage; 
            isTrue = prog.ValidatorDel((int)FieldConstants.PROGRAMField.Description, ProgValidDtos.Description, out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage; 
            isTrue = prog.ValidatorDel((int)FieldConstants.PROGRAMField.Application_opens, ProgValidDtos.Application_opens.ToString(), out  invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage; 
            isTrue = prog.ValidatorDel((int)FieldConstants.PROGRAMField.Application_closes, ProgValidDtos.Application_closes.ToString(),  out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;  
            isTrue = prog.ValidatorDel((int)FieldConstants.PROGRAMField.Program_locations, ProgValidDtos.Program_locations,  out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;      
        }

public bool to_return(){

    Validate();
    return (total_invalid_message == "");  
}

public string invalidMessageFunc(){
    return total_invalid_message;
}

    }
 }
