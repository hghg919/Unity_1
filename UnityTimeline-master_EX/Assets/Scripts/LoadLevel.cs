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
        // Resources 폴더에 저장한 오브젝트를 불러온다.
        string name = $"Level/Level_{m_level}";
        GameObject level = Resources.Load(name) as GameObject;
        // level 데이터가 null이라면 아래 코드를 실행하지 마세요.
        if (level != null)
            Instantiate(level);
    }
}
