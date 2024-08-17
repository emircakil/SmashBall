using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;
public class IAPController : MonoBehaviour, IStoreListener
{
    public UIManager uiManager;
    public IStoreController controller;
    public string[] product;
    public SoundManager soundManager;

    public void Start()
    {
        IAPStart();
    }

    public void IAPStart()
    {
        var module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        foreach (string item in product) { 
        
            builder.AddProduct(item, ProductType.Consumable);
        }

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Failed to Initialize");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log(message);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Failed Purchase");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (string.Equals(e.purchasedProduct.definition.id, product[0], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("moneyy", PlayerPrefs.GetInt("moneyy") + 2000);
            uiManager.CoinTextUpdate();
            soundManager.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[1], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("moneyy", PlayerPrefs.GetInt("moneyy") + 5000);
            uiManager.CoinTextUpdate();
            soundManager.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[2], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("moneyy", PlayerPrefs.GetInt("moneyy") + 9000);
            uiManager.CoinTextUpdate();
            soundManager.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[3], StringComparison.Ordinal))
        {
            if (PlayerPrefs.HasKey("Noads") == true)
            {

                PlayerPrefs.SetInt("Noads", 1);
                uiManager.NoAdsDisable();
                soundManager.CashSound();
            }
            return PurchaseProcessingResult.Complete;
        }
        else
        {
            return PurchaseProcessingResult.Pending;
        }
    }

    public void IAPButton(string id)
    {
        Product product = controller.products.WithID(id);
        if (product != null && product.availableToPurchase)
        {
            controller.InitiatePurchase(product);
            Debug.Log("Buying");
        }
        else
        {
            Debug.Log("Not buying");
        }
    }
}

    //Consumable - bir kere satin alinabilir nesneler // non-Consumable - birden fazla kez satin alinabilir nesneler

