using UnityEngine;
using System.Collections;

public class SphereCollision : MonoBehaviour
{
    public static float Fallingspeed;
    SphereCollision collisionCheck;   

    public float distance;
    public bool CheckIfCollision(GameObject Sphere, GameObject other)
    {
        //position = center, localScale = scale
        float MinX = other.transform.position.x - (other.transform.localScale.x / 2);
        float MinY = other.transform.position.y - (other.transform.localScale.y / 2);
        float MinZ = other.transform.position.z - (other.transform.localScale.z / 2);

        float MaxX = other.transform.position.x + (other.transform.localScale.x / 2);
        float MaxY = other.transform.position.y + (other.transform.localScale.y / 2);
        float MaxZ = other.transform.position.z + (other.transform.localScale.z / 2);

        float X = Mathf.Max(MinX, Mathf.Min(Sphere.transform.position.x, MaxX));
        float Y = Mathf.Max(MinY, Mathf.Min(Sphere.transform.position.y, MaxY));
        float Z = Mathf.Max(MinZ, Mathf.Min(Sphere.transform.position.z, MaxZ));

        distance = Mathf.Sqrt((X - Sphere.transform.position.x) * (X - Sphere.transform.position.x) + (Y - (Sphere.transform.position.y + 0.5f)) * (Y - (Sphere.transform.position.y + 0.5f)) + (Z - Sphere.transform.position.z) * (Z - Sphere.transform.position.z));

        return distance < Sphere.transform.localScale.y;
    }

    void Start()
    {
        collisionCheck = GetComponent<SphereCollision>();
        Fallingspeed = 0.1f;
        
    }

    void Update()
    {      
        this.transform.position = Vector3D.Falling(this.gameObject, Fallingspeed);
    }
}
