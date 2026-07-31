using TMPro;
using UnityEngine;

public class BestScoreIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BestScoreText;
    [SerializeField] private TextMeshProUGUI NewBest;
    [SerializeField] private TextMeshProUGUI BestScoreUI;

    public int BestScore = 0;

    private void Start()
    {
        IndicateBestScoreGUI();
    }
    public void SaveBestSocre()
    {
        RainDestroyer BSC = FindFirstObjectByType<RainDestroyer>();

        BestScore = PlayerPrefs.GetInt("BestScore", 0);

        if(BSC.ScoreCount>BestScore)
        {
            PlayerPrefs.SetInt("BestScore", BSC.ScoreCount);
            PlayerPrefs.Save();
            BestScore = BSC.ScoreCount;
        }

        //Debug.Log("현재 ScoreCount: " + BSC.ScoreCount);
        //Debug.Log("저장된 BestScore: " + BestScore);
    }

    public void IndicateBestScoreGUI()
    {
        RainDestroyer BSC = FindFirstObjectByType<RainDestroyer>();
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreUI.text = "Best Score:" + BestScore;
        BestScoreUI.color = Color.black;
    }
    public void UpdateBestScoreGUI()
    {
        RainDestroyer BSC = FindFirstObjectByType<RainDestroyer>();
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreText.text = "Best Score:" + BestScore;
    }

    public void IndicateNewBestScoreGUI()
    {
        NewBest.text = "New Best!";
    }
}
