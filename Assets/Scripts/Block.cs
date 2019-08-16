using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int points;
    [HideInInspector] public Manager Current;

    private void OnDestroy()
    {
        if (Current != null)
            Current.DestroyBlock(points);
    }
}
