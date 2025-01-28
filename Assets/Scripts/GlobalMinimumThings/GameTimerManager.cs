using UnityEngine;

public class GameTimerManager : MonoBehaviour
{
    [SerializeField]
    private float TimeWhenScoreIncrease = 2;

    [SerializeField]
    private int HowMuchScoreIncrease = 1;

    private float _timer = 0;

    private void Update()
    {
        if (GameManager.Instance.IsGameGoOn)
        {
            _timer += Time.deltaTime;

            if (_timer >= TimeWhenScoreIncrease)
            {
                ScoreManager.Instance.IncreaseScore(HowMuchScoreIncrease);
                _timer = 0;
            }
        }
    }
}
