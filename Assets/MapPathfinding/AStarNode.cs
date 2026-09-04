using System.Collections.Generic;
using Unity.GraphToolkit.Editor;
using UnityEngine;

public class AStarNode : MonoBehaviour
{
    public int NodeID { get; private set; }
    [SerializeField] private List<AStarNode> Neighbours;
    public AStarNode Parent;

    public void Update()
    {
        foreach (AStarNode nodes in Neighbours)
        {
            Debug.DrawLine(transform.position, nodes.transform.position);
        }  
    }
    public List<AStarNode> getNeighbours()
    {
        return Neighbours;
    }

}
