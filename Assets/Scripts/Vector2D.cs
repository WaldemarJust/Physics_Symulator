using UnityEngine;
using System.Collections;

public class Vector2D : MonoBehaviour {

    public float x, y;
    public Vector2D(float x, float y)
    {
        this.x = x;
        this.y = y;
        
    }
    public Vector2D Translate(Vector2D end)
    {
        return new Vector2D(end.x, end.y);
    }

    public static implicit operator Vector2(Vector2D m)
    {
        return new Vector2(m.x, m.y);
    }

    public static implicit operator Vector2D(Vector2 m)
    {
        return new Vector2D(m.x, m.y);
    }

    public Vector2D Position(GameObject A)
    {
        return new Vector2D(A.transform.position.x, A.transform.position.y);
    }
}
