
using UnityEngine;
using UnityEngine.UI;

public class ItemDurationBar : MonoBehaviour
{
    [SerializeField]
    private Image DurationBar;

    [SerializeField]
    private GameObject Panel;

    private float maxDuration;
    private float currentDuration;
    private bool isTImerRunning = false;

    private void Awake()
    {
        DurationBar = GetComponent<Image>();
    }
    private void Update()
    {
        if(isTImerRunning==true)
        {
            currentDuration -= Time.deltaTime;

            if(currentDuration<=0)
            {
                currentDuration = 0;
                isTImerRunning = false;
                gameObject.SetActive(false);
                Panel.SetActive(false);
            }
            DurationBar.fillAmount = currentDuration / maxDuration;
        }
    }

    public void StartDurationBar(float duration)
    {
        maxDuration = duration;
        currentDuration = duration;
        isTImerRunning = true;

        gameObject.SetActive(true);
        Panel.SetActive(true);
        DurationBar.fillAmount = 1.0f;
    }
}
