



using System;
using PROGRAMSS.Param;

namespace PROGRAMSS.Dtos {

   public record  programDTOS {


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
     
     
    }

}

