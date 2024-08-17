using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform VectorLeft;
    public Transform VectorRight;
    public Transform VectorForward;
    public Transform VectorBack;

    public void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.z = Mathf.Clamp(viewPos.z, VectorBack.transform.position.z, VectorForward.transform.position.z);
        viewPos.x = Mathf.Clamp(viewPos.x, VectorLeft.transform.position.x, VectorRight.transform.position.x);
        transform.position = viewPos;
    }
}
