namespace RequestResponseLogger.Interfaces
{
    public interface IRequestResponseLogger
    {
        void Log(IRequestResponseLogModelCreator logCreator);
    }
}
