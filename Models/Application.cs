using System;
using System.Collections.Generic;
using PROGRAMSS.Param;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PROGRAMSS.Models
{  
 public class Application{
  
    [BsonId]
    public ObjectId Id { get; set; } 
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email{get; set;}
    public string Current_Residence{get; set;}
    public string PhoneNumber{get; set;}
    public DateTime Date_of_Birth{ get; set; }
    public  Gender_FieldConstants.Gender_type  Gender {get; set;}
    public string  Nationality{get; set;}  
    public string ImageUrl { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
      public ObjectId ProgramId { get; set; }

    [BsonIgnoreIfDefault]
     public List<Profile> Profiles { get; set; } = new List<Profile>();

    [BsonIgnoreIfDefault]
      public List<Questions> QuestionS { get; set; } = new List<Questions>();
     
   // public Profile Education{get; set;}
   // public Profile Experience{get; set;}
   // public List<Profile> Profiles{get; set;}
   // public List<Questions> Questions{get; set;}
   // public Programs Programss {get; set;}
}

}