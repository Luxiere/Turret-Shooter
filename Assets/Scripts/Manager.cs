using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] Level[] levels;
    [SerializeField] Ammunition bombs;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] TextMeshProUGUI winScore;
    [SerializeField] TextMeshProUGUI loseScore;
    [SerializeField] TextMeshProUGUI winLevel;
    [SerializeField] TextMeshProUGUI loseLevel;
    int idx = -1;
    int detectedBlocks = -1;
    int currentPoints = 0;
    int currentDestroyedBlocks = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //Load PlayerPrefs
    }

    public void DestroyBlock(int points)
    {
        currentPoints += points;
        currentDestroyedBlocks++;
    }

    private void Update()
    {
        if (bombs != null && levels.Length > 0 && detectedBlocks > -1)
        {
            if (detectedBlocks == currentDestroyedBlocks || bombs.Ammo.Length <= 0)
            {
                (bombs.Ammo.Length <= 0 ? loseScreen : winScreen).SetActive(true);
                (bombs.Ammo.Length <= 0 ? loseScore : winScore).text = currentPoints.ToString();
                (bombs.Ammo.Length <= 0 ? loseLevel : winLevel).text = "Level " + (idx + 1).ToString();
                if (detectedBlocks == currentDestroyedBlocks)
                {
                    levels[idx].points = currentPoints;
                    levels[idx].destroyed_block = currentDestroyedBlocks;
                    //Save PlayerPrefs
                }
                detectedBlocks = -1;
            }
        }
    }

    public void Next()
    {
        SceneManager.LoadScene(levels[++idx].Name);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ClearScreen()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    private void OnLevelWasLoaded(int level)
    {
        var blocks = GameObject.FindGameObjectsWithTag("Targay");
        foreach (GameObject b in blocks)
            b.GetComponent<Block>().Current = this;
        bombs = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammunition>();
        currentPoints = 0;
        currentDestroyedBlocks = 0;
        detectedBlocks = blocks.Length;
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
