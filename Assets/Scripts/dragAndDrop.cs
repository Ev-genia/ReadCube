using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class dragAndDrop : MonoBehaviour
{
    float ZPosition;
    Vector3 Offset;
    bool Dragging;

    public Camera MainCamera;
    [Space]
    [SerializeField]
    public UnityEvent OnBeginDrag;
    [SerializeField]
    public UnityEvent OnEndDrag;



    void Start()
    {
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


    void OnMouseDown()
    {
        if (!Dragging)
        {
            BeginDrag();
        }
    }

    void OnMouseUp()
    {
        EndDrag();
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
