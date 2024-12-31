using System.Threading;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Model;
using Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionView : MonoBehaviour
{
    public LanguageEnum language = LanguageEnum.ENGLISH;
    public TextMeshProUGUI title;
    public TMP_Dropdown boosterSelection;
    public GameObject baseAvailableMugshot;
    public GameObject baseHiddenMugshot;
    public GameObject cardP1;
    public GameObject cardP2;
    public Button nextArrow;
    public Button prevArrow;
    public GameObject boosterSelectBackground;
    public GameObject icon1p;
    public GameObject icon2p;
    public GameObject selectBoosterTitle;
    public GameObject versus;
    public GameObject stageCard;
    public Button nextStageCard;
    public Button prevStageCard;
    public GameObject confirmPanel;
    public Button yesConfirmPanelButton;
    public Button noConfirmPanelButton;
    public TextMeshProUGUI confirmPanelTitle;
    public TextMeshProUGUI confirmPanelDesc;


    private CharacterSelectionService service = new();
    private List<Booster> boosters;
    private Booster selectedBooster;
    private List<Character> characters;
    private List<Character> userCharacters;
    private List<Stage> userStages;
    private List<Character> userCharactersByBooster;
    private List<List<Character>> allVisibleBoosterCharactersChunked;

    public List<GameObject> availableMugshots = new();
    public List<GameObject> hiddenMugshots = new();
    public bool p1TurnToSelect = true;
    public bool enableStageSelection = false;
    public int currentChunckListIndex = 0;
    private int totalChunks = 0;
    public int currentStageIndex = 0;

    void Awake()
    {
        boosters = service.FindBoosters();
        userCharacters = service.FindUserCharacters();
        characters = service.FindCharacters();
        userStages = service.FindUserStages();
    }

    void Start()
    {
        FormatTitle(CharacterSelectionI18N.CharSelectionTitle);
        FormatBoosterSelection();
        CreateUserCharacterMugshots(boosterSelection.value);

        nextArrow.onClick.AddListener(OnNextArrowClick);
        prevArrow.onClick.AddListener(OnPrevArrowClick);

        UpdateArrowButtons();

        UpdateSelectStage(currentStageIndex);

        stageCard.GetComponent<Button>().onClick.AddListener(ClickToSelectStage);

        yesConfirmPanelButton.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = CharacterSelectionI18N.YesButton(language);
        noConfirmPanelButton.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = CharacterSelectionI18N.NoButton(language);

        yesConfirmPanelButton.onClick.AddListener(ClickYesConfirmPanel);
        noConfirmPanelButton.onClick.AddListener(ClickNoConfirmPanel);

        nextStageCard.onClick.AddListener(OnStageNextArrowClick);
        prevStageCard.onClick.AddListener(OnStagePrevArrowClick);

        confirmPanelTitle.text = CharacterSelectionI18N.ConfirmPanelTitle(language);
        confirmPanelDesc.text = CharacterSelectionI18N.ConfirmPanelDesc(language);
    }

    private void ClickNoConfirmPanel()
    {
        confirmPanel.SetActive(false);
        foreach (Transform child in confirmPanel.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void ClickYesConfirmPanel()
    {
        SceneManager.LoadScene("VersusMatch");
    }

    private void ClickToSelectStage()
    {
        confirmPanel.SetActive(true);
        foreach (Transform child in confirmPanel.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        Debug.Log(MatchControllerStore.Instance.stageResourcePath);
        if (enableStageSelection)
        {
            ClearMugshots();
            FormatTitle(CharacterSelectionI18N.StageSelectionTitle);
            PrepareStageSelection();
            UpdateStageArrowsSelect();
        }
    }

    private void UpdateStageArrowsSelect()
    {
        nextStageCard.interactable = currentStageIndex + 1 < userStages.Count;
        prevStageCard.interactable = currentStageIndex > 0;
    }

    private void PrepareStageSelection()
    {
        boosterSelection.gameObject.SetActive(false);
        baseAvailableMugshot.gameObject.SetActive(false);
        baseHiddenMugshot.gameObject.SetActive(false);
        nextArrow.gameObject.SetActive(false);
        prevArrow.gameObject.SetActive(false);
        boosterSelectBackground.gameObject.SetActive(false);
        selectBoosterTitle.gameObject.SetActive(false);
        versus.gameObject.SetActive(false);

        stageCard.SetActive(true);
        nextStageCard.gameObject.SetActive(true);
        prevStageCard.gameObject.SetActive(true);
    }

    private void CreateUserCharacterMugshots(int index)
    {
        string selectedOption = boosterSelection.options[index].text;
        selectedBooster = boosters.Where(b => b.number + " - " + b.name == selectedOption).First();

        allVisibleBoosterCharactersChunked = characters.Where(character => character.boosterId == selectedBooster.id)
            .Select((character, index) => new { character, index })
            .GroupBy(x => x.index / 15)
            .Select(group => group.Select(x => x.character).ToList())
            .ToList();

        totalChunks = allVisibleBoosterCharactersChunked.Count;

        userCharactersByBooster = userCharacters.Where(character => character.boosterId == selectedBooster.id).ToList();

        RenderCurrentChunk();
    }

    private void FormatBoosterSelection()
    {
        boosterSelection.ClearOptions();
        boosterSelection.AddOptions(boosters.Select(b => b.number + " - " + b.name).ToList());
        boosterSelection.onValueChanged.AddListener(OnBoosterSelectionValueChanged);
    }

    void OnBoosterSelectionValueChanged(int index)
    {
        CreateUserCharacterMugshots(index);
    }

    private void FormatTitle(Func<LanguageEnum, string> funcI18N)
    {
        title.text = funcI18N(language);
        title.outlineColor = Color.black;
        title.outlineWidth = 0.5f;
        title.color = Color.white;

        Shadow shadow = title.gameObject.GetComponent<Shadow>();
        shadow = title.gameObject.AddComponent<Shadow>();

        shadow.effectColor = new Color(0, 0, 0, 0.5f);
        shadow.effectDistance = new Vector2(2f, -2f);
        shadow.useGraphicAlpha = true;
    }

    private void ClickToSelectChar(Button currentButton, string resourcePath)
    {
        if (p1TurnToSelect)
        {
            currentButton.transform.Find("1pSelect").gameObject.SetActive(true);
            cardP1.GetComponent<Image>().sprite = Resources.Load<Sprite>(resourcePath + "/" + "card"); //Obter o objeto com o nome da pasta e caminho completo
            p1TurnToSelect = false;
            MatchControllerStore.Instance.player1CharacterResourcePath = resourcePath;
        }
        else
        {
            currentButton.transform.Find("2pSelect").gameObject.SetActive(true);
            cardP2.GetComponent<Image>().sprite = Resources.Load<Sprite>(resourcePath + "/" + "card"); //Obter o objeto com o nome da pasta e caminho completo
            p1TurnToSelect = true;
            enableStageSelection = true;
            MatchControllerStore.Instance.player2CharacterResourcePath = resourcePath;
        }
    }

    void OnNextArrowClick()
    {
        if (currentChunckListIndex < totalChunks - 1)
        {
            currentChunckListIndex++;
            UpdateArrowButtons();
            RenderCurrentChunk();
        }
    }

    void OnPrevArrowClick()
    {
        if (currentChunckListIndex > 0)
        {
            currentChunckListIndex--;
            UpdateArrowButtons();
            RenderCurrentChunk();
        }
    }

    void OnStageNextArrowClick()
    {
        currentStageIndex++;
        UpdateSelectStage(currentStageIndex);
    }

    void OnStagePrevArrowClick()
    {
        currentStageIndex--;
        UpdateSelectStage(currentStageIndex);
    }

    void UpdateArrowButtons()
    {
        nextArrow.interactable = currentChunckListIndex < totalChunks - 1;
        prevArrow.interactable = currentChunckListIndex > 0;
    }

    void RenderCurrentChunk()
    {
        ClearMugshots();

        RectTransform rectTransformAvailableMugshot = baseAvailableMugshot.GetComponent<RectTransform>();
        RectTransform rectTransformHiddenMugshot = baseHiddenMugshot.GetComponent<RectTransform>();
        var currentChunk = allVisibleBoosterCharactersChunked[currentChunckListIndex];
        for (int i = 0; i < currentChunk.Count; i++)
        {
            var character = currentChunk[i];

            if (userCharactersByBooster.Any(userChar => userChar.id == character.id))
            {
                GameObject currentAvailableMugshots = Instantiate(baseAvailableMugshot.gameObject, baseAvailableMugshot.transform.parent);
                currentAvailableMugshots.SetActive(true);
                currentAvailableMugshots.GetComponent<Image>().sprite = Resources.Load<Sprite>(character.resourcePath + "/mugshot");
                currentAvailableMugshots.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * 125 + rectTransformAvailableMugshot.anchoredPosition.x, rectTransformAvailableMugshot.anchoredPosition.y);

                var currentButton = currentAvailableMugshots.GetComponent<Button>();
                currentButton.onClick.AddListener(() => ClickToSelectChar(currentButton, character.resourcePath));
                availableMugshots.Add(currentAvailableMugshots);
            }
            else
            {
                GameObject currentHiddenMugshot = Instantiate(baseHiddenMugshot.gameObject, baseHiddenMugshot.transform.parent);
                currentHiddenMugshot.SetActive(true);
                RectTransform rectTransform = currentHiddenMugshot.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(i * 125 + rectTransformHiddenMugshot.anchoredPosition.x, rectTransformHiddenMugshot.anchoredPosition.y);
                hiddenMugshots.Add(currentHiddenMugshot);
            }
        }

        UpdateArrowButtons();
    }

    private void ClearMugshots()
    {
        hiddenMugshots.ForEach(mugshot => Destroy(mugshot));
        hiddenMugshots.Clear();
        availableMugshots.ForEach(mugshot => Destroy(mugshot));
        availableMugshots.Clear();
    }

    private void UpdateSelectStage(int stageIndex)
    {
        var currentStage = userStages[stageIndex];
        stageCard.GetComponent<Image>().sprite = Resources.Load<Sprite>(currentStage.resourcePath + "/card");
        MatchControllerStore.Instance.stageResourcePath = currentStage.resourcePath;
    }
}
