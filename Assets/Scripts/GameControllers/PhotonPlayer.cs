﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject myAvatar;
    public GameObject prefab;
    public int spawn;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", prefab.name), 
                GameSetup.GS.spawnPoints[spawn].position, GameSetup.GS.spawnPoints[spawn].rotation, 0);
        }
    }
}
