using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasManager : MonoBehaviour {

    public Text PointText;
	// Use this for initialization
	void Start ()
    {
        PointText.text = string.Format("Diamonds: {0}", Utility.Points);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
