using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Node : MonoBehaviour
{
    private Renderer rend;

    [Header("Optional")]
    public GameObject turret;

    public BuildManager buildManager;
    public GameManager SelectTurret;
    public bool CanBuild = true;
    public Color DefColor = Color.white;
    public Color HoveredColor = Color.cyan;
    public Color SelectedColor = Color.green;
    public Color WrongColor = Color.red;
    public Vector3 OffSet = new Vector3(0, 0.5f, 0);
    private void Start()
    {
        SelectTurret = FindObjectOfType<GameManager>();
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        rend.material.color = DefColor;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            
            return;
        }
        
        if (buildManager.HasMoney)
        {
            rend.material.color = HoveredColor;
        }
        else
        {
            rend.material.color = WrongColor;
        }

    }

    private void OnMouseExit()
    {
       
        rend.material.color = DefColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = SelectedColor;
        }
            
        if(turret == null)
        {           
            if (buildManager.CanBuild)
            {
                buildManager.BuildTurretOn(this);
                
            }
            else
            {
                SelectTurret.SelectTurret();
                SelectTurret.Invoke("Deselect",2);
                Debug.Log("Select a turret");                             
            }
            
        }
        else
        {
           if(turret != null)
            {
                buildManager.SelectNode(this);
                return;
            }
           
            rend.material.color = WrongColor;
            Debug.Log("No empty Space");
        }
        
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + OffSet;
    }
}
