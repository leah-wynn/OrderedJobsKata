using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderedJobs
{
    public class JobOrder
    {
        public static string OrderJobs(string input)
        {
            if (input == "") return "";
            
            var jobInstructions = input.Replace(" ", "").Split("\n").Select(x => new Job(x)).ToList();
            var jobSchedule = new List<string>();

            var wereJobsAdded = true;
            while (wereJobsAdded)
            {
                wereJobsAdded = false;
                foreach (var job in jobInstructions)
                {
                    if (job.HasNoDependancy() && job.JobNotPresent(jobSchedule))
                    {
                        jobSchedule.Add(job.Name);
                        wereJobsAdded = true;
                    }
                    
                    if (job.HasDependancy() && job.DependancyIsPresent(jobSchedule) && job.JobNotPresent(jobSchedule))
                    {
                        jobSchedule.Add(job.Name);
                        wereJobsAdded = true;
                    }
                }

            }

            var jobList = GetJobList(input);
            var orderedJobs = string.Join("", jobSchedule);
            return jobList.Length != orderedJobs.Length ? "circular dependancy not allowed" : orderedJobs;
        }

        private static string GetJobList(string input)
        {
            var jobs = input.Where(char.IsLetter);
            var jobList = string.Join("", jobs.Distinct());
            return jobList;
        }
    }
}