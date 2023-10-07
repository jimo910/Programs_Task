
using System;
using PROGRAMSS.Param;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PROGRAMSS.Dtos {

   public record  ApplicationDtos {

    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email{get; set;}
    public string Current_Residence{get; set;}
    public string PhoneNumber{get; set;}
    public DateTime Date_of_Birth{ get; set; }
    public  Gender_FieldConstants.Gender_type  Gender {get; set;}
    public string  Nationality{get; set;}
    public ObjectId  ProgramId{get; set;}
    public string Education_Description{get; set;}
    public string Experience_Description{get; set;}

     
    }

}