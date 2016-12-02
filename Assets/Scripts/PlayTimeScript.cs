using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayTimeScript : MonoBehaviour
{
    public Text textObject;
    public float Playtime;

    // Use this for initialization
    void Start()
    {
        Playtime = 0;
        textObject.text = string.Empty;

    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown.play)
        {
            Playtime += Time.deltaTime;
            textObject.text = ((int)Playtime).ToString();
        }

    }
}
