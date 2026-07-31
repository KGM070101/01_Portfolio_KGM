using TMPro;
using UnityEngine;

public class TotalScoreIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalsocreindicator;

    public void UpdateTotalSocreGUI()
    {
        RainDestroyer TSI = GetComponent<RainDestroyer>();
        totalsocreindicator.text = "Total Score:" + TSI.ScoreCount;
    }
}
