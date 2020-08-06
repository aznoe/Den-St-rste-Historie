using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pointer : MonoBehaviour
{

    public float m_Distance = 1000f;
    public LineRenderer m_LineRenderer = null;
    public LayerMask m_Everything = 0;
    public LayerMask m_Interactables = 0;
    public UnityAction<Vector3, GameObject> OnPointerUpdate = null;
    public bool timeLineIsRunning = true;


    private Transform m_CurrentOrigin = null;
    private GameObject m_CurrentObject = null;



    private void Awake()
    {
        PlayerEvents.OnControllerSource += UpdateOrigin;
        PlayerEvents.OnTriggerDown += ProcessTouchpadDown;
    }

    private void Start()
    {
        SetLineColor();
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerEvents.OnControllerSource -= UpdateOrigin;
        PlayerEvents.OnTriggerDown -= ProcessTouchpadDown;

    }

    private void Update()
    {
        Vector3 hitPoint = UpdateLine();

        m_CurrentObject = UpdatePointerStatus();


        if (OnPointerUpdate != null)
            OnPointerUpdate(hitPoint, m_CurrentObject);

    }

    private Vector3 UpdateLine()
    {
        // create ray
        RaycastHit hit = CreateRaycast(m_Everything);


        // default end
        Vector3 endPosition = m_CurrentOrigin.position + (m_CurrentOrigin.forward * m_Distance);


        //check hit
        if (hit.collider != null)
            endPosition = hit.point;

        // set position
        m_LineRenderer.SetPosition(0, m_CurrentOrigin.position);
        m_LineRenderer.SetPosition(1, endPosition);


        return endPosition;
    }


    private void UpdateOrigin(OVRInput.Controller controller, GameObject controllerObejct)
    {
        // set origin of pointer
        m_CurrentOrigin = controllerObejct.transform;

        // is laser visible?
        if(controller == OVRInput.Controller.Touchpad)
        {
            m_LineRenderer.enabled = false;
        }
        else
        {
            m_LineRenderer.enabled = true;

        }
    }

    private GameObject UpdatePointerStatus()
    {
        //Create Ray
        RaycastHit hit = CreateRaycast(m_Interactables);

        // check hit
        if (hit.collider)
            return hit.collider.gameObject;

        //return
        return null;
    }



    private RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;
        Ray ray = new Ray(m_CurrentOrigin.position, m_CurrentOrigin.forward);
        Physics.Raycast(ray, out hit, m_Distance, layer);


        return hit;
    }

    private void SetLineColor()
    {
        if (!m_LineRenderer)
            return;

        Color endColor = Color.white;
        endColor.a = 0.0f;

        m_LineRenderer.endColor = endColor;

       
    }

    private void ProcessTouchpadDown()
    {
        if (!m_CurrentObject)
            return;

        if(timeLineIsRunning == false && m_CurrentObject)
        {
            ClickOnGameObject();
        }
        else
        {
            return;
        }

    }


    //method that sends you to the abstract class and then to the object with the OnClick() function.
    private void ClickOnGameObject()
    {
        m_CurrentObject.GetComponent<InteractiveObjects>()?.OnClicked();
        m_CurrentObject.GetComponent<ObjectIsClicked>()?.OnClicked();
    }

    public void TimeLineIsRunning()
    {
        if (!timeLineIsRunning)
        {
            timeLineIsRunning = true;
            Debug.Log(timeLineIsRunning);
        }
        else
        {
            timeLineIsRunning = false;
            Debug.Log(timeLineIsRunning);
        }

    }

}
