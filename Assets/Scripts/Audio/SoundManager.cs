using System;
using UnityEngine;

namespace Game.Audio {
	public class SoundManager : MonoBehaviour {

		private static SoundManager instance;
		private AudioSwitcher audioSwitcher;

		public static SoundManager Instance {
			get { return instance; }
		}

		private void Awake() {
			if (instance != null && instance != this) {
				Destroy(this.gameObject);
				return;
			} else {
				instance = this;
			}

			audioSwitcher = GetComponent<AudioSwitcher>();
			audioSwitcher.SwitchVolume(Convert.ToBoolean(PlayerPrefs.GetInt("soundState", 1)));

			DontDestroyOnLoad(this.gameObject);
		}

		public void SwitchSound(bool value) {
			audioSwitcher.SwitchVolume(value);
		}
	}
}
