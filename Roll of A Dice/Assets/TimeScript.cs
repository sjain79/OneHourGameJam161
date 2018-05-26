using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {


    Text mText;
    public GameObject b;
    int t=60;
	// Use this for initialization
	void Start ()
    {
        mText = GetComponent<Text>();
        InvokeRepeating("Sub", 1, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        mText.text = "Time Remaining  "+t.ToString();

        if (t==0)
        {
            ShowPanel();
        }
	}

    void Sub()
    {
        if (t > 0)
        {
            t--;
        }
    }

    void ShowPanel()
    {
        b.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
