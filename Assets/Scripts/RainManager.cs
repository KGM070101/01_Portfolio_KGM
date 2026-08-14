using UnityEngine;

public class RainManager : MonoBehaviour
{
    [SerializeField] private GameObject rainPrefab;
    [SerializeField] private GameObject rainPrefab2;
    [SerializeField] private GameObject rainPrefab3;
    [SerializeField] private GameObject rainPrefab4;
    [SerializeField] private GameObject rainHardPrefab;
    [SerializeField] private GameObject rainHardPrefab2;
    [SerializeField] private GameObject rainHardPrefab3;
    [SerializeField] private GameObject rainHardPrefab4;
    [SerializeField] private GameObject Levelannouncement;
    [SerializeField] private Transform RainBox;    
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnInterval2;
    [SerializeField] private float spawnInterval3;
    [SerializeField] private float spawnInterval4;
    [SerializeField] private float spawnInterval_Hard;
    [SerializeField] private float spawnInterval2_Hard;
    [SerializeField] private float spawnInterval3_Hard;
    [SerializeField] private float spawnInterval4_Hard;
    [SerializeField] private float minX = -9.6f;
    [SerializeField] private float maxX = 9.6f;
    [SerializeField] private float spawnY = 6f;
    [SerializeField] private float spawnY2 = 7f;
    [SerializeField] private float spawnY3=8f;

    private RainDestroyer rainDestroyer;
    
    private LevelAnnouncement levelAnnouncement;

    private GameOverStartManager GOSM;
   
    private Rain rain;
    private Rain2 rain2;
    private Rain3 rain3;
    private Rain2_Hard rain2_Hard;
    private Rain3_Hard rain3_Hard;
    private SFX_Manager SFX;
    private CountDown countDown;
    private int Trigger1;
    private int Trigger2;
    private int Trigger3;
    private int Trigger4;
    private int Trigger5;

    public bool Rain3_DoubleBounce = false;
    private void Start()
    {
        rainDestroyer = FindAnyObjectByType<RainDestroyer>();
        levelAnnouncement = FindFirstObjectByType<LevelAnnouncement>(FindObjectsInactive.Include);
        GOSM = FindFirstObjectByType<GameOverStartManager>();
        rain = FindFirstObjectByType<Rain>(FindObjectsInactive.Include);
        rain2 = FindFirstObjectByType<Rain2>(FindObjectsInactive.Include);
        rain3 = FindFirstObjectByType<Rain3>(FindObjectsInactive.Include);
        rain2_Hard = FindFirstObjectByType<Rain2_Hard>(FindObjectsInactive.Include);
        rain3_Hard = FindFirstObjectByType<Rain3_Hard>(FindObjectsInactive.Include);
        SFX = FindFirstObjectByType<SFX_Manager>();
        countDown = FindFirstObjectByType<CountDown>();
    }
        
    public void StartingRain()
    {
        if (GOSM.classic == true)
        {
            rain.randomXForce = 1.0f;
            spawnInterval = 0.4f;
            InvokeRepeating("SpawnRain", 0f, spawnInterval);
            Debug.Log("Start");
        }
        if (GOSM.hard == true)
        {
            rain.randomXForce = 1.0f;
            spawnInterval_Hard = 0.32f;
            InvokeRepeating("SpawnRain_Hard", 0f, spawnInterval_Hard);
        }
    }

    private void Update()
    {        
        if(GOSM.classic==true)
        {
            if (rainDestroyer.ScoreCount >= 100)  //점수구간
            {
                Trigger1++;
                spawnInterval = 0.35f;
                spawnInterval2 = 1.5f;
                rain2.randomXForce = 1.0f;
                if (Trigger1 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("100");
                    CancelInvoke("SpawnRain");
                    InvokeRepeating("SpawnRain", 0f, spawnInterval);
                    InvokeRepeating("SpawnRain2", 0f, spawnInterval2);
                }
            }
            if (rainDestroyer.ScoreCount >= 250)  //점수구간
            {
                Trigger2++;
                spawnInterval = 0.3f;
                rain.randomXForce = 2.0f;
                spawnInterval2 = 1.0f;
                rain2.randomXForce = 3.0f;
                if (Trigger2 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("250");
                    CancelInvoke("SpawnRain");
                    CancelInvoke("SpawnRain2");
                    InvokeRepeating("SpawnRain", 0f, spawnInterval);
                    InvokeRepeating("SpawnRain2", 0f, spawnInterval2);
                }
            }
            if (rainDestroyer.ScoreCount >= 400)  //점수구간
            {
                Trigger3++;
                spawnInterval3 = 10.0f;
                rain3.randomXForce = 10.0f;
                if (Trigger3 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("400");
                    InvokeRepeating("SpawnRain3", 0f, spawnInterval3);
                }
            }
            if (rainDestroyer.ScoreCount >= 700)  //점수구간
            {
                Trigger4++;
                rain3.randomXForce = 15.0f;
                spawnInterval4 = 15.0f;
                if (Trigger4 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("700");
                    InvokeRepeating("SpawnRain4", 0f, spawnInterval4);
                }
            }
            if (rainDestroyer.ScoreCount >= 1000)  //점수구간
            {
                Trigger5++;
                rain.randomXForce = 3.0f;
                spawnInterval2 = 0.8f;
                Rain3_DoubleBounce = true;
                spawnInterval3 = 8.0f;
                spawnInterval4 = 10f;
                if (Trigger5 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("1000");
                    CancelInvoke("SpawnRain2");
                    CancelInvoke("SpawnRain3");
                    CancelInvoke("SpawnRain4");
                    InvokeRepeating("SpawnRain2", 0f, spawnInterval2);
                    InvokeRepeating("SpawnRain3", 0f, spawnInterval3);
                    InvokeRepeating("SpawnRain4", 0f, spawnInterval4);
                }
            }
        } //classic = true

        if(GOSM.hard==true)
        {
            if (rainDestroyer.ScoreCount_Hard >= 100)  //점수구간
            {
                Trigger1++;
                spawnInterval_Hard = 0.28f;
                spawnInterval2_Hard = 1.5f;
                rain2_Hard.randomXForce = 1.0f;
                if (Trigger1 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("100");
                    CancelInvoke("SpawnRain_Hard");
                    InvokeRepeating("SpawnRain_Hard", 0f, spawnInterval_Hard);
                    InvokeRepeating("SpawnRain2_Hard", 0f, spawnInterval2_Hard);
                }
            }
            if (rainDestroyer.ScoreCount_Hard >= 250)  //점수구간
            {
                Trigger2++;
                spawnInterval_Hard = 0.24f;
                rain.randomXForce = 2.0f;
                spawnInterval2_Hard = 1.0f;
                rain2_Hard.randomXForce = 3.0f;
                if (Trigger2 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("250");
                    CancelInvoke("SpawnRain_Hard");
                    CancelInvoke("SpawnRain2_Hard");
                    InvokeRepeating("SpawnRain_Hard", 0f, spawnInterval_Hard);
                    InvokeRepeating("SpawnRain2_Hard", 0f, spawnInterval2_Hard);
                }
            }
            if (rainDestroyer.ScoreCount_Hard >= 400)  //점수구간
            {
                Trigger3++;
                spawnInterval3_Hard = 10.0f;
                rain3_Hard.randomXForce = 10.0f;
                if (Trigger3 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("400");
                    InvokeRepeating("SpawnRain3_Hard", 0f, spawnInterval3_Hard);
                }
            }
            if (rainDestroyer.ScoreCount_Hard >= 700)  //점수구간
            {
                Trigger4++;
                rain3_Hard.randomXForce = 15.0f;
                spawnInterval4_Hard = 15.0f;
                if (Trigger4 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("700");
                    InvokeRepeating("SpawnRain4_Hard", 0f, spawnInterval4_Hard);
                }
            }
            if (rainDestroyer.ScoreCount_Hard >= 1000)  //점수구간
            {
                Trigger5++;
                rain.randomXForce = 3.0f;
                spawnInterval2_Hard = 0.8f;
                Rain3_DoubleBounce = true;
                spawnInterval3_Hard = 8.0f;
                spawnInterval4_Hard = 10f;
                if (Trigger5 == 1)
                {
                    Levelannouncement.SetActive(true);
                    levelAnnouncement.StartNotice("1000");
                    CancelInvoke("SpawnRain2_Hard");
                    CancelInvoke("SpawnRain3_Hard");
                    CancelInvoke("SpawnRain4_Hard");
                    InvokeRepeating("SpawnRain2_Hard", 0f, spawnInterval2_Hard);
                    InvokeRepeating("SpawnRain3_Hard", 0f, spawnInterval3_Hard);
                    InvokeRepeating("SpawnRain4_Hard", 0f, spawnInterval4_Hard);
                }
            }
        }
    }

    private void SpawnRain()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);
        GameObject rain=Instantiate(rainPrefab, spawnPos, Quaternion.identity, RainBox);        
    }
    private void SpawnRain2()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);
        GameObject rain2 = Instantiate(rainPrefab2, spawnPos, Quaternion.identity, RainBox);
       // SFX.Rain2_Falling();
    }

    private void SpawnRain3()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY2);
        GameObject rain2 = Instantiate(rainPrefab3, spawnPos, Quaternion.identity, RainBox);
    }

    private void SpawnRain4()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);
        GameObject rain2 = Instantiate(rainPrefab4, spawnPos, Quaternion.identity, RainBox);
    }

    private void SpawnRain_Hard()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);
        GameObject rain = Instantiate(rainHardPrefab, spawnPos, Quaternion.identity, RainBox);
    }
    private void SpawnRain2_Hard()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);
        GameObject rain2 = Instantiate(rainHardPrefab2, spawnPos, Quaternion.identity, RainBox);
        //SFX.Rain2_Falling();    
    }

    private void SpawnRain3_Hard()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY3);
        GameObject rain2 = Instantiate(rainHardPrefab3, spawnPos, Quaternion.identity, RainBox);
    }

    private void SpawnRain4_Hard()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);
        GameObject rain2 = Instantiate(rainHardPrefab4, spawnPos, Quaternion.identity, RainBox);
    }

}
