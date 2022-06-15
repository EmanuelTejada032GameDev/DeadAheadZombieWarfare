using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class courageBox : MonoBehaviour
{

    private Mouse mouse;
    private Camera mainCamera;
    [SerializeField]
    private int _couragePointsAmount;


    [SerializeField]
    private GameObject _floatingTextPrefab;
  


    private void Awake()
    {
        mouse = new Mouse(); // this class should be called MouseCountroller  or CursorActions, MouseActions
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        mouse.Enable();
    }

    private void OnDisable()
    {
        mouse.Disable();
    }

    private void Start()
    {
        StartCoroutine("DestroyAfterNoUse");
        mouse.MouseActions.Click.started += _ => StartedClick(); // watch the samyam video
        mouse.MouseActions.Click.started += _ => EndedClick();// this is for events, so we do nothing on here since we dont need it in this project
    }

    private void Update()
    {
       
    }

    private void EndedClick()
    {
    }

   
    private void StartedClick()
    {
        detectCollisionOnClick();
    }

    public void detectCollisionOnClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(mouse.MouseActions.Position.ReadValue<Vector2>());
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if(hit.collider != null)
        {
            if(hit.collider.CompareTag("Collectible")){
                courageBox collectibleCourageBox = hit.collider.gameObject.GetComponent<courageBox>();
                if (collectibleCourageBox != null)
                {
                    collectibleCourageBox.AddCouragePoints();
                }
            }
        }
    }


    public void AddCouragePoints()
    {
        GameManager.Instance.couragePoints += _couragePointsAmount;
        if (_floatingTextPrefab) ShowFloatingText(_couragePointsAmount);
        Destroy(gameObject);
    }

    private void ShowFloatingText(int couragePoints)
    {
        var gameObj = Instantiate(_floatingTextPrefab, transform.position, Quaternion.identity);
        gameObj.GetComponent<FloatingText>().startOffset = new Vector3(transform.position.x, transform.position.y + 0.5f , transform.position.z);
        gameObj.GetComponent<TextMesh>().text = $"+{couragePoints.ToString()}";
        gameObj.GetComponent<Animator>().Play("floatUp");
        Destroy(gameObj, 0.4f);
    }

    IEnumerator DestroyAfterNoUse()
    {
        yield return new WaitForSeconds(100f);
        if (gameObject != null)
        {
           Destroy(gameObject);
        }
    }
}
