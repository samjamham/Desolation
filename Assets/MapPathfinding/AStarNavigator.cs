using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AStarNavigator : MonoBehaviour
{
    [SerializeField] private AStarMap m_Map;
    private List<AStarNode> m_Path;
    private List<AStarNode> m_PotentalPath;
    private AStarNode m_CurrentNode;
    [SerializeField] private AStarNode TestStart;
    [SerializeField] private AStarNode TestEnd;
    [SerializeField] private InputAction Move;
    [SerializeField] private InputAction MouseDown;


    public void Start()
    {
        Move.Enable();
        MouseDown.Enable();
        m_Path = A_Star(TestStart, TestEnd);
        m_PotentalPath = new List<AStarNode>();
        m_CurrentNode = TestStart;
    }
    public void FindNewPath(AStarNode End)
    {
        m_PotentalPath = A_Star(m_CurrentNode, End);
    }
    public void ClearNewPath()
    {
        m_PotentalPath.Clear();
    }
    public void UpdateToNewPath()
    {
       if(m_PotentalPath.Count == 0)    
            return;

        m_Path = new List<AStarNode>(m_PotentalPath);
        transform.position = m_CurrentNode.transform.position;
    }

    private List<AStarNode> A_Star(AStarNode start, AStarNode end)
    {
        if (start == end)
        {
            return new List<AStarNode> { start };
        }
        bool found = false;
        List<AStarNode> OpenList = new List<AStarNode>();
        List<AStarNode> ClosedList = new List<AStarNode>(); 
        OpenList.Add(start);
        while (!found)
        {
            foreach (AStarNode nodeA in OpenList)
            {
                foreach (AStarNode nodeB in nodeA.getNeighbours())
                {
                    if (OpenList.Contains(nodeB)) continue;
                    ClosedList.Add(nodeB);
                    nodeB.Parent = nodeA;
                    if (nodeB == end)
                    {
                        found = true;
                        ClosedList = RetracePath(nodeB, start);
                        ClosedList.Reverse();
                        m_Map.ClearParents();
                        return ClosedList;
                    }
                }
                if(found)
                {
                    break;
                }                
            }
            OpenList.AddRange(ClosedList);
            ClosedList.Clear();
        }
        return ClosedList;
    }
    private List<AStarNode> RetracePath(AStarNode end, AStarNode start)
    {
        List<AStarNode> Path = new List<AStarNode>();
        AStarNode CurrentNode = end;
        while (CurrentNode != start)
        {
            Path.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;
        }
        Path.Add(start);
        return Path;
    }
    public void Update()
    {

        if(Move.triggered)
        {
            OnMove();
        }
        if (MouseDown.triggered)
        {
            UpdateToNewPath();
        }
        for  (int i = 0; i < m_Path.Count -1; i++)
        {
            Debug.DrawLine(m_Path[i].transform.position + new Vector3(0f,0.3f,0f), m_Path[i+1].transform.position + new Vector3(0f, 0.3f, 0f), Color.rebeccaPurple);
        }
        if (m_PotentalPath.Count > 0)
        {
            for (int i = 0; i < m_PotentalPath.Count - 1; i++)
            {
                Debug.DrawLine(m_PotentalPath[i].transform.position + new Vector3(0f, 0.3f, 0f), m_PotentalPath[i + 1].transform.position + new Vector3(0f, 0.3f, 0f), Color.orange);
            }
        }
    }

    public void OnMove()
    {
        if (m_Path.Count > 1)
        {
            transform.position = m_Path[1].transform.position;
            m_Path.RemoveAt(0);
            m_CurrentNode = m_Path[0];
        }
        if(m_PotentalPath.Count > 0)
        {
            //if (m_CurrentNode != m_PotentalPath.Last())
                FindNewPath(m_PotentalPath.Last());
        }
    }

}
