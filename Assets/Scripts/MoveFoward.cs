using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public float speed;
    private PlayerController playerCtrl;
    private float fowardBound = -10;
    GameManager GManager;
    // Start is called before the first frame update
    void Start()
    {
        GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GameActive; " + GManager.GameActive);
        if(GManager.GameActive == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (transform.position.x < fowardBound && gameObject.CompareTag("Shark"))
        {
            Destroy(gameObject);
        }

        if (transform.position.x < fowardBound && gameObject.CompareTag("Crab"))
        {
            Destroy(gameObject);
        }

    }
}
