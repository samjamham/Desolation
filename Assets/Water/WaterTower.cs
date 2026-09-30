using UnityEngine;

public class WaterTower : MonoBehaviour
{
    [field: SerializeField] public float capacity { get; private set; } //In Litres (L)
    [field: SerializeField] public float currentVolume {  get; private set; } //In Litres (L)

    [SerializeField] private WaterTower myPartner;
    [SerializeField] private GameObject myDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float RemoveVolume(float value)
    {
        value = Mathf.Abs(value);
        float amountShort = Mathf.Max(value - currentVolume, 0);
        currentVolume -= value;
        currentVolume = Mathf.Max(0, currentVolume);
        SetDisplay();
        return amountShort;
    }
    float Addvalue(float value)
    {
        value = Mathf.Abs(value);
        float amountExcess = Mathf.Max(value - (capacity - currentVolume), 0);
        currentVolume += value;
        currentVolume = Mathf.Min(capacity, currentVolume);
        SetDisplay();
        return amountExcess;
    }

    public void Transfer(float volume)
    {
        float transferAmount = Mathf.Min(Mathf.Min(volume, currentVolume), myPartner.capacity - myPartner.currentVolume);
        RemoveVolume(transferAmount);
        myPartner.Addvalue(transferAmount);  
    }
    private void SetDisplay()
    {
        //Debug
        Vector3 ls = myDisplay.transform.localScale;
        myDisplay.transform.localScale = new Vector3(ls.x, currentVolume / capacity, ls.z);
        //Debug
    }
}
