using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    [Header("�ؽ�Ʈ �ִϸ��̼�")]
    public TextMeshProUGUI dialogue;
    private string currentText;
    public float typeSpeed = 0.1f;

    public void TypeAnimation()
    {
        currentText = dialogue.text;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        dialogue.text = "";

        foreach(char letter in currentText)
        {
            dialogue.text += letter;
            // ��� �ð��� ��ٸ��� �ٽ� �����ϼ���.
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    IEnumerator StartExample()
    {
        dialogue.text = "";
        dialogue.text = "3";
        yield return new WaitForSeconds(1);
        dialogue.text = "2";
        yield return new WaitForSeconds(1);
        dialogue.text = "1";
        yield return new WaitForSeconds(1);
        dialogue.text = "START";
    }
}

