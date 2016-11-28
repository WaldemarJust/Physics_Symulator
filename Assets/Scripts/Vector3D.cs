using UnityEngine;
using System.Collections;

public class Vector3D : MonoBehaviour
{


    public float x, y, z;
    public Vector3D(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vector3D Translate(Vector3D end)
    {
        return new Vector3D(end.x, end.y, end.z);
    }

    public static implicit operator Vector3(Vector3D m)
    {
        return new Vector3(m.x, m.y, m.z);
    }

    public static implicit operator Vector3D(Vector3 m)
    {
        return new Vector3D(m.x, m.y, m.z);
    }

    public Vector3D Position(GameObject A)
    {
        return new Vector3D(A.transform.position.x, A.transform.position.y, A.transform.position.z);
    }

    public static Vector3D Falling (GameObject B, float Fallingspeed)
    {
        return new Vector3D(B.transform.position.x, B.transform.position.y - Fallingspeed, B.transform.position.z);
    } 
}
