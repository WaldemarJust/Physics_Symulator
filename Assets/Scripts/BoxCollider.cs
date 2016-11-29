using UnityEngine;
using System.Collections;

public class BoxCollider : MonoBehaviour
{
    public bool OnCollision;
    public float timer;
    public bool IsJumping;

    private AudioSource SoundSource;
    private BoxCollider collisionCheck;

    public AudioManager AudioContainer;
    public SphereCollision Sphere;
    public Movement Movement;



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
        Sphere = FindObjectOfType<SphereCollision>();
        Movement = Sphere.GetComponent<Movement>();
        collisionCheck = GetComponent<BoxCollider>();
        timer = 0f;
        IsJumping = false;
        SoundSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Sphere != null)
        {
            OnCollision = collisionCheck.CheckIfCollisionBox(Sphere.gameObject, this.gameObject);

            if (OnCollision)
            {
                if (!Sphere.Collisions.Contains(this))
                {
                    Sphere.Collisions.Add(this);

                    if (this.gameObject.layer == 8)
                    {
                        Sphere.FallingSpeed = 0;
                        timer = 0f;

                        if (this.gameObject.tag == "JumpBox")
                        {
                            Sphere.Jumpspeed = 0.7f;
                            IsJumping = true;
                            SoundSource.clip = AudioContainer.au_Clip_Jump;
                            SoundSource.Play();
                        }

                    }

                    if (this.gameObject.tag == "Obstacle")
                    {
                        Movement.crashed = true;
                        if (!SoundSource.isPlaying)
                        {
                            SoundSource.clip = AudioContainer.au_Clip_crash;
                            SoundSource.Play();
                        }
                        Destroy(this.Sphere, 0.55f);
                    }
                }
            }
            else
            {
                if (Sphere.Collisions.Contains(this))
                {
                    Sphere.Collisions.Remove(this);
                }
                if (Sphere.Collisions.Count == 0)
                {
                    Sphere.FallingSpeed = 0.2f;
                }
            }

            if (IsJumping)
            {
                timer += Time.deltaTime;
                if (timer > 0.5f)
                {
                    Sphere.Jumpspeed = 0f;
                    Sphere.FallingSpeed = 0.2f;
                    IsJumping = false;
                }
            }
        }
    }
}