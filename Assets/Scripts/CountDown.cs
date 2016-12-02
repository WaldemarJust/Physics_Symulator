using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public AudioManager AudioContainer;
    public Text textObject;
    public GameObject menuObject;
    public float timer = 4;
    public static bool play = false;
    private bool textbool = true;  

    AudioSource SoundSource;

    // Use this for initialization
    void Start()
    {
        menuObject.SetActive(true);
        textObject.text = string.Empty;
        SoundSource = GetComponent<AudioSource>();
        Utility.Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (textbool)
        {            
            timer -= Time.deltaTime;
            textObject.text = ((int)timer).ToString();

            if (timer <= 0)
            {                
                play = true;
                menuObject.SetActive(false);
                textbool = false;
            }
        }
    }
}
