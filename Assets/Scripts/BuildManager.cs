using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public TurretBlueprint turretToBuild = null;
    public GameObject StandardTurret;
    public GameObject LaserBeamer;
    public GameObject MissileLauncher;
    public GameObject BuildEffect;
    public static BuildManager instance;
    private Node SelectedNode;
    public NodeUI nodeUI;
    
    private void Awake()
    {
        instance = this;
    }
    public bool CanBuild { get { return turretToBuild.prefab != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money >= turretToBuild.cost)
        {
            GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;
            GameObject B_effect = Instantiate(BuildEffect, node.GetBuildPosition(), Quaternion.identity);
            Destroy(B_effect, 4f);
            PlayerStats.Money -= turretToBuild.cost;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void SelectNode(Node node)
    {
        if(SelectedNode == node)
        {
            DeselectNode();
            return;
        }
        SelectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();
    }
}
