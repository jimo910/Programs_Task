using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PROGRAMSS.Validation;
using  PROGRAMSS.Models;
using  PROGRAMSS.Dtos;
using  PROGRAMSS.Param;
using   MongoDB.Driver;
using Microsoft.AspNetCore.Hosting;

namespace PROGRAMSS.Controllers{



[ApiController]
[Route("[controller]")]
public class PROGRAMSSController : ControllerBase
{

    private readonly IWebHostEnvironment  _webHostEnvironment;

   public PROGRAMSSController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }


[HttpGet("Programs/GetProgramSummary")]
public List<ProgramDtos> GetPrograms(ObjectId Id){

    List<ProgramDtos> ListProgramDtos = new List<ProgramDtos>();
    var client = new MongoClient("mongodb://localhost:27017"); // Replace with your MongoDB connection string
    var database = client.GetDatabase("ProgramDB");
    var ProgramsCollection = database.GetCollection<Programs>("programs");
   var ProgramModel = ProgramsCollection.Find(new BsonDocument()).ToList();
  
    foreach( var prog in ProgramModel){
        ProgramDtos progDtos = new ProgramDtos();
        progDtos.Title = prog.Title;
        progDtos.Summary = prog.Summary;
        progDtos.Description = prog.Description;
        progDtos.Application_criteria = prog.Application_criteria;
        progDtos.Benefit = prog.Benefit;
        ListProgramDtos.Add(progDtos);
   }
 
    return ListProgramDtos;  

}


[HttpGet("Programs/GETPROGRAM")]
public IEnumerable<Programs> GetProgram(){

    var client = new MongoClient("mongodb://localhost:27017"); // MongoDB connection string
    var database = client.GetDatabase("ProgramDB");
    var ProgramsCollection = database.GetCollection<Programs>("programs");
   var ProgramModel = ProgramsCollection.Find(new BsonDocument()).ToList();
   return ProgramModel;

   }



[HttpGet("Programs/GETApplication")]
public IEnumerable<Application> GetApplication(){

    var client = new MongoClient("mongodb://localhost:27017"); // MongoDB connection string
    var database = client.GetDatabase("ProgramDB");
    var ApplicationsCollection = database.GetCollection<Application>("applications");
   var ProgramModel = ApplicationsCollection.Find(new BsonDocument()).ToList();
   return ProgramModel;

   }


[HttpGet("workflow/GETWorkflow")]
public IEnumerable<Workflow> GetWorkflow(){

    var client = new MongoClient("mongodb://localhost:27017"); // connection string
    var database = client.GetDatabase("ProgramDB");
    var WorkFLowsCollection = database.GetCollection<Workflow>("Workflows");
   var workFlowModel = WorkFLowsCollection.Find(new BsonDocument()).ToList();
   return  workFlowModel;

   }


   [HttpGet("workflows/GETStages")]
public IEnumerable<Stages> GETStages(){

    var client = new MongoClient("mongodb://localhost:27017");   // MongoDB connection string
    var database = client.GetDatabase("ProgramDB");
    var StagesCollection = database.GetCollection<Stages>("Stages");
   var StageModel =  StagesCollection.Find(new BsonDocument()).ToList();
   return StageModel;

   }


 [HttpGet("workflows/GETInterviewQuestions")]
public IEnumerable<InterviewQuestion> GETIquestions(){

    var client = new MongoClient("mongodb://localhost:27017");   // MongoDB connection string
    var database = client.GetDatabase("ProgramDB");
    var IQuestionCollection = database.GetCollection<InterviewQuestion>("Iquestions");
   var IQuestionModel =  IQuestionCollection.Find(new BsonDocument()).ToList();
   return IQuestionModel;

   }



[HttpPost("Register/Program")]
  public IActionResult RegisterProgram([FromBody]  programDTOS newProgram)
    {
         
               var client = new MongoClient("mongodb://localhost:27017"); // MongoDB connection string
               var database = client.GetDatabase("ProgramDB");
              var ProgramsCollection = database.GetCollection<Programs>("programs");


           ProgramValidationDtos programValidationDTOS = new ProgramValidationDtos{
                   Title = newProgram.Title,
                    Description = newProgram.Description,
                    Type = newProgram.Type,
                   Application_opens= newProgram.Application_opens,
                   Application_closes= newProgram.Application_closes,
                   Program_locations = newProgram.Program_locations
                };

            programValidation validDateProg =  new programValidation(programValidationDTOS);

              if(!(validDateProg.to_return())){
                return Ok(validDateProg.invalidMessageFunc());
              }else{

        Programs programss = new Programs
                {
                    Title = newProgram.Title,
                    Summary = newProgram.Summary,
                    Description = newProgram.Description,
                    Benefit = newProgram.Application_criteria,
                    Application_criteria = newProgram.Application_criteria,
                    Type = newProgram.Type,
                   Qualification= newProgram.Qualification,
                   Program_starts = newProgram.Program_starts,
                   Application_opens= newProgram.Application_opens,
                   Application_closes= newProgram.Application_closes,
                   Duration = newProgram.Duration,
                   No_of_application = newProgram.No_of_application,
                   Program_locations = newProgram.Program_locations
                };
            
              // add it to database.
            ProgramsCollection.InsertOne(programss);
         return Ok("Program Added successfully.");
         }
      

}


[HttpPost("Register/Workflow")]
  public IActionResult RegisterWorkflow([FromBody] Workflow newWorkflow)
    {
         
               var client = new MongoClient("mongodb://localhost:27017"); // MongoDB connection string
               var database = client.GetDatabase("ProgramDB");
               var WorkFLowsCollection = database.GetCollection<Workflow>("Workflows");


            Workflow WF = new Workflow{
              ProgramId = newWorkflow.ProgramId

            };
            
              // add it to database.
         WorkFLowsCollection.InsertOne(WF);
         return Ok("WORKFLOW Added successfully.");
      

}

[HttpPost("Register/Stages")]
  public IActionResult RegisterStages([FromBody] Stages newStages)
    {
         
               var client = new MongoClient("mongodb://localhost:27017"); // MongoDB connection string
               var database = client.GetDatabase("ProgramDB");
               var StagesCollection = database.GetCollection<Stages>("Stages");



           Stages stages = new Stages{
            StageType = newStages.StageType,
            WorkFlowId = newStages.WorkFlowId,
            ShowStage = newStages.ShowStage
            };
            
              // add it to database.
           StagesCollection.InsertOne(stages);
         return Ok("Stages Created successfully.");
      

}



[HttpPost("Register/IQuestions")]
  public IActionResult PostInterviewQuestion([FromBody] InterviewQuestion newIQuestions)
    {
         
               var client = new MongoClient("mongodb://localhost:27017"); // MongoDB connection string
               var database = client.GetDatabase("ProgramDB");
             var IQuestionCollection = database.GetCollection<InterviewQuestion>("Iquestions");

           InterviewQuestion Iquests = new InterviewQuestion{
          
              durationType = newIQuestions.durationType,
              No_of_days_to_deadline = newIQuestions.No_of_days_to_deadline,
              Max_duration = newIQuestions.Max_duration,
              InterviewQuestions = newIQuestions.InterviewQuestions,
              info_InterviewQuestion = newIQuestions.info_InterviewQuestion
            };
            
              // add it to database.
       IQuestionCollection.InsertOne(Iquests);
         return Ok("Interview Question Added successfully.");
      

}


 [HttpPut("Programs/updateProgram")]
public  ActionResult UpdateProgram ([FromBody] Programs newProgram, ObjectId Id){

            var client = new MongoClient("mongodb://localhost:27017"); // Replace with your MongoDB connection string
            var database = client.GetDatabase("ProgramDB");
            var ProgramsCollection = database.GetCollection<Programs>("programs");
         

          // Find the author you want to update by some identifier, for example, by ObjectId
           var programIdToUpdate =  Id; // Replace with the actual ObjectId
           string programIdToUpdateString = programIdToUpdate.ToString();
          // You can use the FilterDefinition to specify the condition to find the author
          var filter = Builders<Programs>.Filter.Eq("Id",  programIdToUpdateString);

    // Define the update operation to update both Name and PhoneNumber
        var update = Builders<Programs>.Update
         .Set("Title", newProgram.Title)
         .Set("Summary", newProgram.Summary)
         .Set("Description", newProgram.Description)
         .Set("Benefit", newProgram.Benefit)
         .Set("Application_criteria", newProgram.Application_criteria)
         .Set("Type", newProgram.Type)  
         .Set("Qualification", newProgram.Qualification) 
         .Set("Program_starts", newProgram.Program_starts)
         .Set("Application_opens", newProgram.Application_opens)  
         .Set("Application_closes", newProgram.Application_closes) 
         .Set("Duration", newProgram.Duration)
         .Set("No_of_application", newProgram.No_of_application)  
         .Set("Application_closes", newProgram.Application_closes) 
         .Set("Program_locations", newProgram.Program_locations);

// Perform the update
    var result = ProgramsCollection.UpdateOne(filter, update);

    if (result.ModifiedCount > 0)
    {
       return Ok("Update Done Successfull.");    
    }
    else
    {
         return NotFound();
}

}

[HttpPost("upload")]
public async Task<IActionResult> UploadImage( ImageDtos imagedtos )
{


            var client = new MongoClient("mongodb://localhost:27017"); // Replace with your MongoDB connection string
            var database = client.GetDatabase("ProgramDB");
            var ImagesCollection = database.GetCollection<Image>("Images");
         
    // Check if an image was uploaded
    if (imagedtos.imageFile != null && imagedtos.imageFile.Length > 0)
    {
        // Generate a unique file name for the image (e.g., using a GUID)
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + imagedtos.imageFile.FileName;

        // Specify the folder where you want to save the image
        var uploadFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads");

        // Create the folder if it doesn't exist
        Directory.CreateDirectory(uploadFolder);

        // Combine the folder path and file name to get the full path to the saved image
        var filePath = Path.Combine(uploadFolder, uniqueFileName);

        // Save the uploaded image to the specified path
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imagedtos.imageFile.CopyToAsync(stream);
        }

        
    Image newImage = new Image {

     ApptId = imagedtos.ApptId,
     imageUrl = "/uploads/" + uniqueFileName 
    };
         
  ImagesCollection.InsertOne(newImage);
        return Ok("Image uploaded successfully.");
    }

    return BadRequest("No image uploaded.");
}





[HttpPost("Application/PostApplication")]
  public IActionResult CreateApplication ([FromBody] ApplicationDtos newApplication)
    {

              var client = new MongoClient("mongodb://localhost:27017"); // Replace with your MongoDB connection string
              var database = client.GetDatabase("ProgramDB");
              var ApplicationsCollection = database.GetCollection<Application>("applications");
              var ProfilesCollection = database.GetCollection<Profile>("profiles");

            ApplicationValidation validDateAppt =  new ApplicationValidation(newApplication);

              if(!(validDateAppt.to_return())){
                return Ok(validDateAppt.invalidMessageFunc());
              }else{

             Application appt = new Application{
                    FirstName = newApplication.FirstName,
                    LastName = newApplication.LastName,
                    PhoneNumber = newApplication.PhoneNumber,
                    Current_Residence = newApplication.Current_Residence,
                    Date_of_Birth = newApplication.Date_of_Birth,
                    Email= newApplication.Email,
                    Gender= newApplication.Gender,
                   Nationality = newApplication.Nationality,
                   ProgramId = newApplication.ProgramId
                };

                // add to application database.
                ApplicationsCollection.InsertOne(appt);
               // return Ok("Program Added successfully.");
     
                 
               Profile EducationProfile = new Profile{
                  Title= "Education",
                  Description = newApplication.Education_Description
                };

                 Profile ExperienceProfile = new Profile{
                  Title= "Experience",
                  Description = newApplication.Experience_Description
                };
                // add to profile database
              ProfilesCollection.InsertMany(new List<Profile> { EducationProfile, ExperienceProfile});
              appt.Profiles.AddRange(new List<Profile> { EducationProfile, ExperienceProfile});
              ApplicationsCollection.ReplaceOne(a => a.Id == appt.Id, appt);

            return Ok(" Application Created successfully.");
            }
          
}

  
 [HttpPut("{UpdateApplication}")]
public  ActionResult UpdateApplication ([FromBody] Application newApplication, ObjectId Id){
     
              var client = new MongoClient("mongodb://localhost:27017"); // Replace with your MongoDB connection string
              var database = client.GetDatabase("ProgramDB");
              var ApplicationsCollection = database.GetCollection<Application>("applications");
              var ProfilesCollection = database.GetCollection<Profile>("profiles");

          // Find the author you want to update by some identifier, for example, by ObjectId
           var ApplicationIdToUpdate =  Id; // Replace with the actual ObjectId
           string ApplocationIdToUpdateString = ApplicationIdToUpdate.ToString();
          // You can use the FilterDefinition to specify the condition to find the author
          var filter = Builders<Application>.Filter.Eq("Id",  ApplocationIdToUpdateString);

    // Define the update operation to update both Name and PhoneNumber
        var update = Builders<Application>.Update
         .Set("FirstName", newApplication.FirstName)
         .Set("LastName", newApplication.LastName)
         .Set("Email", newApplication.Email)
         .Set("Current_Residence", newApplication.Current_Residence)
         .Set("Nationality", newApplication.Nationality)
         .Set("Gender", newApplication.Gender)  
         .Set("Date_of_Birth", newApplication.Date_of_Birth) 
         .Set("PhoneNumber", newApplication.PhoneNumber);

// Perform the update
    var result = ApplicationsCollection.UpdateOne(filter, update);

    if (result.ModifiedCount > 0)
    {
       return Ok("Update Done Successfull.");    
    }
    else
    {
         return NotFound();
}

            


}


[HttpPost("Application/Profile")]
  public IActionResult CreateProfile([FromBody] Profile newProfile)
    {

              var client = new MongoClient("mongodb://localhost:27017"); // Replace with your MongoDB connection string
              var database = client.GetDatabase("ProgramDB");
              //var ApplicationsCollection = database.GetCollection<Application>("applications");
              var ProfilesCollection = database.GetCollection<Profile>("profiles");

         Profile Profile_A = new Profile{
                  Title=  newProfile.Title,
                  Description = newProfile.Description,
                  ApplicationId = newProfile.ApplicationId
                };

            // add to database.
          ProfilesCollection.InsertOne(Profile_A);
        return Ok("Profile Added successfully.");

}

[HttpPost("Application/Question")]
  public IActionResult CreateProfile([FromBody] Questions newQuestion)
    {


           var client = new MongoClient("mongodb://localhost:27017"); // Replace with your MongoDB connection string
           var database = client.GetDatabase("ProgramDB");
           var QuestionsCollection = database.GetCollection<Questions>("QuestionS");

           Questions QuestionS = new Questions{
                  Title=  newQuestion.Title,
                  Description = newQuestion.Description,
                  ApplicationId = newQuestion.ApplicationId
                };

            // add to database.
        QuestionsCollection.InsertOne(QuestionS);
           return Ok("Questions Added successfully.");
}





}

}

