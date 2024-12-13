using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public int m_level = 0;
    // Start is called before the first frame update

    void Start()
    {
        LoadMap();
    }

    public void LoadMap()
    {
        // Resources ������ ������ ������Ʈ�� �ҷ��´�.
        string name = $"Level/Level_{m_level}";
        GameObject level = Resources.Load(name) as GameObject;
        // level �����Ͱ� null�̶�� �Ʒ� �ڵ带 �������� ������.
        if (level != null)
            Instantiate(level);
    }
}
