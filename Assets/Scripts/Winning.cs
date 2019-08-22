using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour

{
    [HideInInspector]public int numberoblocks;

    public GameObject WinScreen;
    // Start is called before the first frame update
    void Start()
    {
    
       

    }

    // Update is called once per frame
    void Update()
    {
        numberoblocks = GameObject.FindGameObjectsWithTag("Targay").Length;
        if (numberoblocks == 0)
        {
            Win();


        }


        void Win()
        {
            //WINNING CODE
            if(Random.Range(0,15) == 1)
            {
                Debug.Log("DID u JUST WIN??");
            }else
            Debug.Log("You Won!!!");

            WinScreen.SetActive(true);

        }

    }
}
