using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullBrain : MonoBehaviour
{
    private Bot bot;
    private Vector3 shellPos;
    private bool hasShell = false;
    GameManager GManager;

    // Start is called before the first frame update
    void Start()
    {
        GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bot = GetComponent<Bot>();
        NavPlayerMovement.pickedUpShell += shellAcquired;
    }

    void shellAcquired(Vector3 pos)
    {
        shellPos = pos;
        hasShell = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GManager.GameActive == true)
        {
            if (hasShell)
            {
                bot.Seek(shellPos);
            }
            else
            {
                bot.Wander();
            }
        }

    }
}
