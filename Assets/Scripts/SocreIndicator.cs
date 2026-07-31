using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;

    private void Start()
    {
        UpdateCountGUI();
    }

    public void UpdateCountGUI()
    {
        RainDestroyer SC = FindFirstObjectByType<RainDestroyer>();
        ScoreText.text = "Score:" + SC.ScoreCount;
        ScoreText.color = Color.black;
    }
    
}
