using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Text;
using PROGRAMSS.FieldValidators;
using PROGRAMSS.Dtos;

 namespace PROGRAMSS.Validation{

   public  class ApplicationValidation{

         ApplicationValidator appt = new ApplicationValidator();
        ApplicationDtos apptValidDtos = new ApplicationDtos();

         public  ApplicationValidation( ApplicationDtos values){
                apptValidDtos = values; 
            }

   public  bool isTrue = true;
   public string invalidMessage="";
   public string total_invalid_message= "";

        private void Validate(){
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.FirstName,  apptValidDtos.FirstName, out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.LastName, apptValidDtos.LastName, out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage; 
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.Email, apptValidDtos.Email, out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage; 
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.Current_Residence, apptValidDtos.Current_Residence,  out  invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage; 
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.PhoneNumber, apptValidDtos.PhoneNumber,  out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;  
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.Date_of_Birth,  (apptValidDtos.Date_of_Birth).ToString(),  out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;    
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.Gender , (apptValidDtos.Gender).ToString(),  out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;  
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.Nationality, apptValidDtos.Nationality,  out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.ProgramId, (apptValidDtos.ProgramId).ToString(),  out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.Education_Description, apptValidDtos.Education_Description,  out invalidMessage);
             total_invalid_message = total_invalid_message +invalidMessage;
            isTrue = appt.ValidatorDel((int)FieldConstant.APPLICATIONField.Experience_Description, apptValidDtos.Experience_Description,  out invalidMessage);
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
