using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Menu {
    public class MenuUIManager :MonoBehaviour {

        public MenuManager menuManager;

        [SerializeField] Button playGameButton;
		[SerializeField] Button languageIndicator;
		[SerializeField] TMP_Text languageIndicatorText;
		[SerializeField] TMP_Text gameDescriptionText;
		[SerializeField] TMP_Text playButtonText;

        public void Init() {
            playGameButton.onClick.AddListener(PlayGame);
			languageIndicator.onClick.AddListener(SwitchLanguage);

			YG2.onSwitchLang += ChangeMenuLanguage;
			YG2.SwitchLanguage(YG2.lang);
			Debug.Log(YG2.lang);
        }

        private void PlayGame() => menuManager.PlayGame();

		private void SwitchLanguage() {
			if (YG2.lang == "en") {
				YG2.SwitchLanguage("ru");
			} else if (YG2.lang == "ru") {
				YG2.SwitchLanguage("en");
			}
		}

		private void ChangeMenuLanguage(string lang) {
			if (YG2.lang == "ru") {
				languageIndicatorText.text = "EN";
				gameDescriptionText.text = "CHAIN CUBE это игра, в которой нужно выкидывать пронумерованные кубы на доску с другими кубами. Если у кубов одинаковый цвет и номер, они соединяются и число удваивается. Главное правило состоит в том, чтобы запущенный куб не остановился перед линией.";
				playButtonText.text = "ИГРАТЬ";
				Debug.Log(YG2.lang);
			} else if (YG2.lang == "en") {
				languageIndicatorText.text = "RU";
				gameDescriptionText.text = "CHAIN CUBE is a game where you roll numbered cubes onto a board with other cubes. If the cubes have the same color and number, they merge, and the number doubles. The key rule is that your cube must not stop before the line.";
				playButtonText.text = "PLAY";
				Debug.Log(YG2.lang);
			}
		}

		
    }
}