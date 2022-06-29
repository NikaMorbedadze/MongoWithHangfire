using MongoWithHangfire.Service.Interfaces;

namespace MongoWithHangfire.Service
{
    public class JobService : IJobService

    {
        private readonly IFileService _service;
        public JobService(IFileService service)
        {
            _service = service;
        }
    
        public void ContinuationJob()
        {
            throw new NotImplementedException();
        }

        public void DelayedJob()
        {
            throw new NotImplementedException();
        }

        public void FireAndForgetJob()
        {
            throw new NotImplementedException();
        }

        public void ReccuringJob()
        {
            var date = DateTime.Now.ToString("d");
            var files = _service.Get().Result.FindAll(x=>x.DateCreated.ToString("d")== date);
            
        }
    }
}
