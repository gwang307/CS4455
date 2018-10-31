using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterManager : MonoBehaviour {


    public SimpleCharacterControl[] ControllableCharacters = {}; 

    public ThirdPersonCamera thirdPersonCamera;

    public string CameraPositionMarkerName = "CamPos";


    protected int nextCharacterIndex = 0;


    protected void setCharacter(int charIndex) {
    
        if (charIndex < 0)
            charIndex = 0;

        if (charIndex >= ControllableCharacters.Length)
            charIndex = ControllableCharacters.Length - 1;

        ControllableCharacters[charIndex].enabled = true;

        thirdPersonCamera.desiredPose = ControllableCharacters[charIndex].transform.Find(CameraPositionMarkerName);

   
    }


	
	void Start () {
		
        if (thirdPersonCamera == null)
            Debug.LogError("camera must be set");

        setCharacter(nextCharacterIndex);

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.T))
        {
            Debug.Log("Character toggled");

        }
		
	}
}
