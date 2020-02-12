using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 COMPLETED - get the Job with the given ID and pass it into the view

            //  we are using the Job object as the ViewModel and passing it
            //  into the Index view
            return View(jobData.Find(id));
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 COMPLETED - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            if (ModelState.IsValid)
            {
                Employer employer = new Employer()
                {
                    ID = newJobViewModel.EmployerId,
                    Value = newJobViewModel.Employers[newJobViewModel.EmployerId].Text
                };

                Location location = new Location()
                {
                    ID = newJobViewModel.LocationId,
                    Value = newJobViewModel.Locations[newJobViewModel.LocationId].Text
                };

                CoreCompetency coreCompetency = new CoreCompetency()
                {
                    ID = newJobViewModel.CoreCompetencyId,
                    Value = newJobViewModel.CoreCompetencies[newJobViewModel.CoreCompetencyId].Text
                };

                PositionType positionType = new PositionType()
                {
                    ID = newJobViewModel.PositionTypeId,
                    Value = newJobViewModel.PositionTypes[newJobViewModel.PositionTypeId].Text
                };

                Job newJob = new Job()
                {
                    Name = newJobViewModel.Name,
                    Employer = employer,
                    Location = location,
                    CoreCompetency = coreCompetency,
                    PositionType = positionType
                };

                jobData.Jobs.Add(newJob);

                return Redirect("Index");
            }
            return View(newJobViewModel);
        }
    }
}
