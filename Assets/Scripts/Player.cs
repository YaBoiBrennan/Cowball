using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody2D rb;
    public float horizontalSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.M))
            SceneManager.LoadScene("LevelSelect");
    }

    public void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput * horizontalSpeed, 0);
        rb.AddForce(movement);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = collision.gameObject.transform;
        }
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
            transform.parent = null;
    }

}
