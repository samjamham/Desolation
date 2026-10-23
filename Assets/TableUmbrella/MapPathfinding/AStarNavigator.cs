using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class AStarNavigator : MonoBehaviour
{
    [SerializeField] private AStarMap m_Map;
    private List<AStarNode> m_Path;
    private List<AStarNode> m_PotentalPath;
    [SerializeField] private SplineContainer m_pathTracer;
    [SerializeField] private SplineContainer m_PotentalpathTracer;
    private AStarNode m_CurrentNode;


    public void Start()
    {      
        m_PotentalPath = new List<AStarNode>();
    }
    public void FindStartPath(AStarNode Start, AStarNode End)
    {
        m_Path = A_Star(Start, End);
        m_CurrentNode = Start;
        m_pathTracer.Spline = CreateSpline(m_Path, m_pathTracer.gameObject);
        m_pathTracer.gameObject.GetComponentInChildren<NavigatorPathTracer>().TracerReset(true, m_Path.Count - 1);

    }
    public void FindPotenalPath(AStarNode End)
    {
        m_PotentalPath = A_Star(m_CurrentNode, End);
        if (m_Path.SequenceEqual(m_PotentalPath))
            return;
        m_PotentalpathTracer.Spline = CreateSpline(m_PotentalPath, m_PotentalpathTracer.gameObject);
        m_PotentalpathTracer.GetComponentInChildren<NavigatorPathTracer>().TracerReset(true, m_PotentalPath.Count - 1);
    }
    public void ClearPotentalPath()
    {
        m_PotentalPath.Clear();
        m_PotentalpathTracer.Spline.Clear();
        m_PotentalpathTracer.GetComponentInChildren<NavigatorPathTracer>().TracerReset(false);

    }
    public void UpdateToNewPath()
    {
       if(m_PotentalPath.Count == 0)    
            return;

        m_Path = new List<AStarNode>(m_PotentalPath);
        transform.position = m_CurrentNode.transform.position;
        m_pathTracer.Spline = CreateSpline(m_Path, m_pathTracer.gameObject);
        m_pathTracer.gameObject.GetComponentInChildren<NavigatorPathTracer>().TracerReset(true, m_Path.Count - 1);
        m_PotentalpathTracer.Spline.Clear();
        m_PotentalpathTracer.GetComponentInChildren<NavigatorPathTracer>().TracerReset(false);
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
            bool Exhaust = true;
            foreach (AStarNode nodeA in OpenList)
            {
                foreach (AStarNode nodeB in nodeA.GetNeighbours())
                {
                    if (OpenList.Contains(nodeB)) continue;
                    Exhaust = false;
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
            if (Exhaust)
            {
                m_Map.ClearParents();
                return new List<AStarNode> { start };
            }
        }
        //Should never get here, if program has reached here something has gone wrong :3
        m_Map.ClearParents();
        return new List<AStarNode> { start };
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
    }

    public void OnCycleChange(bool IsNight)
    {
        MoveToNextNode();
    }
    private void MoveToNextNode()
    {
        if (m_Path.Count > 1)
        {
            if (m_CurrentNode.GetNeighbours().Contains(m_Path[1]))
            {
                transform.position = m_Path[1].transform.position;
                m_Path.RemoveAt(0);
                m_CurrentNode = m_Path[0];
                m_pathTracer.Spline = CreateSpline(m_Path, m_pathTracer.gameObject);
                m_pathTracer.gameObject.GetComponentInChildren<NavigatorPathTracer>().TracerReset(true, m_Path.Count - 1);
            }
        }
        if (m_PotentalPath.Count > 0)
        {
            FindPotenalPath(m_PotentalPath.Last());
            if (m_Path.SequenceEqual(m_PotentalPath))
                return;
            m_PotentalpathTracer.Spline = CreateSpline(m_PotentalPath, m_PotentalpathTracer.gameObject);
            m_PotentalpathTracer.GetComponentInChildren<NavigatorPathTracer>().TracerReset(false);
        }
    }

    public void AddNode(AStarNode node)
    {
        m_Map.AddNode(node);    
    }
    public void RemoveNode(AStarNode node)
    {
        m_Map.RemoveNode(node);
    }

    public Spline CreateSpline(List<AStarNode> Nodes, GameObject Tracer)
    {
        Spline nSpline = new Spline();
        foreach (AStarNode Node in Nodes)
        {
            BezierKnot knot = new BezierKnot();
            knot.Position = Tracer.transform.InverseTransformPoint(Node.transform.position);
            nSpline.Add(knot);
        }
        nSpline.SetTangentMode(TangentMode.AutoSmooth);
        return nSpline;
    }
}
