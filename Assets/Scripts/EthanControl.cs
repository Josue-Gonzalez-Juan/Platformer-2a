using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class EthanControl : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    public float move = 1;
    public float moveAmplify = 1;
    public float amplify = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //controls the animation speed
        move = Input.GetAxis("Horizontal");
        move = (Input.GetKey(KeyCode.LeftShift)) ? move * amplify : move; //turbo
        
        animator.SetFloat("Speed", Mathf.Abs(move));

        //turn Ethan Model either left or right
        float y = (move < 0) ? -90 : 90;
        Vector3 input = new Vector3(0, y, 0);
        transform.eulerAngles = input;
    }

    void FixedUpdate()
    {
        //
    }
}
