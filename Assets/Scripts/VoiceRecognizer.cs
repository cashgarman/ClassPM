using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System; //Refer to Functions as Actions
using System.Linq; //ToArray()
using UnityEngine.Windows.Speech;

public class VoiceRecognizer : MonoBehaviour
{
    private Dictionary<string, Action> m_keywordActions = new Dictionary<string, Action>();

    private KeywordRecognizer m_keywordRecognizer;

    void Start()
    {
        m_keywordActions.Add("Create cube", SpawnCube);
        m_keywordActions.Add("Ra Za Na Ba Do A", SpawnCube);

        m_keywordRecognizer = new KeywordRecognizer(m_keywordActions.Keys.ToArray());
        m_keywordRecognizer.OnPhraseRecognized += OnKeywordRecognized;
        m_keywordRecognizer.Start();
    }

    void OnKeywordRecognized(PhraseRecognizedEventArgs args)
    {
        m_keywordActions[args.text].Invoke();
    }

    public Transform m_spawnTransform;

    public GameObject m_prefabCube;
    void SpawnCube()
    {
        Instantiate(m_prefabCube, m_spawnTransform.position, m_spawnTransform.rotation);
    }
}
