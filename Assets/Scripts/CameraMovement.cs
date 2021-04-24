using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 2;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float maxZoom;
    [SerializeField] private float minZoom;
    [SerializeField] Map map;

    private new Camera camera;
    private Vector3 pressedDownPoint;

    Vector2 LeftBottomBound;
    Vector2 rightTopBound;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        AdjustCamera();
    }

    private void Start()
    {
        LeftBottomBound = map.LeftBottom + new Vector2(camera.aspect * camera.orthographicSize, camera.orthographicSize);
        rightTopBound = map.RightTop - new Vector2(camera.aspect * camera.orthographicSize, camera.orthographicSize);
    }

    private void Update()
    {
        UpdateZoom();
        UpdateDrag();
    }

    private void AdjustCamera()
    {
        Camera.main.transform.position = new Vector3(
            (Mathf.Abs(map.RightTop.x) - Mathf.Abs(map.LeftBottom.x)) / 2,
            (Mathf.Abs(map.RightTop.y) - Mathf.Abs(map.LeftBottom.y)) / 2,
            Camera.main.transform.position.z);
        var diff = Mathf.Abs(map.RightTop.y - map.LeftBottom.y);
        Camera.main.orthographicSize = Mathf.Clamp(diff / 2, minZoom, maxZoom);
    }

    private void UpdateZoom()
    {
        if (Input.mouseScrollDelta != Vector2.zero)
        {
            var delta = Input.mouseScrollDelta.y * -zoomSpeed * Time.deltaTime;
            var size = Mathf.Clamp(camera.orthographicSize + delta, minZoom, maxZoom);
            var diff = size - camera.orthographicSize;
            camera.orthographicSize = size;
            LeftBottomBound += new Vector2(diff, diff);
            rightTopBound -= new Vector2(diff, diff);
        }
    }

    private void UpdateDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressedDownPoint = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0))
            return;

        Vector3 viewportPoint = camera.ScreenToViewportPoint(Input.mousePosition - pressedDownPoint);
        Vector3 targetPosition = new Vector3(viewportPoint.x * dragSpeed, viewportPoint.y * dragSpeed, 0);
        transform.position += targetPosition * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LeftBottomBound.x, rightTopBound.x), Mathf.Clamp(transform.position.y, LeftBottomBound.y, rightTopBound.y), transform.position.z);
    }
}
