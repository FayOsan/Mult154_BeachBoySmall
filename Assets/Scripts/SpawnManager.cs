using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsPrefab;
    public GameObject CrabPrefab;
    private Vector3 spawnpos = new Vector3(0, 2, 56);
    private PlayerController playerCtrl;
    GameManager GManager;

    // Start is called before the first frame update
    void Start()
    {
        GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnShark", 1, 1);
        InvokeRepeating("SpawnCrab", 4, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnShark()
    {
        if (GManager.GameActive == true)
        {
            spawnpos = new Vector3(Random.Range(-14, 14),0.10f ,120);
            
            Instantiate(obsPrefab, spawnpos, obsPrefab.transform.rotation);
        }
    }

    void SpawnCrab()
    {
        if (GManager.GameActive == true)
        {
            spawnpos = new Vector3(Random.Range(-7, 7), 0.50f, 56);

            Instantiate(CrabPrefab, spawnpos, CrabPrefab.transform.rotation);
        }
    }

}
