using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] List<Sprite> healthImages;
    [SerializeField] private float maxHealth;
    [SerializeField] private TurnManager playerActive;

    private float currentHealth, calcEffect, lastRecord, timer;
    private float waitTime = 1.0f;
    private float setBool = 0.5f;
    private int whereAt, counts, stayOn;
    private bool isOn, ending;

    //Images in list
    //3 lasts to display. 4 empty and 3 for warning
    

    void Start()
    {
        //13 images before displaying the ending.
        whereAt = 13;
        maxHealth = playerActive.maxHealth;
        Debug.Log("21ac: " + ending);

        //The value per image
        calcEffect = maxHealth / whereAt;
        //Debug.Log("21a001a: " + calcEffect);

        lastRecord = 0f;
        counts = 16;

        currentHealth = maxHealth;
        Image img = GetComponent<Image>();

        img.sprite = healthImages[healthImages.Count -1];

        isOn = true;        
    }

    private void Update()
    {
        Image img = GetComponent<Image>();

        currentHealth = playerActive.currentHealth;
        ending = playerActive.ending;

        timer += Time.deltaTime;


        if (timer > setBool)
            isOn = true;

        if (currentHealth != maxHealth &&  currentHealth != lastRecord && Mathf.Abs(lastRecord - currentHealth)  >= calcEffect)
        {
            lastRecord = currentHealth;
            //Debug.Log("21b000b: " + currentHealth);
            //Debug.Log("21b000c: " + lastRecord);

            counts--;
            Debug.Log("21b000d: " + counts);

            if (counts >= 4)
            {                   
                img.sprite = healthImages[counts];
                if (counts == 4)
                    stayOn = counts;
            }            
        }

        if (isOn && stayOn == 4 && timer > waitTime && !ending)
        {
            img.sprite = healthImages[4];
            timer = timer - waitTime;
        }
        else if (isOn && stayOn == 4 && timer > setBool && !ending)
        {
            img.sprite = healthImages[3];
        }

        //Debug.Log("21da: " + ending);
        if (ending)
        {
            img.sprite = healthImages[2];

            if (timer >= 0.1)
                img.sprite = healthImages[1];

            if (timer >= 0.2)
                img.sprite = healthImages[0];
        }
    }
}








//Calculations

//21a0000b: 1.384615 18/13          CurrD , 19/1.38 = 13.76



//18 full health    F

//Temp x            T
//21a000: 17.99961  A
//21a000: 17.99945  B

//21a000: 15.82279  A
//21a000: 15.81195  B

//Calc
//21a0000b: 1.384615    C
//To solve for the future - > How C would affect the visuals UI when requesting slower effect rate.

//Mathf.Approximately for floats, less necessary for this 'if', since the numbers will always be different.
//  if (A != F && A != T && Mathf.Abs(T - A) >= C)
//  {
//      T = A
//      Cal C and whereAt
//  }



//16.60963 - 15.21772 = 1.3919 which > C


