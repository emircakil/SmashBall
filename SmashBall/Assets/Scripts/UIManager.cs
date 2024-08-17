using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    public SoundManager soundManager;
    public Image whiteeffectimage;
    private int effectcontrol = 0;
    public Animator LayoutAnimator;
    bool radialShineCondition;

    public GameObject player;
    public GameObject finishLine;

    public GameObject settingsOpen;
    public GameObject settingsClose;
    public GameObject layoutBackground;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject vibrationOn;
    public GameObject vibrationOff;
    public GameObject iap;
    public GameObject information;
    public GameObject introHand;
    public GameObject noAds;
    public GameObject shop;
    public GameObject coin;
    public TextMeshProUGUI coin_text;
    public GameObject restartScene;


    public GameObject finishScreen;
    public GameObject completed;
    public GameObject coinFinishScr;
    public GameObject rewarded;
    public GameObject noThanks;
    public GameObject radialShine;
    public Image fillImageRate;

    public GameObject achievedCoin;
    public GameObject nextLevel;
    public TextMeshProUGUI achievedText;
    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

     

        if (PlayerPrefs.GetInt("Noads") == 1) { 
        
            NoAdsDisable();
        }

        CoinTextUpdate();
    }

    private void Update()
    {
        if (radialShineCondition == true) {

            radialShine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 100f) * Time.deltaTime);
        }

        fillImageRate.fillAmount = (player.transform.position.z) / (finishLine.transform.position.z);

    }

    public void FirstTouch()
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(false);
        layoutBackground.SetActive(false);
        soundOn.SetActive(false);
        soundOff.SetActive(false);
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
        introHand.SetActive(false);
        noAds.SetActive(false);
        shop.SetActive(false);
        coin.SetActive(false);
    }

    public void NoAdsDisable() { 
        noAds.SetActive(false);
    }

    public void RestartButtonActive()
    {
        restartScene.SetActive(true);
    }

    public void RestartScene()
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void FinishScreen()
    {

        StartCoroutine(FinishLaunch());
    }

    public IEnumerator FinishLaunch()
    {
        radialShineCondition = true;
        finishScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        completed.SetActive(true);
        soundManager.completeSound();
        yield return new WaitForSecondsRealtime(0.8f);
        radialShine.SetActive(true);
        coinFinishScr.SetActive(true);
        soundManager.completeSound();
        yield return new WaitForSecondsRealtime(0.4f);
        rewarded.SetActive(true);
        soundManager.completeSound();
        yield return new WaitForSecondsRealtime(1.5f);
        noThanks.SetActive(true);

    }

    public IEnumerator AfterRewardButton() { 
    
        achievedCoin.SetActive(true);
        rewarded.SetActive(false);
        noThanks.SetActive(false);
        for (int i = 0; i <= 400; i += 4)
        {
            achievedText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
        }
      
        yield return new WaitForSecondsRealtime(1f);
        nextLevel.SetActive(true);

        
    }

    public void CoinTextUpdate()
    {
            coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();

    }

    public void Privacy_Policy()
    {
        Application.OpenURL("");
    }

    public void Terms_Of_Use()
    {
        Application.OpenURL("");
    }

    public void Settings_Open()
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(true);
        LayoutAnimator.SetTrigger("slide_in");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            AudioListener.volume = 0;
        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibrationOn.SetActive(true);
            vibrationOff.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibrationOn.SetActive(false);
            vibrationOff.SetActive(true);
        }
    }

    public void Settings_Close()
    {
        settingsOpen.SetActive(true);
        settingsClose.SetActive(false);
        LayoutAnimator.SetTrigger("slide_out");
    }

    public void Sound_On()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void Sound_Off()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On()
    {
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }

    public void Vibration_Off()
    {
        vibrationOn.SetActive(true);
        vibrationOff.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }

    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        whiteeffectimage.color = new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0); // Reset alpha to 0

        // Fade in
        while (whiteeffectimage.color.a < 1.0f)
        {
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }

        // Fade out
        while (whiteeffectimage.color.a > 0.0f)
        {
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }

        whiteeffectimage.gameObject.SetActive(false); // Deactivate image when effect is done
        Debug.Log("Efekt bitti");
    }
}
