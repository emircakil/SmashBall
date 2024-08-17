using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EffectsLayout : MonoBehaviour
{
    public UIManager uiManager;
    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;
    public List<MyClass> effects = new();
    public List<GameObject> buttons = new();

    public Sprite effectSprite;
    public GameObject PackPrefab;
    public RectTransform RectTransform;
    public Sprite greenBack;
    public Sprite yellowBack;

    private const string selectedId = "itemSelected";
    private const string isBought = "isBought";

    void Start()
    {
        int id = 0;
        foreach (var item in effects)
        {
            GameObject newPanel = Instantiate(PackPrefab, RectTransform);
            string idBought = isBought + id.ToString();

            if (!PlayerPrefs.HasKey(idBought)) { 
                PlayerPrefs.SetInt(idBought, 0);
            }

            if (newPanel.TryGetComponent<EffectItem>(out var containerValue))
            {
                containerValue.SetPanel(item.amount, item.sprite, id);
                containerValue.gameObject.GetComponent<Button>().onClick.AddListener(adjustGreenBackground);
                id++;
                buttons.Add(newPanel);

            }
        }

        if (!PlayerPrefs.HasKey(selectedId)) { 
        
            PlayerPrefs.SetInt(selectedId, 0);
        }
        adjustGreenBackground();
    }
    public void adjustGreenBackground()
    {

        foreach (var item in buttons)
        {

            if (item.TryGetComponent<Image>(out var imageValue))
            {

                imageValue.sprite = yellowBack;
            }
        }

        if (buttons[PlayerPrefs.GetInt(selectedId)].TryGetComponent<Image>(out var img))
        {
            img.sprite = greenBack;
        }
        uiManager.CoinTextUpdate();


        switch (PlayerPrefs.GetInt(selectedId))
        {

            case 0:
                particle1.SetActive(true);
                particle2.SetActive(false);
                particle3.SetActive(false);
                particle4.SetActive(false);
                break;
            case 1:
                particle1.SetActive(false);
                particle2.SetActive(true);
                particle3.SetActive(false);
                particle4.SetActive(false);
                break;
            case 2:
                particle1.SetActive(false);
                particle2.SetActive(false);
                particle3.SetActive(true);
                particle4.SetActive(false);
                break;
            case 3:
                particle1.SetActive(false);
                particle2.SetActive(false);
                particle3.SetActive(false);
                particle4.SetActive(true);
                break;

        }
    }
   

    }

[System.Serializable]
public class MyClass
{
    public string amount;
    public Sprite sprite;

}

