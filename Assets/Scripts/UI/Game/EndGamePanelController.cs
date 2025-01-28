using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePanelController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text EndScoreTXT;

    public void Initialize(int score)
    {
        EndScoreTXT.text = score.ToString();
    }

    public void RestartGameButton()
    {
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
