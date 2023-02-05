using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaitForTime
{
    //Probably obsolete
    public static IEnumerator WaitForSec(float timeToWait)
    {
        bool isWaiting = true;

        while(isWaiting)
        {
            yield return new WaitForSeconds(timeToWait);
            isWaiting = false;
        }
    }
}
