using TMPro;
using UnityEngine;

public class LifeIndicator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] public int life = 3;

    
    private void Start()
    {
        UpdateLifeGUI();
    }

    public void Damage()
    {
        life--;

        if(life<0)
        {
            life = 0;

            
        }
        UpdateLifeGUI();
    }

    public void Damage2()
    {
        life-=2;

        if (life < 0)
        {
            life = 0;


        }
        UpdateLifeGUI();
    }
    public void UpdateLifeGUI()
    {
        lifeText.text = "Life:" + life;
        lifeText.color = Color.black;
    }
}
