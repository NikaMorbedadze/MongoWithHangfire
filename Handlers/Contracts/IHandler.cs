namespace MongoWithHangfire.Handlers.Contracts
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void Handle(int x);
    }
}
