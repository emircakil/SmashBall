using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingeltonBanner : MonoBehaviour
{
    private static SingeltonBanner obje = null;

    private void Awake()
    {
        if (obje == null)
        {
            obje = this;
            DontDestroyOnLoad(this);
        }
        else if (obje != obje) {

            Destroy(gameObject);
        }
    }
}
