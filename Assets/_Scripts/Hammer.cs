using UnityEngine;
using UnityEngine.UI;
using System;

public class Hammer : Item
{
    public Hammer()
    {
        Name = "Hammer of Justice";
        Description =
            "This mighty hammer wasn’t made for building - it was made for breaking! With a single powerful strike, it removes unwanted cells from the game board, clearing space for new opportunities. Use it wisely - every hit can change the course of the game!";
        
        
    }

    private int value = 3;
    
    public override void ApplyOneTime()
    {
        --value;
        if (value != 0)
        {
            InvokeOnValueDecrease();
        }
        else
        {
            InvokeOnDestroy();
        }
    }
}
