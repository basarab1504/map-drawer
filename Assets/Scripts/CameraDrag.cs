using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 2;

    private new Camera camera;
    private Vector3 pressedDownPoint;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressedDownPoint = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0))
            return;

        Vector3 pos = camera.ScreenToViewportPoint(Input.mousePosition - pressedDownPoint);
        Vector3 targetPosition = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
        transform.Translate(targetPosition, Space.World);
    }
}
