using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlayer : MonoBehaviour
{
    [SerializeField] private float scaleOffset = 0.3f;
    [SerializeField] private float deformOffset = 0.15f;

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

        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }

        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            transform.localScale += new Vector3(deformOffset, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            transform.localScale -= new Vector3(deformOffset, 0, 0);
        }
    }
}
