using System;
using UnityEngine;

public class BedInteraction : FirstPersonInteraction
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Action MoveToNextCycle;
    public override void Interact()
    {
        MoveToNextCycle?.Invoke();
    }

}
