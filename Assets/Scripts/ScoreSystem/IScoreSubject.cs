public interface IScoreSubject
{
    void RegisterObserver(IScoreObserver observer);
    void UnregisterObserver(IScoreObserver observer);
    void NotifyObservers();
}