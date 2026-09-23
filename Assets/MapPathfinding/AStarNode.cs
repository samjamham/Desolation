using System.Collections.Generic;
using Unity.GraphToolkit.Editor;
using UnityEngine;

public class AStarNode : MonoBehaviour
{
    public int NodeID { get; private set; }
    [SerializeField] private List<AStarNode> Neighbours = new List<AStarNode>();
    public AStarNode Parent;

    public void Update()
    {
        //For testing only
        //----------------
        foreach (AStarNode nodes in Neighbours)
        {
            Debug.DrawLine(transform.position, nodes.transform.position);
        }
        //----------------
    }
    public List<AStarNode> GetNeighbours()
    {
        return Neighbours;
    }
    public void AddNeighbourOneWay(AStarNode node)
    {
        if (!Neighbours.Contains(node))
            Neighbours.Add(node);
    } public void AddNeighbourTwoWay(AStarNode node)
    {
        AddNeighbourOneWay(node);
        node.AddNeighbourOneWay(this);
    }
    public void RemoveNeighbourOneWay(AStarNode node)
    {
        if (Neighbours.Contains(node))
            Neighbours.Remove(node);
    }    
    public void RemoveNeighbourTwoWay(AStarNode node)
    {
        RemoveNeighbourOneWay(node);
        node.RemoveNeighbourOneWay(this);
    }

}
