﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TourManager : MonoBehaviour {

//	public static TourManager instance = null;

	public GameObject stationPopup;
//	public GameObject stationPopupCancelButton;
	public GameObject stationPopupStartButton;

	public GameObject[] popups;
	public GameObject[] archMarker;
	public GameObject[] geoMarker;

	[SerializeField] private Text testLabelText;
	[SerializeField] private Text stationPopupText;

	string qrString = "";

	private string nextScene;

//	void Awake () {
//		if (instance == null) instance = this;
//		else if (instance != null) Destroy(gameObject);
//		DontDestroyOnLoad(gameObject);
//	}

	// Use this for initialization
	void Start () {
		AndroidNFCReader.enableBackgroundScan ();
		AndroidNFCReader.ScanNFC (gameObject.name, "OnFinishScan");

		nextScene = "mainScreen";
	}
	
	// Update is called once per frame
	void Update () {
		//		if (qrString == "tag1") {
		//			SceneManager.LoadScene ("location1");
		//		}
		if (qrString == "start") {
//			nextScene = "location1";
			showPopup (1);
		}
		if (qrString == "eisen") {
			nextScene = "location1";
			showPopup (3);
			GameManager.instance.progress++;
		}
		if (qrString == "kakus") {
			nextScene = "location1";
			GameManager.instance.progress++;
			showPopup (5);
		}
		if (qrString == "hausFoss") {
			nextScene = "location1";
			GameManager.instance.progress++;
			showPopup (7);
		}
		if (qrString == "korallen") {
			nextScene = "location1";
			GameManager.instance.progress++;
			showPopup (9);
		}
		if (qrString == "ziel") {
			//			nextScene = "location1";
			if (GameManager.instance.progress>=4)
				showPopup (13);
			else showPopup (11);
		}
	}

	void showPopup(int id) {
		popups [id].SetActive (true);
		popups [id+1].SetActive (true);
	}

//	void showPopup() {
//		if (nextScene == "location1") {
//			stationPopupText.text = "Dies ist der Info-Text zu Station 1";
//		}
//		else {
//			stationPopupText.text = "Kein Info-Text gefunden.";
//		}
//		stationPopup.SetActive (true);
////		stationPopupCancelButton.SetActive (true);
////		stationPopupCancelButton.GetComponent<Button> ().interactable = true;
//		stationPopupStartButton.SetActive (true);
//		stationPopupStartButton.GetComponent<Button> ().interactable = true;
//	}

//	public void hidePopup() {
//		stationPopup.SetActive (false);
//		stationPopupCancelButton.SetActive (false);
//		stationPopupCancelButton.GetComponent<Button> ().interactable = false;
//		stationPopupStartButton.SetActive (false);
//		stationPopupStartButton.GetComponent<Button> ().interactable = false;
//	}

//	void OnLevelWasLoaded(int level) {
//		startPopup = GameObject.Find ("startPopup");
//		stationPopup = GameObject.Find ("stationPopup");
//		stationPopupCancelButton = GameObject.Find ("stationPopupCancelButton");
//		stationPopupStartButton = GameObject.Find ("stationPopupStartButton");
//
//		testLabelText = GameObject.Find ("testLabel").GetComponent<Text> ();
//		stationPopupText = GameObject.Find ("stationPopupText").GetComponent<Text> ();
//	}

	public void toggleOptionPanel() {
		popups[0].SetActive(!popups[0].activeSelf);
	}

	public void toggleArchMarkers() {
//		Debug.Log ("toggle:");
		for (int i = 0; i < archMarker.Length; i++) {
//			Debug.Log (archMarker[i].activeSelf);
			archMarker[i].SetActive (!archMarker[i].activeSelf);
//			Debug.Log (archMarker[i].activeSelf);
		}
	}

	public void toggleGeoMarkers() {
//		Debug.Log ("toggle:");
		for (int i = 0; i < geoMarker.Length; i++) {
//			Debug.Log (geoMarker[i].activeSelf);
			geoMarker[i].SetActive (!geoMarker[i].activeSelf);
//			Debug.Log (geoMarker[i].activeSelf);
		}
	}

	public void loadLevel() {
		SceneManager.LoadScene (nextScene);
	}


	// NFC callback
	void OnFinishScan(string result) {
		if (result == AndroidNFCReader.CANCELLED) {
			// The user has canceled the scan (back button)
		} else if (result == AndroidNFCReader.ERROR) {
			// There was an error reading the NFC tag
		} else if (result == AndroidNFCReader.NO_HARDWARE) {
			// No NFC hardware available
		}
		// result contains the NFC tag text content
		qrString = getToyxFromUrl (result);
//		Debug.Log(result);
		testLabelText.text = qrString;
	}

	// Extract toyxId from url
	string getToyxFromUrl (string url)
	{		
		int index = url.LastIndexOf ('/') + 1;

		if (url.Length > index) {
			return url.Substring (index);		
		} 

		return url;
	}

}





	



