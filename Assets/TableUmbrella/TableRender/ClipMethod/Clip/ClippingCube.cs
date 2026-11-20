using UnityEngine;

[ExecuteAlways]
public class ClippingCube : MonoBehaviour
{
    [SerializeField] private Vector3 ClipDistance;
    Vector4[] Planes = new Vector4[6];

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            Transform child = transform.GetChild(i);
            switch (i)
            {
                case 0:
                    child.position = this.transform.position + this.transform.right * ClipDistance.x;
                    break;
                case 1:
                    child.position = this.transform.position + -this.transform.right * ClipDistance.x;
                    break;                
                case 2:
                    child.position = this.transform.position + this.transform.up * ClipDistance.y;
                    break;
                case 3:
                    child.position = this.transform.position + -this.transform.up * ClipDistance.y;
                    break;                
                case 4:
                    child.position = this.transform.position + this.transform.forward * ClipDistance.z;
                    break;
                case 5:
                    child.position = this.transform.position + -this.transform.forward * ClipDistance.z;
                    break;
                default: 
                    break;
            }
            Plane plane = new Plane(child.transform.up, child.transform.position);
            Vector4 planeRepresentation = new Vector4(plane.normal.x, plane.normal.y, plane.normal.z, plane.distance);
            Planes[i] = planeRepresentation;
        }
        Shader.SetGlobalVectorArray("_Planes", Planes);
        if (Application.isEditor && !Application.isPlaying)
        {
            Shader.SetGlobalFloat("_Zoomies", 1);
        }        
        //foreach (Material mat in Materials)
        //{
        //    mat.SetVectorArray("_Planes", Planes);
        //}
        
    }
}
