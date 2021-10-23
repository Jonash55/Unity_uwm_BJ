using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEx2 : MonoBehaviour
{
    
    public float speed = 10.0f;
    private float start_position;
    private bool odwroc;
    private float reverse_position;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

	rb = GetComponent<Rigidbody>();
	start_position = transform.position.x - speed;
	reverse_position = start_position + speed;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
	Vector3 velocity = new Vector3(-1, 0, 0);
	velocity = velocity.normalized * speed * Time.deltaTime;
	if (transform.position.x > start_position && odwroc == false)
	{
		rb.MovePosition(transform.position + velocity);
	}
	else if (transform.position.x < reverse_position && odwroc == true)
	{
		rb.MovePosition(transform.position - velocity);
	}
		
	if (transform.position.x <= start_position)
		odwroc = true;
	if (transform.position.x >= reverse_position)
		odwroc = false;
    }
}
