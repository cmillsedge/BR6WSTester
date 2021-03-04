using System;
using System.Threading;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace BRWS6
{
    public static class JobHandler
    {
        public static JobReport pollJob(JobReport job, string sessionId, string url)
        {
            JobsApi jobsApi = new JobsApi(url);
            JobReport polledJob;
            do
            {
                Thread.Sleep(1000);
                polledJob = jobsApi.JobGet(sessionId, job.Id);
                Console.WriteLine(polledJob.Status);
            } while (polledJob.Status != "error" && polledJob.Status != "finished");
            return polledJob;
        }
    }
}
