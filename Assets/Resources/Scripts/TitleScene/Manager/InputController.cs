using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerClickHandler
{
    public OutgameManager outgameManager;

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
                    StageEnterCheck(stage);
                    //SelectStage(stage);
                    //outgameManager.StageEnter(stage);
                    Debug.Log("스테이지");
                    break;

                case "Player":
                    Debug.Log("플레이어");
                    break;

            }
        }
    }

    public void StageEnterCheck(Stage stage)
    {
        if(stage.stageEnterValue == false)
        {
            return;
        }
        else
        {
            SelectStage(stage);
            outgameManager.StageEnter(stage);
        }
    }

    public void SelectStage(Stage stage)
    {
        outgameManager.CurrentStageDataSend(stage);
    }
}
