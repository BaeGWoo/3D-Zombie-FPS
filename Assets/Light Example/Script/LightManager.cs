using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] bool condition = false;
    [SerializeField] GameObject[] lightEffect;

   public void LigthSetting(int number)
    {
        condition = !condition;
        lightEffect[number].SetActive(condition);

    }
}
