using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public AudioManager AudioContainer;

    AudioSource SoundSource;
    public float movement;
    public float MovementSpeed;
    public float SideMovement;
    public bool crashed;

    // Use this for initialization
    void Start()
    {
        MovementSpeed = 10.0f;
        SideMovement = 1.0f;
        crashed = false;
        SoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown.play)
        {
            if (!SoundSource.isPlaying)
            {
                SoundSource.clip = AudioContainer.au_Clip_Start;
                SoundSource.Play();
                SoundSource.clip = AudioContainer.au_Clip_BackBeat;
                SoundSource.Play();
            }
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3D MovementVector = new Vector3D(horizontal, vertical, 0);

            if (!crashed)
            {
                this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.x, MovementVector.y, MovementVector.z + MovementSpeed * Time.deltaTime);
            }
            SideMovement = Input.GetAxis("Horizontal") * MovementSpeed;
            SideMovement *= Time.deltaTime;
        }
    }
}
