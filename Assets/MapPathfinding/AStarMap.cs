using System.Collections.Generic;
using Unity.GraphToolkit.Editor;
using UnityEngine;

public class AStarMap : MonoBehaviour
{
    private List<AStarNode> NodesArr;
    [SerializeField] private GameObject Nodes;

    private void Awake()
    {
        NodesArr = new List<AStarNode>();
        RefreshList();
        //Debug.Log($"I have {NodesArr.Count} Nodes in my list");
    }
    void RefreshList()
    {
        NodesArr.Clear();
        foreach (AStarNode node in Nodes.transform.GetComponentsInChildren<AStarNode>())
        {
            NodesArr.Add(node);
        }
    }
    public void ClearParents()
    {
        foreach (AStarNode node in NodesArr)
        {
            node.Parent = null;
        }
    }
    public void AddNode(AStarNode node)
    {
        if (!NodesArr.Contains(node))
        {
            NodesArr.Add(node);
        }
    }
    public void RemoveNode(AStarNode node) 
    {
        if (NodesArr.Contains(node))
        {
            foreach (AStarNode nodeNeighbour in node.GetNeighbours()) 
            {
                node.RemoveNeighbourTwoWay(nodeNeighbour);
            }
            NodesArr.Remove(node);
        }
    }

}
