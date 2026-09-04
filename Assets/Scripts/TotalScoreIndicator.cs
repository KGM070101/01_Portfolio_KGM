using TMPro;
using UnityEngine;

public class TotalScoreIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalsocreindicator;

    private GameOverStartManager gosm;
    private RainDestroyer rainDestroyer;

    private void Start()
    {
        gosm = FindFirstObjectByType<GameOverStartManager>();
        rainDestroyer = FindFirstObjectByType<RainDestroyer>();
    }
    public void UpdateTotalSocreGUI()
    {                        
        totalsocreindicator.text = "Total \nScore:" + rainDestroyer.ScoreCount;              
    }

    public void UpdateTotalScoreGUI_Hard()
    {
        totalsocreindicator.text = "Total \nScore:" + rainDestroyer.ScoreCount_Hard;
    }
}
