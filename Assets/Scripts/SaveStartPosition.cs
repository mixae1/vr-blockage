using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStartPosition : MonoBehaviour
{
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public void setStartPos() {
        transform.position = startPos;
    }
}
