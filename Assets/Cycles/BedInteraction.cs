using System;
using UnityEngine;

public class BedInteraction : FirstPersonInteraction
{
    public Action MoveToNextCycle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void Interact()
    {
        Debug.Log("Hi I'm a Bed");
        MoveToNextCycle?.Invoke();
    }

}
