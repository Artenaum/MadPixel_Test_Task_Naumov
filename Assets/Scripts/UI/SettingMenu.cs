using System;
using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;

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

		[SerializeField] TMP_Text musicButtonText;
		[SerializeField] TMP_Text restartButtonText;
		[SerializeField] TMP_Text backButtonText;

        public override void Init(bool isOpen = false) {
            base.Init(isOpen);
            okButton.onClick.AddListener(CloseSettingMenu);
            closeButton.onClick.AddListener(CloseSettingMenu);

            restartButton.onClick.AddListener(RestartGame);
            backToMenuButton.onClick.AddListener(BackToMenu);
            musicButton.onClick.AddListener(ChangeMusic);

			musicOff.gameObject.SetActive(!YG2.saves.soundState);
			musicOn.gameObject.SetActive(YG2.saves.soundState);

			if (YG2.lang == "en") {
				musicButtonText.text = "Music";
				restartButtonText.text = "Restart";
				backButtonText.text = "Back to menu";
			} else if (YG2.lang == "ru") {
				musicButtonText.text = "Музыка";
				restartButtonText.text = "Заново";
				backButtonText.text = "Назад в меню";
			}
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
            if (musicOff.gameObject.activeSelf) MusicSwitcher(true);
            else MusicSwitcher(false);
        }

        private void MusicSwitcher(bool value) {
            musicOff.gameObject.SetActive(!value);
            musicOn.gameObject.SetActive(value);

			soundManager.SwitchSound(value);
			YG2.saves.soundState = value;
        }

    }
}