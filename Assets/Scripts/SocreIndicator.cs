using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;

    private GameOverStartManager gosm;
    private RainDestroyer rainDestroyer;
        
    private void Start()
    {
        gosm = FindFirstObjectByType<GameOverStartManager>();
        rainDestroyer = FindFirstObjectByType<RainDestroyer>();

        if (gosm.classic==true&&gosm.hard==false)
        {
            UpdateCountGUI();
        }
        if (gosm.classic == false && gosm.hard == true)
        {
            UpdateCountGUI_Hard();
        }
    }

    public void UpdateCountGUI() //클래식 모드에서의 실시간 점수 집계
    {       
        ScoreText.text = "Score:" + rainDestroyer.ScoreCount;
        ScoreText.color = Color.black;
    }
    public void UpdateCountGUI_Hard() //하드 모드에서의 실시간 점수 집계
    {       
        ScoreText.text = "Score(Hard):" + rainDestroyer.ScoreCount_Hard;
        ScoreText.color = Color.black;
    }


}
