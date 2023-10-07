using System;
using System.Collections.Generic;
using PROGRAMSS.Param;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PROGRAMSS.Models
{  
 public class Workflow{

    [BsonId]
    public ObjectId Id { get; set; }
    
      [BsonIgnoreIfDefault]
 public List<Stages> Stagess { get; set; } = new List<Stages>(); 
 
      [BsonRepresentation(BsonType.ObjectId)]
      public ObjectId ProgramId { get; set; }



  
 }
 
}