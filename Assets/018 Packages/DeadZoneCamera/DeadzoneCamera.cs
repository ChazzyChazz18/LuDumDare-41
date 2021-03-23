using UnityEngine;
//using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Camera))]
public class DeadzoneCamera : MonoBehaviour
{
    [SerializeField] private Renderer target;
    [SerializeField] private Rect deadzone;
    [SerializeField] private Vector3 smoothPos;
    [SerializeField] private bool isSmoothXStatic = false;
    [SerializeField] private bool isSmoothYStatic = false;

    [SerializeField] private Rect[] limits;

    protected Camera _camera;
    protected Vector3 _currentVelocity;

    public Rect Deadzone
    {
        get
        {
            return deadzone;
        }
    }

    public Rect[] Limits
    {
        get
        {
            return limits;
        }
    }

    public void Start()
    {
        smoothPos = target.transform.position;
        smoothPos.z = transform.position.z;
        _currentVelocity = Vector3.zero;

        _camera = GetComponent<Camera>();
        if (!_camera.orthographic)
        {
            Debug.LogError("deadzone script require an orthographic camera!");
            Destroy(this);
        }

        if (isSmoothYStatic)
            smoothPos.y = 0f;

        if (isSmoothXStatic)
            smoothPos.x = 0f;
    }

    public void Update()
    {
        float localX = target.transform.position.x - transform.position.x;
        float localY = target.transform.position.y - transform.position.y;


        if (localX < deadzone.xMin)
        {
            smoothPos.x += localX - deadzone.xMin;
        }
        else if (localX > deadzone.xMax)
        {
            smoothPos.x += localX - deadzone.xMax;
        }

        if (localY < deadzone.yMin)
        {
            smoothPos.y += localY - deadzone.yMin;
        }
        else if (localY > deadzone.yMax)
        {
            smoothPos.y += localY - deadzone.yMax;
        }

        Rect camWorldRect = new Rect();
        camWorldRect.min = new Vector2(smoothPos.x - _camera.aspect * _camera.orthographicSize, smoothPos.y - _camera.orthographicSize);
        camWorldRect.max = new Vector2(smoothPos.x + _camera.aspect * _camera.orthographicSize, smoothPos.y + _camera.orthographicSize);

        for (int i = 0; i < limits.Length; ++i)
        {
            if (limits[i].Contains(target.transform.position))
            {
                Vector3 localOffsetMin = limits[i].min + camWorldRect.size * 0.5f;
                Vector3 localOffsetMax = limits[i].max - camWorldRect.size * 0.5f;

                localOffsetMin.z = localOffsetMax.z = smoothPos.z;

                smoothPos = Vector3.Max(smoothPos, localOffsetMin);
                smoothPos = Vector3.Min(smoothPos, localOffsetMax);

                break;
            }
        }

        Vector3 current = transform.position;
        current.x = smoothPos.x; // we don't smooth horizontal movement
        current.y = smoothPos.y; // we don't smooth vertical movement

        transform.position = Vector3.SmoothDamp(current, smoothPos, ref _currentVelocity, 0.1f);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(DeadzoneCamera))]
public class DeadZonEditor : Editor
{
    public void OnSceneGUI()
    {
        DeadzoneCamera cam = target as DeadzoneCamera;

        Vector3[] vert =
        {
            cam.transform.position + new Vector3(cam.Deadzone.xMin, cam.Deadzone.yMin, 0),
            cam.transform.position + new Vector3(cam.Deadzone.xMax, cam.Deadzone.yMin, 0),
            cam.transform.position + new Vector3(cam.Deadzone.xMax, cam.Deadzone.yMax, 0),
            cam.transform.position + new Vector3(cam.Deadzone.xMin, cam.Deadzone.yMax, 0)
        };

        Color transp = new Color(0, 0, 0, 0);
        Handles.DrawSolidRectangleWithOutline(vert, transp, Color.red);

        for (int i = 0; i < cam.Limits.Length; ++i)
        {
            Vector3[] vertLimit =
           {
                new Vector3(cam.Limits[i].xMin, cam.Limits[i].yMin, 0),
                new Vector3(cam.Limits[i].xMax, cam.Limits[i].yMin, 0),
                new Vector3(cam.Limits[i].xMax, cam.Limits[i].yMax, 0),
                new Vector3(cam.Limits[i].xMin, cam.Limits[i].yMax, 0)
            };

            Handles.DrawSolidRectangleWithOutline(vertLimit, transp, Color.green);
        }
    }
}
#endif