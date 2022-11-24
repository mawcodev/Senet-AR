using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject[] instructions;
    private int instructionNumber;
    public Animator figuras;
    void Start()
    {
        instructionNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Next()
    {
        if(instructionNumber < instructions.Length - 1)
        {
            instructions[instructionNumber].SetActive(false);
            instructionNumber++;
            instructions[instructionNumber].SetActive(true);
            figuras.Play("Step"+instructionNumber);
        }
        else
        {
            Debug.Log("no se puedee");
        }
    }
}
