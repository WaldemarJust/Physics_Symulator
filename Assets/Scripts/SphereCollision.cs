using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SphereCollision : MonoBehaviour
{
    //SphereCollision collisionCheck;
    public AudioManager AudioContainer;

    /// <summary>
    /// A List of Colliders this Collider is currently colliding with
    /// </summary>
    public List<BoxCollider> Collisions;

    public float timer;    
    public float FallingSpeed;
    public float Jumpspeed;
    public float distance;
    AudioSource SoundSource;
    public bool CheckIfCollision(GameObject Sphere, GameObject other)
    {
        if (Sphere != null)
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

            distance = Mathf.Sqrt((X - Sphere.transform.position.x) * (X - Sphere.transform.position.x) + (Y - (Sphere.transform.position.y)) * (Y - (Sphere.transform.position.y)) + (Z - Sphere.transform.position.z) * (Z - Sphere.transform.position.z));

            return distance < Sphere.transform.localScale.y / 2;
        }
        return false;
    }

    void Start()
    {        
        FallingSpeed = 0.1f;
        Jumpspeed = 0f;
        timer = 0;
        SoundSource = GetComponent<AudioSource>();


    }

    void Update()
    {        
        this.transform.position = Vector3D.Falling(this.gameObject, FallingSpeed);
        this.transform.position = Vector3D.Jump(this.gameObject, Jumpspeed);
        if (this.gameObject.transform.position.y <= -20)
        {
            if (SoundSource.clip != AudioContainer.au_Clip_KillZone)
            {
                SoundSource.clip = AudioContainer.au_Clip_KillZone;
                SoundSource.Play();
            }
            timer += Time.deltaTime;
            if (timer > 2.5f)
            {
                Destroy(this.gameObject, 2.5f);
                SceneManager.LoadScene("LooseScene");
            }
        }
    }
}
