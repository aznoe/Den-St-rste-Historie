using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerEvents : MonoBehaviour
{

    #region Events
    public static UnityAction OnTriggerUp = null;
    public static UnityAction OnTriggerDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null;


    #endregion

    #region Anchors
    public GameObject m_LeftAnchor;
    public GameObject m_RightAnchor;
    public GameObject m_HeadAnchor;
    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    private OVRInput.Controller m_InputScource = OVRInput.Controller.None;
    private OVRInput.Controller m_Controller = OVRInput.Controller.None;
    private bool m_InputActive = true;
    #endregion

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        m_ControllerSets = CreateControllerSets();


    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;

    }

    // Update is called once per frame
    private void Update()
    {


        //Check for Active Input
        if (!m_InputActive)
            return;


        //check if a controller exists
        CheckForController();
        //check for input Source
        CheckInputSource();

        //Check for actual input
        Input();

    }


    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = m_Controller;

        //Right remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.RTrackedRemote;



        //left remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.LTrackedRemote;



        //if no controllers, headset
        if (!OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) && !OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.Touchpad;



        // update

        m_Controller = UpdateSource(controllerCheck, m_Controller);




    }


    private void CheckInputSource()
    {
        // update
        m_InputScource = UpdateSource(OVRInput.GetActiveController(), m_InputScource);


    }

    private void Input()
    {
        // IndexTrigger Down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (OnTriggerDown != null)
                OnTriggerDown();
        }

        // IndexTrigger up
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (OnTriggerUp != null)
                OnTriggerUp();
        }


    }


    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous)
    {
        // if the values are the same, return
        if (check == previous)
            return previous;

        // get controller object
        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);

        //if no controller, set to headset
        if (controllerObject == null)
            controllerObject = m_HeadAnchor;

        // send event out
        if(OnControllerSource != null)
        {
            OnControllerSource(check, controllerObject);
        }



        return check;
    }


    private void PlayerFound()
    {
        m_InputActive = true;
    }

    private void PlayerLost()
    {
        m_InputActive = false;
    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            { OVRInput.Controller.LTrackedRemote, m_LeftAnchor },
            { OVRInput.Controller.RTrackedRemote, m_RightAnchor },
            { OVRInput.Controller.Touchpad, m_HeadAnchor }
        };
        return newSets;
    }
}
