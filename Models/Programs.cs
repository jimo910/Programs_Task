using System;
using System.Collections.Generic;
using PROGRAMSS.Param;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace PROGRAMSS.Models
{  
 public class Programs{
  
    [BsonId]
    public ObjectId Id { get; set; } 
    public string Title {get; set;}
    public string Summary {get; set;}
    public string Description{get; set;}
    public string Benefit{get; set;}
    public string Application_criteria{get; set;}
    public Program_FieldConstants.program_type Type{get; set;}
    public Qualification_FieldConstants.Qualification Qualification{get; set;}
    public DateTime Program_starts{ get; set; }
    public DateTime Application_opens { get; set; }
    public DateTime Application_closes { get; set; }
    public string Duration{get; set;}
    public int No_of_application{get; set;}
    public string Program_locations{get; set;}


    [BsonIgnoreIfDefault]
     public List<Application> Applications { get; set; } = new List<Application>();

   [BsonIgnoreIfDefault]
     public List<Workflow> WORKFLOW { get; set; } = new List<Workflow>();

   
}

}