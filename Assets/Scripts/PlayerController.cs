using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.forward * Input.GetAxis("Vertical");
        move += Vector3.right * Input.GetAxis("Horizontal");
        transform.position += move * speed * Time.deltaTime;

        if (transform.position.y <= -10)
        {
            Retry();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            SceneManager.LoadScene("Goal");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Retry();
        }

        if (collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(collision.gameObject);
        }
    }

    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
