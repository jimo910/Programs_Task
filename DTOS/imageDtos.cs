
using System;
using PROGRAMSS.Param;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PROGRAMSS.Dtos {

   public record  ImageDtos {
    public IFormFile imageFile{get; set;}
    public ObjectId ApptId{get; set;}

   }

}