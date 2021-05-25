using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class dragAndDrop : MonoBehaviour
{
    float ZPosition;
    Vector3 Offset;
    //Camera MainCamera;
    bool Dragging;

    public Camera MainCamera;
    [Space]
    [SerializeField]
    public UnityEvent OnBeginDrag;
    [SerializeField]
    public UnityEvent OnEndDrag;



    void Start()
    {
        //MainCamera = Camera.main;
        ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {
        if (Dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZPosition);
            transform.position = MainCamera.ScreenToViewportPoint(position + new Vector3(Offset.x, Offset.y));
        }
    }

    //private Vector3 screenPoint;
    //private Vector3 offset;

    void OnMouseDown()
    {
        if (!Dragging)
        {
            BeginDrag();
        }
        //    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
    }

    void OnMouseUp()
    {
        EndDrag();
        //    Vector3 coursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        //    Vector3 coursorPosition = Camera.main.ScreenToWorldPoint(coursorPoint) + offset;
        //    transform.position = coursorPosition;
    }

    public void BeginDrag ()
    {
        OnBeginDrag.Invoke();
        Dragging = true;
        Offset = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }

    public void EndDrag ()
    {
        OnEndDrag.Invoke();
        Dragging = false;
    }
}
