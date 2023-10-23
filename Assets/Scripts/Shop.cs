using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissileLauncher;
    public TurretBlueprint LaserBeamer;
    public Node node;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(StandardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(MissileLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(LaserBeamer);
    }
}
