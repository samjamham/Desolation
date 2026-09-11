using UnityEngine;
using UnityEngine.InputSystem;

public class NodeJoiner : MonoBehaviour
{
    public InputAction join;
    private bool mJoin = false;
    [SerializeField] private AStarNode nodeA;
    [SerializeField] private AStarNode nodeB;
    [SerializeField] private AStarNode nodeC;

    private void Start()
    {
        join.Enable();
    }

    private void Update()
    {
        if(join.triggered)
        {
            mJoin = !mJoin;
            if(mJoin)
            {
                nodeA.AddNeighbourTwoWay(nodeB);
                nodeA.AddNeighbourTwoWay(nodeC);
            }
            else
            {
                nodeA.RemoveNeighbourTwoWay(nodeB);
                nodeA.RemoveNeighbourTwoWay(nodeC);
            }
            
        }
    }


}
