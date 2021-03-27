using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform cameraPosition = null;

    void LateUpdate()
    {
        transform.position = cameraPosition.position;
    }
}
