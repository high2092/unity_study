using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    int gold;

    public int GetGold() {
        return gold;
    }

    public void Farming(int value) {
        gold += value;
        Debug.Log(gold);
    }
}
