using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private UIManager uiManager;
    public GameObject particle;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;

    public Sprite greenBack;
    public Sprite yellowBack;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;


    private void Awake()
    {
        uiManager = GetComponent<UIManager>();

        if (PlayerPrefs.HasKey("itemselect") == false)
        {

            PlayerPrefs.SetInt("itemselect", 0);
        }

        if (PlayerPrefs.GetInt("itemselect") == 0)
            Item1Open();
        else if (PlayerPrefs.GetInt("itemselect") == 1)
            Item2Open();
        else if (PlayerPrefs.GetInt("itemselect") == 2)
            Item3Open();
        if (PlayerPrefs.GetInt("itemselect") == 3)
            Item4Open();


        if (PlayerPrefs.HasKey("lock1control") == false)
            PlayerPrefs.SetInt("lock1control", 0);

        if (PlayerPrefs.HasKey("lock2control") == false)
            PlayerPrefs.SetInt("lock2control", 0);

        if (PlayerPrefs.HasKey("lock3control") == false)
            PlayerPrefs.SetInt("lock3control", 0);


        if (PlayerPrefs.GetInt("lock1control") == 1)
        {
            lock1.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lock2control") == 1)
        {
            lock2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lock3control") == 1)
        {
            lock3.SetActive(false);
        }
    }
    public void Item1Open()
    {
        particle.SetActive(true);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(false);

        item1.GetComponent<Image>().sprite = greenBack;
        item2.GetComponent<Image>().sprite = yellowBack;
        item3.GetComponent<Image>().sprite = yellowBack;
        item4.GetComponent<Image>().sprite = yellowBack;

        PlayerPrefs.SetInt("itemselect", 0);
    }
    public void Item2Open()
    {
        particle.SetActive(false);
        particle2.SetActive(true);
        particle3.SetActive(false);
        particle4.SetActive(false);

        item1.GetComponent<Image>().sprite = yellowBack;
        item2.GetComponent<Image>().sprite = greenBack;
        item3.GetComponent<Image>().sprite = yellowBack;
        item4.GetComponent<Image>().sprite = yellowBack;

        PlayerPrefs.SetInt("itemselect", 1);
    }
    public void Item3Open()
    {
        particle.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(true);
        particle4.SetActive(false);

        item1.GetComponent<Image>().sprite = yellowBack;
        item2.GetComponent<Image>().sprite = yellowBack;
        item3.GetComponent<Image>().sprite = greenBack;
        item4.GetComponent<Image>().sprite = yellowBack;

        PlayerPrefs.SetInt("itemselect", 2);
    }
    public void Item4Open()
    {
        particle.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(true);

        item1.GetComponent<Image>().sprite = yellowBack;
        item2.GetComponent<Image>().sprite = yellowBack;
        item3.GetComponent<Image>().sprite = yellowBack;
        item4.GetComponent<Image>().sprite = greenBack;

        PlayerPrefs.SetInt("itemselect", 3);
    }

    // ---------LOCKS---------------- 1000 3000 7500

    public void Lock1Open()
    {

        int money = PlayerPrefs.GetInt("moneyy");
        int lockControl = PlayerPrefs.GetInt("lock1Control");

        if (money >= 1000 && lockControl == 0)
        {

            lock1.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 1000);
            PlayerPrefs.SetInt("lock1control", 1);
            Item2Open();
            uiManager.CoinTextUpdate();
        }
    }
    public void Lock2Open()
    {

        int money = PlayerPrefs.GetInt("moneyy");
        int lockControl = PlayerPrefs.GetInt("lock2Control");

        if (money >= 3000 && lockControl == 0)
        {

            lock2.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 3000);
            PlayerPrefs.SetInt("lock2control", 1);

            Item3Open();
            uiManager.CoinTextUpdate();
        }
    }
    public void Lock3Open()
    {

        int money = PlayerPrefs.GetInt("moneyy");

        int lockControl = PlayerPrefs.GetInt("lock3Control");

        if (money >= 7500 && lockControl == 0)
        {

            lock3.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 7500);
            PlayerPrefs.SetInt("lock3control", 1);

            Item4Open();
            uiManager.CoinTextUpdate();
        }
    }


}