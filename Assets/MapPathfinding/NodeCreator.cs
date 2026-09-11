using UnityEngine;
using UnityEngine.InputSystem;

public class NodeCreator : MonoBehaviour
{
    public InputAction Create;
    private bool mCreate = false;
    private GameObject Node;
    private AStarNode nodeA;
    [SerializeField] private AStarNode nodeB;
    [SerializeField] private AStarNode nodeC;
    [SerializeField] private GameObject NodePrefab;
    [SerializeField] private AStarNavigator Navi;

    private void Start()
    {
        Create.Enable();
    }
    private void Update()
    {
        if (Create.triggered)
        {
            mCreate = !mCreate;
            if (mCreate)
            {
                Node = Instantiate(NodePrefab, transform.parent);
                GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.localScale = Vector3.one * 0.3f;
                Cube.transform.parent = Node.transform;
                Node.transform.position = new Vector3(-1, 0, 1);
                Cube.transform.position = new Vector3(-1, 0, 1);
                Node.GetComponent<HoverTest>().ChangeNavigator(Navi);
                nodeA = Node.GetComponent<AStarNode>();
                Navi.AddNode(nodeA);
                nodeA.AddNeighbourTwoWay(nodeB);
                nodeA.AddNeighbourTwoWay(nodeC);
            }
            else
            {
                nodeA.RemoveNeighbourTwoWay(nodeB);
                nodeA.RemoveNeighbourTwoWay(nodeC);
                Navi.RemoveNode(nodeA);
                Destroy(Node);
            }

        }
    }
}
