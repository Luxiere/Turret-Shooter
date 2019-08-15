using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] Level[] levels;
    private int idx = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        //SceneManager.LoadScene(idx);
    }

    public int TotalPoints()
    {
        int total = 0;
        foreach (Level l in levels)
            total += l.points;
        return total;
    }

    [System.Serializable]
    public struct Level
    {
        public string Name;
        [HideInInspector] public int points;
    }

}
