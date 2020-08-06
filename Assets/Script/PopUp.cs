using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PopUp : MonoBehaviour
{
    [SerializeField]
    OnClickController ClickController;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(Hide);

    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {

        ClickController.isClickable = false;
        gameObject.SetActive(true);
    }

    private void Hide()
    {

        ClickController.isClickable = true;
        gameObject.SetActive(false);
    }

}
