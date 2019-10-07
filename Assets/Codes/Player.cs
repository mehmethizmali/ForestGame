using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    Animator gameAnimate;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        gameAnimate = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        // Flip
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameAnimate.Play("flip", -1, 0f);
            jump();
        }

        // run
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameAnimate.Play("run", -1, 0f);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            gameAnimate.Play("stop", -1, 0f);
        }
    }

    void jump()
    {
        rigidbody.AddForce(new Vector3(0, 15, 0),ForceMode.Impulse);
    }
}
