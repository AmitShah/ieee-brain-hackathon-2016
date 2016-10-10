using UnityEngine;
using System.Collections;

public class LightIntensityChanger : MonoBehaviour {

    public Light myLight;
    public float targetIntesity;
    public float tweenDuration = 1;
    private PipeColorChanger ppc;

    // Use this for initialization
    void Awake () {

        targetIntesity = 2;
        myLight = gameObject.GetComponent<Light>();
    }

    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetNewIntesity(myLight.gameObject, 2,2);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetNewIntesity(myLight.gameObject, 0.5f, 2);
        }

    }

    public void SetNewIntesity(GameObject myObj, float newIntesity, float time)
    {
        Light myLight= myObj.GetComponent<Light>();
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("from", myLight.intensity);
        tweenParams.Add("to", newIntesity);
        tweenParams.Add("time", tweenDuration);
        tweenParams.Add("onupdate", "OnIntesityUpdated");

        iTween.ValueTo(gameObject, tweenParams);
    }

    private void OnIntesityUpdated(float f)
    {
        myLight.intensity = f;
    }
}
