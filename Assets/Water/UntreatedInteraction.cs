using UnityEngine;

public class UntreatedInteraction : FirstPersonInteraction
{
    [SerializeField] private WaterTower myWaterTower;
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
        Debug.Log($"Hello I'm Untreated I have {myWaterTower.currentVolume} out of {myWaterTower.capacity}: ({myWaterTower.currentVolume / myWaterTower.capacity * 100}%)");
    }

}
