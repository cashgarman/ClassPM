using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton s_instance;

    private void Awake()
    {
        s_instance = this;
    }

    public Transform m_player;
}
