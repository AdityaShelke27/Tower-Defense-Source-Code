using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public Node target;
    public GameObject UI;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }
}
