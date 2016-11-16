using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public bool grounded = false;
    public float movement;
    public float MovementSpeed;
    public float SideMovement;
    public float Fallingspeed;

    // Use this for initialization
    void Start ()
    {
        MovementSpeed = 15.0f;
        Fallingspeed = 15.0f;
        SideMovement = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!grounded)
        {
            this.gameObject.transform.position = Vector3D.Falling(this.gameObject, Fallingspeed);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3D MovementVector = new Vector3D(horizontal, vertical, 0);

        this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.x, MovementVector.y, MovementVector.z + MovementSpeed * Time.deltaTime); 
        SideMovement = Input.GetAxis("Horizontal") * MovementSpeed;
        movement *= Time.deltaTime;
        SideMovement *= Time.deltaTime;
        transform.Translate(SideMovement, 0, movement);
    }
}
