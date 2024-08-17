using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonSource;
    public AudioSource blowupSource;
    public AudioSource cashSource;
    public AudioSource completeSource;
    public AudioSource hitSource;

    public AudioClip buttonClip;
    public AudioClip blowUpClip;
    public AudioClip cashClip;
    public AudioClip completeClip;
    public AudioClip hitClip;

    public void ButtonSound() {

        buttonSource.PlayOneShot(buttonClip);

    }

    public void BlowUpSound()
    {

        blowupSource.PlayOneShot(blowUpClip, 0.5f);

    }
    public void CashSound()
    {

        cashSource.PlayOneShot(cashClip);

    }
    public void completeSound()
    {

        completeSource.PlayOneShot(completeClip);

    }
    public void hitSound()
    {

        hitSource.PlayOneShot(hitClip);

    }


}
