using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private EndGamePanelController _endGamePanelController;

    private bool _isGameGoOn = true;
    public bool IsGameGoOn { get => _isGameGoOn; }

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

    public void ShowEndGamePanel()
    {
        _endGamePanelController?.gameObject.SetActive(true);
        _isGameGoOn = false;
        _endGamePanelController?.Initialize(ScoreManager.Instance.Score);
    }
}
