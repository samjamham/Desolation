using System.Collections.Generic;
using Unity.GraphToolkit.Editor;
using UnityEngine;

public class AStarMap : MonoBehaviour
{
    private List<AStarNode> NodesArr;
    [SerializeField] private GameObject Nodes;

    private void Start()
    {
        NodesArr = new List<AStarNode>();
        foreach (AStarNode node in Nodes.transform.GetComponentsInChildren<AStarNode>())
        {
            NodesArr.Add(node);
        }
        Debug.Log($"I have {NodesArr.Count} Nodes in my list");
    }
    public void ClearParents()
    {
        foreach (AStarNode node in NodesArr)
        {
            node.Parent = null;
        }
    }
}
