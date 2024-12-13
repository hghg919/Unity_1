using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 5.0f;  // 상호작용 거리
    public GameObjectController objectController;  // ObjectController 참조
    public LayerMask interactLayer;

    public Image focusUI;
    private bool canInteractive = false;
    private TransformData currentInteract = null;


    void Update()
    {
        if(CanInteract())
        {
            focusUI.color = Color.red;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if(currentInteract != null)
                    Interact(currentInteract);
            }
        }
        else
        {
            focusUI.color = Color.white;
        }
        

    }

    private bool CanInteract()
    {
        // 메인 카메라에서 전방 방향으로 레이캐스트
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactLayer))
        {
            GameObject target = hit.transform.gameObject;

            // 충돌한 오브젝트의 이름이 "Model"이면 부모를 검색
            if (target.name == "Model" && target.transform.parent != null)
            {
                target = target.transform.parent.gameObject;
            }

            // Ray가 닿은 오브젝트가 ObjectController의 대상 오브젝트인지 확인
            foreach (var data in objectController.objectsToControl)
            {
                GameObject interactionTarget = data.linkedObject ?? data.targetObject;

                if (interactionTarget != null && hit.transform.gameObject == interactionTarget)
                {
                    currentInteract = data;
                    return true;
                }
            }       
        }

        currentInteract = null;
        return false;
    }

    void Interact(TransformData data)
    {
        GameObject interactionTarget = data.linkedObject ?? data.targetObject;
        data.isTrigger = !data.isTrigger;    
    }

    private void OnDrawGizmos()
    {
        // 카메라의 위치와 정면 방향 설정
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 rayOrigin = mainCamera.transform.position;
            Vector3 rayDirection = mainCamera.transform.forward;

            // 레이 그리기
            Gizmos.color = Color.red;  // 레이의 색상 설정
            Gizmos.DrawLine(rayOrigin, rayOrigin + rayDirection * interactionRange);

            // 레이 끝에 작은 구를 그려 시각적으로 표시
            Gizmos.DrawSphere(rayOrigin + rayDirection * interactionRange, 0.1f);
        }
    }
}
