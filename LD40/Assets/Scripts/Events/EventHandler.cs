using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    public BaseCrimeEvents baseCrimeEvents;
    public BaseGoodEvents baseGoodEvents;

	public void ChooseBaseEvent()
    {
        if (Random.Range(0, 100) <= 50)
        {
            baseCrimeEvents.PickEvent();
        }
        else
        {
            baseGoodEvents.PickEvent();
        }
    }
}
