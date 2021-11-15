using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public float speed;
    private PlayerController playerCtrl;
    private float fowardBound = -10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (transform.position.x < fowardBound && gameObject.CompareTag("Shark"))
        {
            Destroy(gameObject);
        }

    }
}
