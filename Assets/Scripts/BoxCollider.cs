﻿using UnityEngine;
using System.Collections;

public class BoxCollider : MonoBehaviour
{
    public bool OnCollision;
    public GameObject Sphere;
    BoxCollider collisionCheck;

    public float distance;
    public bool CheckIfCollisionBox(GameObject Sphere, GameObject Self)
    {
        //position = center, localScale = scale
        float MinX = Self.transform.position.x - (Self.transform.localScale.x / 2);
        float MinY = Self.transform.position.y - (Self.transform.localScale.y / 2);
        float MinZ = Self.transform.position.z - (Self.transform.localScale.z / 2);
                    
        float MaxX = Self.transform.position.x + (Self.transform.localScale.x / 2);
        float MaxY = Self.transform.position.y + (Self.transform.localScale.y / 2);
        float MaxZ = Self.transform.position.z + (Self.transform.localScale.z / 2);

        float X = Mathf.Max(MinX, Mathf.Min(Sphere.transform.position.x, MaxX));
        float Y = Mathf.Max(MinY, Mathf.Min(Sphere.transform.position.y, MaxY));
        float Z = Mathf.Max(MinZ, Mathf.Min(Sphere.transform.position.z, MaxZ));

        distance = Mathf.Sqrt((X - Sphere.transform.position.x) * (X - Sphere.transform.position.x) + (Y - (Sphere.transform.position.y + 0.5f)) * (Y - (Sphere.transform.position.y + 0.5f)) + (Z - Sphere.transform.position.z) * (Z - Sphere.transform.position.z));

        return distance < Sphere.transform.localScale.y;
    }
    void Start()
    {
        collisionCheck = GetComponent<BoxCollider>();
    }

    void Update()
    {

        OnCollision = collisionCheck.CheckIfCollisionBox(Sphere, this.gameObject);
        SphereCollision.Fallingspeed = 0.1f;

        if (OnCollision)
        {
            if (this.gameObject.tag == "Obstacle")
            {
                Destroy(this.Sphere);
            }

            if (this.gameObject.layer == 8)
            {
                SphereCollision.Fallingspeed = 0;
            }
          
            if (this.gameObject.tag =="JumpBox" && this.gameObject.layer == 8)
            {
                SphereCollision.Fallingspeed = 0;
            }
        }
    }
}