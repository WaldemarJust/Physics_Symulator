using UnityEngine;
using System.Collections;

public class BoxCollider : MonoBehaviour
{
    public AudioManager AudioContainer;
    public GameObject Sphere;
    BoxCollider collisionCheck;
    public bool OnCollision;
    public float timer;
    public bool IsJumping;
    AudioSource SoundSource;
    



    public float distance;
    public bool CheckIfCollisionBox(GameObject Sphere, GameObject Self)
    {

        if (Sphere != null)
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

            distance = Mathf.Sqrt((X - Sphere.transform.position.x) * (X - Sphere.transform.position.x) + (Y - (Sphere.transform.position.y)) * (Y - (Sphere.transform.position.y)) + (Z - Sphere.transform.position.z) * (Z - Sphere.transform.position.z));

            return distance < Sphere.transform.localScale.y / 2;
        }
        return false;

    }
    void Start()
    {
        collisionCheck = GetComponent<BoxCollider>();
        timer = 0f;
        IsJumping = false;
        SoundSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Sphere != null)
        {
            OnCollision = collisionCheck.CheckIfCollisionBox(Sphere, this.gameObject);

            if (OnCollision)
            {
                if (this.gameObject.layer == 8)
                {
                    Sphere.GetComponent<SphereCollision>().Fallingspeed = 0;
                    timer = 0f;

                    if (this.gameObject.tag == "JumpBox")
                    {
                        Sphere.GetComponent<SphereCollision>().Jumpspeed = 0.7f;
                        IsJumping = true;
                        SoundSource.clip = AudioContainer.au_Clip_Jump;
                        SoundSource.Play();
                    }

                }

                if (this.gameObject.tag == "Obstacle")
                {
                    Sphere.GetComponent<Movement>().crashed = true;
                    if (!SoundSource.isPlaying)
                    {
                        SoundSource.clip = AudioContainer.au_Clip_crash;
                        SoundSource.Play();
                    }
                    Destroy(this.Sphere, 0.55f);
                }
            }
            else
            {
                if (this.gameObject.layer != 8)
                    Sphere.GetComponent<SphereCollision>().Fallingspeed = 0.2f;
            }

            if (IsJumping)
            {
                timer += Time.deltaTime;
                if (timer > 0.5f)
                {
                    Sphere.GetComponent<SphereCollision>().Jumpspeed = 0f;
                    Sphere.GetComponent<SphereCollision>().Fallingspeed = 0.2f;
                    IsJumping = false;
                }
            }
        }
    }
}