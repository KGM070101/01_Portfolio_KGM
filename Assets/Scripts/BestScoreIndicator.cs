using TMPro;
using UnityEngine;

public class BestScoreIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BestScoreText;
    [SerializeField] private TextMeshProUGUI NewBest;
    [SerializeField] private TextMeshProUGUI BestScoreUI;

    private GameOverStartManager gosm;
    private RainDestroyer rainDestroyer;
        

    public int BestScore = 0;
    public int BestScore_Hard = 0;

    private void Start()
    {
        gosm = FindFirstObjectByType<GameOverStartManager>();
        rainDestroyer=FindFirstObjectByType<RainDestroyer>();
        if(gosm.classic==true&&gosm.hard==false)
        {
            IndicateBestScoreGUI();
        }
        if(gosm.classic==false&&gosm.hard==true)
        {
            IndicateBestScoreGUI_Hard();
        }
       
    }

    

    public void SaveBestScore() //클래식 모드 최고 점수 저장
    {
        if(gosm.classic==true&&gosm.hard==false)
        {            
            BestScore = PlayerPrefs.GetInt("BestScore", 0);

            if (rainDestroyer.ScoreCount > BestScore)
            {
                PlayerPrefs.SetInt("BestScore", rainDestroyer.ScoreCount);
                PlayerPrefs.Save();
                BestScore = rainDestroyer.ScoreCount;
            }
        }        
        //Debug.Log("현재 ScoreCount: " + BSC.ScoreCount);
        //Debug.Log("저장된 BestScore: " + BestScore);
    }
    
    public void SaveBestScore_Hard() //하드 모드 최고 점수 저장
    {
        if(gosm.hard==true&&gosm.classic==false)
        {
            BestScore_Hard = PlayerPrefs.GetInt("BestScore_Hard", 0);

            if(rainDestroyer.ScoreCount_Hard>BestScore_Hard)
            {
                PlayerPrefs.SetInt("BestScore_Hard", rainDestroyer.ScoreCount_Hard);
                PlayerPrefs.Save();
                BestScore_Hard = rainDestroyer.ScoreCount_Hard;
            }
        }
    }

    public void IndicateBestScoreGUI() //클래식 모드 최고 점수 UI 표시
    {
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreUI.text = "Best Score:" + BestScore;
        BestScoreUI.color = Color.black;
    }

    public void IndicateBestScoreGUI_Hard() //하드 모드 최고 점수 UI 표시
    {
        BestScore_Hard = PlayerPrefs.GetInt("BestScore_Hard", 0);
        BestScoreUI.text = "Best Score(Hard):" + BestScore_Hard;
        BestScoreUI.color = Color.black;
    }
    public void UpdateBestScoreGUI() //클래식 모드 최고 점수 업데이트
    {      
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreText.text = "Best Score:" + BestScore;
    }

    public void UpdateBestScoreGUI_Hard() //하드 모드 최고 점수 업데이트
    {
        BestScore_Hard = PlayerPrefs.GetInt("BestScore_Hard", 0);
        BestScoreText.text = "Best Score:" + BestScore_Hard;
    }

    public void IndicateNewBestScoreGUI()
    {
        NewBest.text = "New Best!";
    }
}
