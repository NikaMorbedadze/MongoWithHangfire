namespace MongoWithHangfire.Service.Interfaces
{
    public interface IJobService
    {
        void FireAndForgetJob();
        void ReccuringJob();
        void DelayedJob();
        void ContinuationJob();

    }
}
