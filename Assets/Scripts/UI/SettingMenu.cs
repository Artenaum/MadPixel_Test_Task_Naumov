using System;
using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using UnityEngine;
using UnityEngine.UI;
namespace Game.UI {
    public class SettingMenu :MenuWindow {

        [SerializeField] InGameUIManager inGameUIManager;
		[SerializeField] SoundManager soundManager;

      
        [SerializeField] Button restartButton;
        [SerializeField] Button backToMenuButton;


        [SerializeField] Button okButton;
        [SerializeField] Button closeButton;
        [Header("music")]
        [SerializeField] Button musicButton;
        [SerializeField] Image musicOff;
        [SerializeField] Image musicOn;
        public override void Init(bool isOpen = false) {
            base.Init(isOpen);
            okButton.onClick.AddListener(CloseSettingMenu);
            closeButton.onClick.AddListener(CloseSettingMenu);

            restartButton.onClick.AddListener(RestartGame);
            backToMenuButton.onClick.AddListener(BackToMenu);
            musicButton.onClick.AddListener(ChangeMusic);

            //TODO SAVE Music Value
            musicOff.gameObject.SetActive(Convert.ToBoolean(PlayerPrefs.GetInt("soundState", 1)));
            musicOn.gameObject.SetActive(!Convert.ToBoolean(PlayerPrefs.GetInt("soundState", 0)));
        }

		private void Awake() {
			if (!soundManager) {
				soundManager = FindObjectOfType<SoundManager>();
			}
		}

        private void CloseSettingMenu() => inGameUIManager.CloseSetting();
        private void RestartGame() => inGameUIManager.inGameManager.RestartGame();
        private void BackToMenu() => inGameUIManager.inGameManager.BackToMenu();
        private void ChangeMusic() {
            if (musicOff.gameObject.activeSelf) MusicSwitcher(false);
            else MusicSwitcher(true);
        }

        private void MusicSwitcher(bool value) {
            musicOff.gameObject.SetActive(value);
            musicOn.gameObject.SetActive(!value);

            //inGameUIManager.inGameManager.audioSwitcher.SwitchVolume(value);
			soundManager.SwitchSound(value);
			PlayerPrefs.SetInt("soundState", Convert.ToInt32(value));
        }

    }
}