using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject ShieldItem;
    [SerializeField] private GameObject LifeItem;
    [SerializeField] private GameObject SpeedItem;
    [SerializeField] private GameObject DoubleScoreItem;
    [SerializeField] private GameObject SmallItem;
    [SerializeField] private GameObject LiskItem;
    [SerializeField] private GameObject SamuraiItem;
    [SerializeField, Range(10, 20)] private int ItemSpawnInterval;
    [SerializeField] private Transform ItemBox;
    
    private GameObject RandomItem;
    private int RandomItemSelection;
       
    private float min_X = -9.1f;
    private float max_X = 9.1f;
    private float PosY = 6.0f;
    private float timer = 0f;
    private float nextGap = 0f;
    private void Start()
    {
        RandomItemSelection = Random.Range(0, 100);
        //Debug.Log("RandomItemSelection:" + RandomItemSelection);
        nextGap = Random.Range(10.0f, 15.0f);
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (RandomItemSelection < 20)
        {
            RandomItem = ShieldItem;
        }
        else if (RandomItemSelection < 40)
        {
            RandomItem = LifeItem;
        }
        else if (RandomItemSelection < 60)
        {
            RandomItem = SpeedItem;
        }
        else if (RandomItemSelection < 80)
        {
            RandomItem = SmallItem;
        }
        else if (RandomItemSelection < 90)
        {
            RandomItem = DoubleScoreItem; 
        }
        else if(RandomItemSelection < 95)
        {
            RandomItem = LiskItem;
        }
        else if (RandomItemSelection < 100)
        {
            RandomItem = SamuraiItem    ;
        }

        if (timer >= nextGap)
        {
            nextGap = GetRandomIntervalByLevel(ItemSpawnInterval);
            RandomItemSelection = Random.Range(0, 100);
            //Debug.Log("다음 스폰까지: " + nextGap);
            //Debug.Log("RandomItemSelection:" + RandomItemSelection);

            SpawnItems();

            timer = 0f;
        }       
    }
    private float GetRandomIntervalByLevel(int level)
    {
        switch(level)
        {
            case 10: return Random.Range(10f, 12f);
            case 11: return Random.Range(12f, 14f);
            case 12: return Random.Range(14f, 16f);
            case 13: return Random.Range(16f, 18f);
            case 14: return Random.Range(18f, 20f);
            case 15: return Random.Range(20f, 22f);
            case 16: return Random.Range(22f, 24f);
            case 17: return Random.Range(24f, 26f);
            case 18: return Random.Range(26f, 28f);
            case 19: return Random.Range(28f, 30f);
            case 20: return Random.Range(1f, 30f);   

            default: return Random.Range(10f, 30f);
        }
    }        
    private void SpawnItems()
    {
        float RandomX = Random.Range(min_X, max_X);
        Vector2 spawnPos = new Vector2(RandomX, PosY);
        Instantiate(RandomItem, spawnPos, Quaternion.identity, ItemBox);
    }

}
