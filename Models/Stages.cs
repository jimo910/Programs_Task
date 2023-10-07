using System;
using System.Collections.Generic;
using PROGRAMSS.Param;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PROGRAMSS.Models
{  
 public class Stages{

       [BsonId]
        public ObjectId Id { get; set; }
       public StagesType_FieldConstants.Stages_type StageType{get; set;}
       public bool ShowStage{get; set;}
      [BsonRepresentation(BsonType.ObjectId)]
      public ObjectId WorkFlowId { get; set; }

 }
 
}