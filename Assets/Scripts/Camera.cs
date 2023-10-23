using UnityEngine;

public class Camera : MonoBehaviour
{
    public float PanSpeed = 1f;
    public float panBorderThickness = 70f;
    private float speed;
    public float scrollSpeed = 10f;

    // Update is called once per frame
    void Update()
    {

        if(GameManager.gameOver)
        {
            this.enabled = false;
            return;
        }
        speed = PanSpeed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(-PanSpeed, 0, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(PanSpeed, 0, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(0, 0, -PanSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(0, 0, PanSpeed, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            pos.y -= scroll * scrollSpeed * Time.deltaTime;
        }
        else
        {
            if(Input.GetKey(KeyCode.KeypadPlus))
            {
                pos.y -= scrollSpeed * Time.deltaTime;
            }
           
            if(Input.GetKey(KeyCode.KeypadMinus))
            {
                pos.y += scrollSpeed * Time.fixedDeltaTime;
            }
            
        }
        pos.x = Mathf.Clamp(pos.x, 3f, 77f);
        pos.y = Mathf.Clamp(pos.y, 9f, 110f);
        pos.z = Mathf.Clamp(pos.z, -2f, 74f);
        transform.position = pos;
        
    }
}
