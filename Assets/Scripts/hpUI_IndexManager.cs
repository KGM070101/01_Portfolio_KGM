using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class hpUI_IndexManager : MonoBehaviour
{    
    public GameObject[] NormalHp;
    public GameObject[] BonusHP;

    private void Start()
    {
        BonusHP[0].transform.localScale = new Vector2(0f, 0f);
        BonusHP[1].transform.localScale = new Vector2(0f, 0f);
        BonusHP[2].transform.localScale = new Vector2(0f, 0f);
        BonusHP[3].transform.localScale = new Vector2(0f, 0f);
        BonusHP[4].transform.localScale = new Vector2(0f, 0f);
    }

    public Color HpColor = Color.white;
    public Color EmptyColor = Color.black;
    

    public void UpdateHPUI(int currentHP,int maxHP)
    {
        int normalHPcount = NormalHp.Length;

        for (int i = 0; i < NormalHp.Length; i++)
        {
            SpriteRenderer spriteRenderer1 = NormalHp[i].GetComponent<SpriteRenderer>();

            if (i < currentHP)
                spriteRenderer1.DOColor(HpColor,1);
            else
                spriteRenderer1.DOColor(EmptyColor, 1);
        }

        for (int i = 0;i < BonusHP.Length; i++)
        {
            

            int hpIndex = normalHPcount + i + 1;

            if (hpIndex <= currentHP && hpIndex <= maxHP)
            {
                //BonusHP[i].SetActive(true);
                
                BonusHP[i].transform.DOScale(1, 1);                
            }                               
            else
            {                              
                BonusHP[i].transform.DOScale(0, 0.5f);
                //BonusHP[i].SetActive(false);
            }                                
        }
    }
}
