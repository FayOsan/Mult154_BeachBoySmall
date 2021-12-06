using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMove : MonoBehaviour
{
    public float speed;
    private PlayerController playerCtrl;
    private float fowardBound = -20;
    public Animator anim;
    GameManager GManager;
    // Start is called before the first frame update
    void Start()
    {
        GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GManager.GameActive == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (transform.position.z < fowardBound && gameObject.CompareTag("Shark"))
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
        }
    }
}

