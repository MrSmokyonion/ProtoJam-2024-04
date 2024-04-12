using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StickAniamtionText : MonoBehaviour
{
    TextMeshProUGUI text;

    public bool moveMode = true;

    int beforeTime = 0;
    int currentTime = 0;
    float realTime = 0;
    float CurrentTime
    {
        get => realTime;
        set
        {
            realTime = value;
            if (moveMode)
            {
                currentTime = Mathf.RoundToInt(realTime);
                if (beforeTime != currentTime)
                {
                    if (currentTime == 3) currentTime = -1;
                    WobblyMove(currentTime);
                    beforeTime = currentTime;
                }
            }
            else
            {
                UpDownMove(realTime);
            }
        }
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
    }

    void UpDownMove(float time)
    {
        text.ForceMeshUpdate();
        var textInfo = text.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(time * 2f + 45.0f * i) , 0) * 10.0f;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            text.UpdateGeometry(meshInfo.mesh, i);
        }
    }

    /// <summary>
    /// 1초마다 뚝뚝 끊기는 움직임을 보이는 움직임
    /// </summary>
    /// <param name="a">-1 ~ 2사이의 값</param>
    void WobblyMove(int a)
    {
        text.ForceMeshUpdate();
        var textInfo = text.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                int temp = a + j + i;
                verts[charInfo.vertexIndex + j] = orig + new Vector3(temp % 2, (temp+1) % 2, 0) * 10.0f;
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            text.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
