using System;
using System.Collections.Generic;
using PROGRAMSS.Param;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PROGRAMSS.Models
{  
 public class Questions{
  
   [BsonId]
    public ObjectId Id { get; set; } 
    public string Title {get; set;}
    public string Description {get; set;}
    
   [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId ApplicationId { get; set; }
 }
 
}