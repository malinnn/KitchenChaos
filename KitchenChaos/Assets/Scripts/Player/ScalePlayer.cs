using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlayer : MonoBehaviour
{
    [SerializeField] private float scaleOffset = 0.3f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Period))
        {
            transform.localScale = new Vector3(
                transform.localScale.x + scaleOffset,
                transform.localScale.y + scaleOffset,
                transform.localScale.z + scaleOffset
            );
        }

        if(Input.GetKeyDown(KeyCode.Comma))
        {
            transform.localScale = new Vector3(
                transform.localScale.x - scaleOffset,
                transform.localScale.y - scaleOffset,
                transform.localScale.z - scaleOffset
            );
        }
    }
}
