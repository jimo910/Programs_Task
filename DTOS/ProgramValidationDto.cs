


using System;
using PROGRAMSS.FieldValidators;
using PROGRAMSS.Param;
namespace PROGRAMSS.Dtos {

   public record  ProgramValidationDtos {

     public string Title {get; set;}
    public string Description {get; set;}
    public DateTime Application_opens { get; set; }
    public DateTime Application_closes { get; set; }
   public Program_FieldConstants.program_type Type{get; set;}
     public string Program_locations{get; set;}
    }

}



