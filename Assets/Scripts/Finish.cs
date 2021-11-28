using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _cap;

public void CloseFinish()
    {
        _cap.transform.position = new Vector3(0, 0, 0);
    }
}
