using System;
using System.Collections.Generic;
using PROGRAMSS.Param;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PROGRAMSS.Models
{  
 public class Image{
  
    [BsonId]
    public ObjectId Id { get; set; } 
    public string imageUrl {get; set;}
   [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId ApptId {get; set;}
 }
 
 
 }