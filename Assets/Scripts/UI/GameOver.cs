using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;
namespace Game.UI {
    public class GameOver :MenuWindow {
        [SerializeField] InGameUIManager inGameUIManager;

        [SerializeField] Button restartButton;
        [SerializeField] Button backToMenuButton;

		[SerializeField] TMP_Text gameOverText;
		[SerializeField] TMP_Text restartButtonText;
		[SerializeField] TMP_Text backButtonText;

        public AudioSource gameOverAudio;

        public override void Init(bool isOpen = false) {
            base.Init(isOpen);
            restartButton.onClick.AddListener(RestartGame);
            backToMenuButton.onClick.AddListener(BackToMenu);

			if (YG2.lang == "en") {
				gameOverText.text = "GAME OVER";
				restartButtonText.text = "Restart";
				backButtonText.text = "Back to menu";
			} else if (YG2.lang == "ru") {
				gameOverText.text = "ИГРА ОКОНЧЕНА";
				restartButtonText.text = "Заново";
				backButtonText.text = "Назад в меню";
			}
        }

        private void RestartGame() => inGameUIManager.inGameManager.RestartGame();
        private void BackToMenu() => inGameUIManager.inGameManager.BackToMenu();
    }
}