using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    Vector3D MovementVector = new Vector3D(0, 0, 0);
    public AudioManager AudioContainer;    
    AudioSource SoundSource;
    public float movement;
    public float MovementSpeed;
    public float SideMovement;
    public float HorizontalSpeed;
    public bool crashed;
    //public float PlayTime;

    private float SpeedTimer;

    // Use this for initialization
    void Start()
    {
       
        SideMovement = 1.0f;
        crashed = false;
        SoundSource = GetComponent<AudioSource>();
        SoundSource.clip = AudioContainer.au_Clip_BackBeat;
        SoundSource.Play();
        SpeedTimer = 0f;
        //PlayTime = 0;
    }
#if UNITY_STANDALONE
    // Update is called once per frame
    void Update()
    {
        if (CountDown.play)
        {
            //PlayTime += Time.deltaTime;
            SpeedTimer += Time.deltaTime;
            if (SpeedTimer > 20f)
            {
                MovementSpeed *= 1.5f;
                SpeedTimer = 0;
            }
            SoundSource.volume = 1;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3D MovementVector = new Vector3D(horizontal, vertical, 0);

            if (!crashed)
            {
                this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.x * HorizontalSpeed * Time.deltaTime, MovementVector.y, MovementVector.z + MovementSpeed * Time.deltaTime);
            }
            SideMovement = horizontal * MovementSpeed;
        }
    }

#endif
#if UNITY_ANDROID
    void Update()
    {       
        if (CountDown.play)
        {
            SoundSource.volume = 1;
            MovementVector = new Vector3D(0, 0, 0);
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovementVector.x = Input.GetTouch(0).deltaPosition.x;

            }

            if (!crashed)
            {
                this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.x * HorizontalSpeed * Time.deltaTime, MovementVector.y, MovementVector.z + MovementSpeed * Time.deltaTime);
            }

        }
    }
#endif

    void OnGUI()
    {
        HorizontalSpeed = GUI.HorizontalSlider(new Rect(0, 0, 120, 20), HorizontalSpeed, 0, 10);
    }

}

