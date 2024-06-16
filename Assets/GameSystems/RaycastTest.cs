using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    private void OnMouseDown()
    {
        var ray = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        var hit = Physics2D.Raycast(ray, Vector2.zero);
        if(hit.collider == null)
        {
            Debug.Log("Mouse hit " + hit.collider.gameObject.name);
        }

    }
}
