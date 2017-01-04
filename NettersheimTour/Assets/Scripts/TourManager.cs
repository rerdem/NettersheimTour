using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TourManager : MonoBehaviour {

	public static TourManager instance = null;

	public GameObject startPopup;

	[SerializeField] private Text testLabelText;

	string qrString = "";

	void Awake () {
		if (instance == null) instance = this;
		else if (instance != null) Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		startPopup.SetActive(true);

		AndroidNFCReader.enableBackgroundScan ();
		AndroidNFCReader.ScanNFC (gameObject.name, "OnFinishScan");

	}
	
	// Update is called once per frame
	void Update () {
		if (qrString == "tag1") {
			SceneManager.LoadScene ("location1");
		}
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





	



