using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    [SerializeField] GameObject currentCube;
    [SerializeField] GameObject lastCube;
    public int level;
    [SerializeField] bool done;
    [SerializeField] PartiSystem partiSystem;
    [SerializeField] AudioPlay brickSound;

    //End
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject end;

    void Start()
    {
        newBlock();
    }

    private void newBlock()
    {
        if (lastCube!= null)
        {
            currentCube.transform.position = new Vector3(Mathf.Round(currentCube.transform.position.x), currentCube.transform.position.y, Mathf.Round(currentCube.transform.position.z));
            currentCube.transform.localScale = new Vector3(lastCube.transform.localScale.x - Mathf.Abs(currentCube.transform.position.x - lastCube.transform.position.x),
                                                           lastCube.transform.localScale.y,
                                                           lastCube.transform.localScale.z - Mathf.Abs(currentCube.transform.position.z - lastCube.transform.position.z));

            currentCube.transform.position = Vector3.Lerp(currentCube.transform.position, lastCube.transform.position, 0.5f) + Vector3.up * 5f;
            if(currentCube.transform.localScale.x <= 0f || currentCube.transform.localScale.z <= 0f)
            {
                done = true;
                end.SetActive(true);
                text.gameObject.SetActive(true);
                text.text = "Your Score: " + level;
            }
        }
        lastCube = currentCube;
        currentCube = Instantiate(lastCube);
        currentCube.name = level + "";
        currentCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((level / 100f) % 1f, 1f, 1f));
        level++;
        Camera.main.transform.position = currentCube.transform.position + new Vector3(100, 100, 100f);
        Camera.main.transform.LookAt(currentCube.transform.position);
    }

    void Update()
    {
        if(done) return;

        var time = Mathf.Abs(Time.realtimeSinceStartup % 2f - 1f);

        var pos1 = lastCube.transform.position + Vector3.up * 10f; 
        var pos2 = pos1 + ((level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;

        if(level % 2 == 0)
        {
            currentCube.transform.position = Vector3.Lerp(pos2, pos1, time);
        }
        else
        {
            currentCube.transform.position = Vector3.Lerp(pos1, pos2, time);
        }

        if(Input.GetMouseButtonDown(0))
        {
            newBlock();
            partiSystem.ParticleStuff();
            brickSound.PlayRandomClip();

        }
    }
}
