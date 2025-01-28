using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour, IScoreObserver
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreManager _scoreManager;

    private void OnEnable()
    {
        _scoreManager.RegisterObserver(this);
        UpdateScoreDisplay(_scoreManager.Score);
    }


    private void OnDisable()
    {
        _scoreManager.UnregisterObserver(this);
    }


    public void OnScoreChanged(int newScore)
    {
        UpdateScoreDisplay(newScore);
    }

    private void UpdateScoreDisplay(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }
}