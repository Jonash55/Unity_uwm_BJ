using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEx3 : MonoBehaviour
{
    
    public float speed = 10.0f;
    private float start_position;
    private float start_up_position;
    private float reverse_position;
    private float reverse_up_position;
    private bool odwroc_x = false;
    private bool odwroc_z = false;

    Rigidbody rb;
	
	// Start is called before the first frame update
    void Start()
    {

	rb = GetComponent<Rigidbody>();
	start_position = transform.position.x + speed;
	start_up_position = transform.position.y + speed;
	reverse_position = start_position - speed;
	reverse_up_position = start_up_position - speed;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
	Vector3 velocity_x = new Vector3(1, 0, 0);
	velocity_x = speed * Time.deltaTime * velocity_x.normalized;
	Vector3 velocity_z = new Vector3(0, 0, 1);
	velocity_z = speed * Time.deltaTime * velocity_z.normalized;

	if (!odwroc_x && !odwroc_z)
	{
	    rb.MovePosition(transform.position + velocity_x);
	    Vector3 rot1 = new Vector3(0, 0, 0);
	    transform.rotation = Quaternion.Euler(rot1);
	}

	if (!odwroc_x && odwroc_z)
        {
            rb.MovePosition(transform.position + velocity_z);
	    Vector3 rot2 = new Vector3(0, -90f, 0);
	    transform.rotation = Quaternion.Euler(rot2);
        }

	else if (odwroc_x && odwroc_z)
	{
	    rb.MovePosition(transform.position - velocity_x);
	    Vector3 rot3 = new Vector3(0, -180f, 0);
	    transform.rotation = Quaternion.Euler(rot3);
	}

	else if (odwroc_x && !odwroc_z)
	{
	     rb.MovePosition(transform.position - velocity_z);
	     Vector3 rot4 = new Vector3(0, -270f, 0);
	     transform.rotation = Quaternion.Euler(rot4);
	}


	if (transform.position.x >= start_position)
	    odwroc_z = true;
	else if (transform.position.x <= reverse_position)
	    odwroc_z = false;

	if (transform.position.z >= start_up_position)
	    odwroc_x = true;
	else if (transform.position.z <= reverse_up_position)
	    odwroc_x = false;
	}
}
