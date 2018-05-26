using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDiceScript : MonoBehaviour {

    public Sprite[] numbers;

    private void Update()
    {
        
    }

    public void SetNumber(int n)
    {
        SpriteRenderer sR = GetComponent<SpriteRenderer>();

        sR.sprite = numbers[n];
        Debug.Break();
    }
}
