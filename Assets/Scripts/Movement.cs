using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float movement;
    public float MovementSpeed;
    public float SideMovement;    

    // Use this for initialization
    void Start()
    {
        MovementSpeed = 10.0f;
        SideMovement = 1.0f;       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3D MovementVector = new Vector3D(horizontal, vertical, 0);

        this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.x, MovementVector.y, MovementVector.z + MovementSpeed * Time.deltaTime);
        SideMovement = Input.GetAxis("Horizontal") * MovementSpeed;
        SideMovement *= Time.deltaTime;
    }   
}
