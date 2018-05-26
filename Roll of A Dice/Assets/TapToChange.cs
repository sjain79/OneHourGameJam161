using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToChange : MonoBehaviour {

    public int currentNumber = 1;
    public Sprite[] numbers;

    SpriteRenderer mySpriteRender;

    private void Awake()
    {
        mySpriteRender = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        if (currentNumber < 6)
        {
            currentNumber++;
        }
        else
        {
            currentNumber = 1;
        }

        mySpriteRender.sprite = numbers[currentNumber - 1];
    }

    private void Update()
    {
        mySpriteRender.sprite = numbers[currentNumber - 1];
    }
}
