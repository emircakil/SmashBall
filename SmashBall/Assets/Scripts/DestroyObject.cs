using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Untagged") || hit.gameObject.CompareTag("Obstacle"))
        {
            hit.gameObject.SetActive(false);
        }
    }
}
