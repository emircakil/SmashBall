using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;

public class EffectItem : MonoBehaviour
{
    public TextMeshProUGUI coinAmount;
    public Image imageForEffect;

    int id;
    private const string selectedId = "itemSelected";
    private const string moneyAmount = "moneyy";
    private const string isBought = "isBought";
   

    public void SetPanel(string text,Sprite sprite ,int id)
    {
  
        imageForEffect.sprite = sprite;
        this.id = id;
        string idBought = isBought + id.ToString();
        if (PlayerPrefs.GetInt(idBought) == 0)
        {
            coinAmount.text = text;
        }
        else {
            coinAmount.text = "Unlocked";
        }
    }

    public void Clicked()
    {
        string idBought = isBought + id.ToString();
        if (PlayerPrefs.GetInt(idBought)== 0)
        {
            int cAmount = Convert.ToInt32(coinAmount.text);

            if (cAmount < PlayerPrefs.GetInt(moneyAmount))
            {
                PlayerPrefs.SetInt(moneyAmount, PlayerPrefs.GetInt(moneyAmount) - cAmount);
                PlayerPrefs.SetInt(selectedId, id);
                PlayerPrefs.SetInt(idBought, 1);
                coinAmount.text = "Unlocked";
               
            }

        }
        else {

            PlayerPrefs.SetInt(selectedId, id);
        }
 
    }
}
