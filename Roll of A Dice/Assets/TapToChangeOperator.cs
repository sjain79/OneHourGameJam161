using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Operator { NULL, ADD, SUBTRACT, MULTIPLY, DIVIDE };

public class TapToChangeOperator : MonoBehaviour {

    public Operator myOperator = Operator.NULL;

    public Sprite[] operators;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
       

        if (myOperator==(Operator)4)
        {
            myOperator = 0;
        }
        else
        {
            myOperator++;
        }

        spriteRenderer.sprite = operators[(int)myOperator];

    }

    private void Update()
    {
        spriteRenderer.sprite = operators[(int)myOperator];

    }
}
