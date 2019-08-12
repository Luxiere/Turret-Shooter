using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [Header("Material Offset")]
    [SerializeField] Vector2 minOffsetPoint = Vector2.zero;
    [SerializeField] Vector2 maxOffsetPoint = new Vector2(0.25f, 0.125f);
    void Update()
    {
        Vector2 distance = maxOffsetPoint - minOffsetPoint;
        Vector2 currentPosition = (Mathf.Sin(Time.timeSinceLevelLoad) + 1) * distance / 2;
        GetComponent<Renderer>().material.mainTextureOffset = currentPosition;
    }
}
