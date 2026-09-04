using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] GameObject CountDownCanvas;
    [SerializeField] TextMeshProUGUI CounterText;

    private float count = 3;


    public bool TimerOver = false;
    public bool IsCounting = false;
    private void Start()
    {
        CountDownCanvas.SetActive(true);
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy==true)
        {
            if (!IsCounting)
                return;

            count -= Time.unscaledDeltaTime;
            CounterText.text = Mathf.CeilToInt(count).ToString();

            if (count <= 0)
            {
                CountDownCanvas.SetActive(false);
                count = 3;
                TimerOver = true;
            }
            //CountDownStart();
        }
        //CounterText.text = System.Convert.ToString(count);
    }
    public void CountDownStart()
    {
        //CounterText.text = System.Convert.ToString((int)count);        
        //CounterText.text = count.ToString("N0");

        count = 3f;
        IsCounting = true;
        TimerOver = false;
        CounterText.text = "3";
        CountDownCanvas.SetActive(true);
        
    }
}
