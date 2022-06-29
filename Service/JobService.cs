using MongoWithHangfire.Service.Interfaces;

namespace MongoWithHangfire.Service
{
    public class JobService : IJobService

    {
        public void Semd(string txt)
        {
            Console.WriteLine("done");
        }
    }
}
