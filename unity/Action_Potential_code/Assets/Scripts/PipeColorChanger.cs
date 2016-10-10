using UnityEngine;
using System.Collections;

public class PipeColorChanger : MonoBehaviour {

        GameObject myObject;
        Material myMaterial;   
        float tweenDuration = 2;
        Color myColor;

    void Awake() {

//        myMaterial = gameObject.GetComponent<Renderer>().material;
        myObject = gameObject;
    }

    void Start() {
        SpecialEffect();    
    }
    void Update() {

        if (Input.GetKeyDown(KeyCode.G))
        {
            Color c = new Color(0.8f, 1f, 0.31f);
            SetNewColor(c, 2);

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Color c = new Color(0.26f, 0.76f, 0.8f);
            SetNewColor(c, 2);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Color c = new Color(0.8f, 0.15f, 0.24f);
            SetNewColor(c, 2);
            
        }

       
         
        
        
        
    }
  
    public void SetNewColor(Color newColor, float time)
    {   
        Color myColor = gameObject.GetComponent<Renderer>().material.color;
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("from", myColor);
        tweenParams.Add("to", newColor);
        tweenParams.Add("time", time);
        tweenParams.Add("onupdate", "OnColorUpdated");
     
        
        iTween.ValueTo(gameObject, tweenParams);                  
    }

    private void OnColorUpdated(Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    private void SpecialEffect() {

        //gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        Color fromColor = gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor");
        Color toColor = new Color(0.6f, 0.6f, 0.6f);
   //     Color myColor = gameObject.GetComponent<Renderer>().material.color;
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("from", fromColor);
        tweenParams.Add("to", toColor);
        tweenParams.Add("time", 1f);
        tweenParams.Add("easetype", "easeInCubic");
        tweenParams.Add("onupdate", "OnEmissionUpdated");
        tweenParams.Add("looptype", "pingPong ");

        iTween.ValueTo(gameObject, tweenParams);

    }
    private void OnEmissionUpdated(Color color)
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
    }
    






}
