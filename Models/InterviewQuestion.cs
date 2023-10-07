using System;
using System.Collections.Generic;
using PROGRAMSS.Param;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PROGRAMSS.Models
{  
 public class InterviewQuestion{

     [BsonId]
     public ObjectId Id { get; set; }
     public DurationsType_FieldConstants.Durations_type durationType{get; set;}
     public int No_of_days_to_deadline{get; set;}
     public int Max_duration{get; set;}
     public string InterviewQuestions{get; set;}
     public string info_InterviewQuestion{get; set;}
     [BsonRepresentation(BsonType.ObjectId)]
     public ObjectId StageId { get; set; }

 }
 
}