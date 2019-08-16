using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] Level[] levels;
    [SerializeField] Ammunition bombs;
    private int idx = -1;
    private int detectedBlocks = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void DestroyBlock(int points)
    {
        levels[idx].points += points;
        levels[idx].destroyed_block++;
    }

    private void Update()
    {
        if (bombs != null && levels.Length > 0)
        {
            if (detectedBlocks == levels[idx].destroyed_block)
            {
                //It open the win Window
            } else if (bombs.Ammo.Length <= 0) {
                //It open the lose window
            }
        }
    }

    public void Next()
    {
        SceneManager.LoadScene(levels[++idx].Name);
    }

    private void OnLevelWasLoaded(int level)
    {
        var blocks = GameObject.FindGameObjectsWithTag("Targay");
        detectedBlocks = blocks.Length;
        foreach (GameObject b in blocks)
            b.GetComponent<Block>().Current = this;
        bombs = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammunition>();
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
        [HideInInspector] public int destroyed_block;
    }

}
