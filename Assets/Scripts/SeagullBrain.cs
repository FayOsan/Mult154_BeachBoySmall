using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullBrain : MonoBehaviour
{
    private Bot bot;
    private Vector3 shellPos;
    private bool hasShell = false;

    // Start is called before the first frame update
    void Start()
    {
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
