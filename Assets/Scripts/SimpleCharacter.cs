using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleCharacter : MonoBehaviour
{
    public float Speed = 10;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);

//        Movement(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        _rigidbody2D.MovePosition(Speed * Time.deltaTime *
                                  new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) + _rigidbody2D.position);
    }
}