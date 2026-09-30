using System;
using UnityEngine;
using UnityEngine.Events;

public class BedInteraction : FirstPersonInteraction
{
    [SerializeField] private UnityEvent MoveToNextCycle;
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
        MoveToNextCycle.Invoke();
    }

}
