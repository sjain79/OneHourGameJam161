using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject leftDice1, leftDice2, leftDice3;
    public GameObject rightDice1, rightDice2, rightDice3;
    public GameObject firstOperator, secondOperator;
    public Text myText,mT,score;
    int firstNum, secondNum, thirdNum;

    public GameObject plusOne;

    int answer;

    int shouldBeAnswer;
    bool hasToChange = false;

    int scoren = 0;

    private void Start()
    {
        shouldBeAnswer = Random.Range(1, 20);
        //SetRightDice();
        myText.text = shouldBeAnswer.ToString();
        ChangeNumber();

        plusOne.SetActive(false);
    }

    public void Update()
    {

        GetNums();

        

        switch (firstOperator.GetComponent<TapToChangeOperator>().myOperator)
        {
            case Operator.NULL:
                OperatorNull(firstNum);
                break;
            case Operator.ADD:
                Add(firstNum, secondNum);
                break;
            case Operator.SUBTRACT:
                Subtract(firstNum, secondNum);
                break;
            case Operator.MULTIPLY:
                Multiply(firstNum, secondNum);
                break;
            case Operator.DIVIDE:
                Divide(firstNum, secondNum);
                break;
            default:
                break;
        }

        switch (secondOperator.GetComponent<TapToChangeOperator>().myOperator)
        {
            case Operator.NULL:
                OperatorNull();
                break;
            case Operator.ADD:
                Add(answer, thirdNum);
                break;
            case Operator.SUBTRACT:
                Subtract(answer, thirdNum);
                break;
            case Operator.MULTIPLY:
                Multiply(answer, thirdNum);
                break;
            case Operator.DIVIDE:
                Divide(answer, thirdNum);
                break;
            default:
                break;
        }


        //Debug.Log(answer+"\t"+shouldBeAnswer);
        //Debug.Log("Answ " + shouldBeAnswer % 10 + "\t" + (shouldBeAnswer / 10) % 10);


        if (answer==shouldBeAnswer && !hasToChange)
        {
            hasToChange = true;
            PlusPoint();
        }

        if (hasToChange)
        {
            hasToChange = false;
            ChangeNumber();
        }

        score.text = "Score "+scoren.ToString();
    }



    public void Add(int n, int m)
    {
        answer = n + m;
    }

    public void Subtract(int n, int m)
    {
        answer = n - m;
    }

    public void Multiply (int n, int m)
    {
        answer = n * m;
    }

    public void Divide(int n, int m)
    {
        answer = n / m;
    }

    public void OperatorNull(int n)
    {
        answer = n;
    }

    public void OperatorNull()
    {
        return;
    }

    public void GetNums()
    {
       firstNum= leftDice1.GetComponent<TapToChange>().currentNumber;
       secondNum= leftDice2.GetComponent<TapToChange>().currentNumber;
       thirdNum = leftDice3.GetComponent<TapToChange>().currentNumber;
    }


    void ChangeNumber()
    {
        
        shouldBeAnswer = Random.Range(1, 21);


        StartCoroutine(TextAnim());
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(2);
        rightDice1.GetComponent<Animator>().SetBool("Start Rolling", false);
        rightDice2.GetComponent<Animator>().SetBool("Start Rolling", false);
        SetRightDice();
    }

    void SetRightDice()
    {
        rightDice2.GetComponent<RightDiceScript>().SetNumber(shouldBeAnswer % 10);
        rightDice1.GetComponent<RightDiceScript>().SetNumber((shouldBeAnswer/10) % 10);
    }

    void PlusPoint()
    {
        plusOne.SetActive(true);
        Score();
        Debug.Log("Called");
    }

   

    void Score()
    {
        scoren++;
        leftDice1.GetComponent<TapToChange>().currentNumber = 1;
        leftDice2.GetComponent<TapToChange>().currentNumber = 1;
        leftDice3.GetComponent<TapToChange>().currentNumber = 1;

        firstOperator.GetComponent<TapToChangeOperator>().myOperator = Operator.NULL;
        secondOperator.GetComponent<TapToChangeOperator>().myOperator = Operator.NULL;
    }

    IEnumerator TextAnim()
    {
        int i = 0;
        while (i<10)
        {
            i++;
            myText.text = Random.Range(0, 100).ToString();
            yield return new WaitForSeconds(0.0001f);
        }

        myText.text = shouldBeAnswer.ToString();

    }
}
