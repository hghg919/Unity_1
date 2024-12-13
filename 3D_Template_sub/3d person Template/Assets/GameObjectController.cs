using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformData
{
    public GameObject targetObject;
    public GameObject linkedObject;
    public bool isTrigger = false;
    public bool changePosition = false;  // 위치 변경 여부
    public Vector3 position;             // 변경할 위치 값

    public bool changeRotation = false;  // 회전 변경 여부
    public Vector3 rotation;             // 변경할 회전 값 (Euler Angles)

    public bool changeScale = false;     // 스케일 변경 여부
    public Vector3 scale;                // 변경할 스케일 값

    public float lerpSpeed = 1.0f;

    public Vector3 originalPosition;   // 원래 위치
    public Quaternion originalRotation; // 원래 회전
    public Vector3 originalScale;       // 원래 스케일
    private bool hasStoredOriginal = false;

    // 원래 트랜스폼 값을 저장
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
    public List<TransformData> objectsToControl; // 제어할 오브젝트 리스트

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
            // 위치 변경 (Lerp 사용)
            if (data.changePosition)
            {
                targetTransform.position = Vector3.Lerp(targetTransform.position, data.position, data.lerpSpeed * Time.deltaTime);
            }

            // 회전 변경 (Lerp 사용)
            if (data.changeRotation)
            {
                Quaternion targetRotation = Quaternion.Euler(data.rotation);
                targetTransform.rotation = Quaternion.Lerp(targetTransform.rotation, targetRotation, data.lerpSpeed * Time.deltaTime);
            }

            // 스케일 변경 (Lerp 사용)
            if (data.changeScale)
            {
                targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, data.scale, data.lerpSpeed * Time.deltaTime);
            }
        }
        else
        {
            // 트리거가 꺼졌을 때 원래 상태로 되돌아가도록 Lerp 적용
            targetTransform.position = Vector3.Lerp(targetTransform.position, data.originalPosition, data.lerpSpeed * Time.deltaTime);
            targetTransform.rotation = Quaternion.Lerp(targetTransform.rotation, data.originalRotation, data.lerpSpeed * Time.deltaTime);
            targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, data.originalScale, data.lerpSpeed * Time.deltaTime);
        }
    }
}
