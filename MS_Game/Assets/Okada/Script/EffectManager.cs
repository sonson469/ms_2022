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
    public void PlayEffect(int indexNum,Vector3 position)
    {
        effectPools[indexNum].EffectPlay(position);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Create Particles"))
        {
            effectPools[1].EffectPlay(new Vector3(0.0f, 1.0f, 0.0f));

        }
    }
}
