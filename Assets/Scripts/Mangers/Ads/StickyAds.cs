using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class StickyAds : MonoBehaviour {

	private static StickyAds instance;

	public static StickyAds Instance {
		get { return instance; }
	}

	private void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
	}
}
