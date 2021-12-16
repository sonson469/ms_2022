using Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private EffectPool[] effectPools;

    // Start is called before the first frame update

    /// <summary>
    /// エフェクト再生
    /// </summary>
    /// <param name="indexNum"></param>
    public void PlayEffect(int indexNum)
    {
        effectPools[indexNum].EffectPlay(new Vector3(0.0f, 1.0f, 0.0f));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Create Particles"))
        {
            effectPools[0].EffectPlay(new Vector3(0.0f, 1.0f, 0.0f));

        }
    }

    private void Update()
    {
    }
}
