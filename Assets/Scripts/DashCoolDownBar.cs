using UnityEngine;
using UnityEngine.UI;

public class DashCoolDownBar : MonoBehaviour
{
    [SerializeField]
    private Image CoolDownBar;

    [SerializeField]
    private GameObject Panel;

    private float maxDuration;
    private float currentDuration;
    private bool isTimerRunning=false;

    private Color barColor_Charging = new Color(1, 0.75f, 0.3f);
    private Color barColor_Charged = new Color(0.3f, 0.65f, 1);

    private void Awake()
    {
        CoolDownBar = GetComponent<Image>();
    }

    private void Update()
    {
        if(isTimerRunning==true)
        {
            currentDuration += Time.deltaTime;

            if(currentDuration<=0)
            {
                currentDuration = 0;
                isTimerRunning = false;
                gameObject.SetActive(false);                
            }
            CoolDownBar.fillAmount = currentDuration / maxDuration;
        }
        if(CoolDownBar.fillAmount==1.0f)
        {
            CoolDownBar.color = barColor_Charged;
        }
    }

    public void StartCoolDownBar(float cooldown)
    {        
        maxDuration = cooldown;
        currentDuration = 0;
        CoolDownBar.color = barColor_Charging;
        isTimerRunning = true;

        CoolDownBar.fillAmount = 1.0f;
    }
}
