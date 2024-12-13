using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 5.0f;  // ��ȣ�ۿ� �Ÿ�
    public GameObjectController objectController;  // ObjectController ����
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
        // ���� ī�޶󿡼� ���� �������� ����ĳ��Ʈ
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactLayer))
        {
            GameObject target = hit.transform.gameObject;

            // �浹�� ������Ʈ�� �̸��� "Model"�̸� �θ� �˻�
            if (target.name == "Model" && target.transform.parent != null)
            {
                target = target.transform.parent.gameObject;
            }

            // Ray�� ���� ������Ʈ�� ObjectController�� ��� ������Ʈ���� Ȯ��
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
        // ī�޶��� ��ġ�� ���� ���� ����
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 rayOrigin = mainCamera.transform.position;
            Vector3 rayDirection = mainCamera.transform.forward;

            // ���� �׸���
            Gizmos.color = Color.red;  // ������ ���� ����
            Gizmos.DrawLine(rayOrigin, rayOrigin + rayDirection * interactionRange);

            // ���� ���� ���� ���� �׷� �ð������� ǥ��
            Gizmos.DrawSphere(rayOrigin + rayDirection * interactionRange, 0.1f);
        }
    }
}
