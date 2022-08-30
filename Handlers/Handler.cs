using MongoWithHangfire.Handlers.Contracts;

namespace MongoWithHangfire.Handlers
{
    public abstract class Handler : IHandler
    {
        private IHandler Next { get; set; }

        public virtual void Handle(int x) => Next?.Handle(x);

        public IHandler SetNext(IHandler handler)
        {
            Next = handler;
            return Next;
        }

    }
}
