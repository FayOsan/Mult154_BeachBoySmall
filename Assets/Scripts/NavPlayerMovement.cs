using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavPlayerMovement : MonoBehaviour
{
    public float speed = 60.0f;
    public float rotationSpeed = 10.0f;
    Rigidbody rgBody = null;
    float trans = 0;
    float rotate = 0;
    public Animator anim;
    private Camera camera;
    GameManager GManager;
    protected GameObject player;

    private int Score = 0;

    public delegate void DropHive(Vector3 pos);
    public static event DropHive pickedUpShell;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rgBody = GetComponent<Rigidbody>();
        GManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameData.gamePlayStart = Time.time;
    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            pickedUpShell?.Invoke(transform.position + (transform.forward * 10));
        }*/
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        //float translation = Input.GetAxis("Vertical");
        if (GManager.GameActive == true)
        {
            float translation = Input.GetAxis("Horizontal");

            trans += translation;
        }
        //rotate += rotation;
    }

    private void FixedUpdate()
    {
        /*Vector3 rot = transform.rotation.eulerAngles;
        rot.y += rotate * rotationSpeed * Time.deltaTime;
        rgBody.MoveRotation(Quaternion.Euler(rot));
        rotate = 0;*/

        Vector3 move = transform.right * trans;
        rgBody.velocity = move * speed * Time.deltaTime;
        trans = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shark")
        {
            anim.SetTrigger("PlayerIsDead");
            GManager.GameActive = false;
            SceneManager.LoadScene("DeathScene");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shell")
        {
            Score += 5;
            Debug.Log("Scored " + Score);
        }
        if (Score >= 100)
        {
            GManager.GameActive = false;
            SceneManager.LoadScene("EndScene");
        }
    }

    IEnumerator ZoomOut()
    {
        const int ITERATIONS = 25;
        for (int z = 0; z < 10; z++)
        {
            camera.transform.Translate(camera.transform.forward * -1 * 15.0f / ITERATIONS);
            yield return new WaitForSeconds(1.0f / ITERATIONS);
        }
    }
}
