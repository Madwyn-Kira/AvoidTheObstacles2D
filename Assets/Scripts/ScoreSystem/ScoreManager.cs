using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreSubject
{
    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            NotifyObservers();
        }
    }

    private readonly List<IScoreObserver> _observers = new List<IScoreObserver>();

    public void RegisterObserver(IScoreObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void UnregisterObserver(IScoreObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.OnScoreChanged(_score);
        }
    }

    public void IncreaseScore(int amount)
    {
        Score += amount;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}