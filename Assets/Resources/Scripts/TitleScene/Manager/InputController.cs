using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerClickHandler
{
    public OutgameManager ingameManager;

    RaycastHit raycastHit;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MouseInput();
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("ui");
        }
    }

    void MouseInput()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Ray clickPos = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(clickPos, out raycastHit))
        {
            switch (raycastHit.transform.tag)
            {
                case "Ship":
                    var Ship = raycastHit.transform.gameObject.GetComponent<Ship>();
                    Debug.Log("함선");
                    break;

                case "Stage":

                    var stage = raycastHit.transform.gameObject.GetComponent<Stage>();
                    SelectStage(stage);
                    ingameManager.StageEnter(stage);
                    Debug.Log("스테이지");
                    break;

                case "Player":
                    Debug.Log("플레이어");
                    break;

            }
        }
    }

    public void SelectStage(Stage stage)
    {
        ingameManager.CurrentStageDataSend(stage);
    }
}
