using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformData
{
    public GameObject targetObject;
    public GameObject linkedObject;
    public bool isTrigger = false;
    public bool changePosition = false;  // ��ġ ���� ����
    public Vector3 position;             // ������ ��ġ ��

    public bool changeRotation = false;  // ȸ�� ���� ����
    public Vector3 rotation;             // ������ ȸ�� �� (Euler Angles)

    public bool changeScale = false;     // ������ ���� ����
    public Vector3 scale;                // ������ ������ ��

    public float lerpSpeed = 1.0f;

    public Vector3 originalPosition;   // ���� ��ġ
    public Quaternion originalRotation; // ���� ȸ��
    public Vector3 originalScale;       // ���� ������
    private bool hasStoredOriginal = false;

    // ���� Ʈ������ ���� ����
    public void StoreOriginalTransform()
    {
        if (!hasStoredOriginal && targetObject != null)
        {
            originalPosition = targetObject.transform.position;
            originalRotation = targetObject.transform.rotation;
            originalScale = targetObject.transform.localScale;
            hasStoredOriginal = true;
        }
    }
}

public class GameObjectController : MonoBehaviour
{
    public List<TransformData> objectsToControl; // ������ ������Ʈ ����Ʈ

    void Update()
    {
        foreach (var data in objectsToControl)
        {
            if (data.targetObject != null)
            {
                data.StoreOriginalTransform();
                ApplyTransform(data);
            }
        }
    }

    private void ApplyTransform(TransformData data)
    {
        Transform targetTransform = data.targetObject.transform;

        if (data.isTrigger)
        {
            // ��ġ ���� (Lerp ���)
            if (data.changePosition)
            {
                targetTransform.position = Vector3.Lerp(targetTransform.position, data.position, data.lerpSpeed * Time.deltaTime);
            }

            // ȸ�� ���� (Lerp ���)
            if (data.changeRotation)
            {
                Quaternion targetRotation = Quaternion.Euler(data.rotation);
                targetTransform.rotation = Quaternion.Lerp(targetTransform.rotation, targetRotation, data.lerpSpeed * Time.deltaTime);
            }

            // ������ ���� (Lerp ���)
            if (data.changeScale)
            {
                targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, data.scale, data.lerpSpeed * Time.deltaTime);
            }
        }
        else
        {
            // Ʈ���Ű� ������ �� ���� ���·� �ǵ��ư����� Lerp ����
            targetTransform.position = Vector3.Lerp(targetTransform.position, data.originalPosition, data.lerpSpeed * Time.deltaTime);
            targetTransform.rotation = Quaternion.Lerp(targetTransform.rotation, data.originalRotation, data.lerpSpeed * Time.deltaTime);
            targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, data.originalScale, data.lerpSpeed * Time.deltaTime);
        }
    }
}
