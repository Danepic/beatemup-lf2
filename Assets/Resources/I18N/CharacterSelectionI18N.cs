using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;

public class CharacterSelectionI18N
{
    public static string CharSelectionTitle(LanguageEnum language)
    {
        switch (language)
        {
            case LanguageEnum.BRASIL:
                return "Seleção de Personagem";

            case LanguageEnum.ENGLISH:
                return "Character Selection";

            case LanguageEnum.ESPAÑOL:
                return "Selección de Personajes";

            default:
                return "Language not supported.";
        }
    }

    public static string StageSelectionTitle(LanguageEnum language)
    {
        switch (language)
        {
            case LanguageEnum.BRASIL:
                return "Seleção de Fases";

            case LanguageEnum.ENGLISH:
                return "Stage Selection";

            case LanguageEnum.ESPAÑOL:
                return "Selección de Escenario";

            default:
                return "Language not supported.";
        }
    }

    public static string ConfirmPanelTitle(LanguageEnum language)
    {
        switch (language)
        {
            case LanguageEnum.BRASIL:
                return "Pronto?";

            case LanguageEnum.ENGLISH:
                return "Ready?";

            case LanguageEnum.ESPAÑOL:
                return "¿Listo?";

            default:
                return "Language not supported.";
        }
    }

    public static string ConfirmPanelDesc(LanguageEnum language)
    {
        switch (language)
        {
            case LanguageEnum.BRASIL:
                return "A batalha está prestes a começar. Continuar?";

            case LanguageEnum.ENGLISH:
                return "The battle is about to start. Proceed?";

            case LanguageEnum.ESPAÑOL:
                return "La batalla está a punto de comenzar. ¿Proceder?";

            default:
                return "Language not supported.";
        }
    }

    public static string YesButton(LanguageEnum language)
    {
        switch (language)
        {
            case LanguageEnum.BRASIL:
                return "Sim";

            case LanguageEnum.ENGLISH:
                return "Yes";

            case LanguageEnum.ESPAÑOL:
                return "Sí";

            default:
                return "Language not supported.";
        }
    }

    public static string NoButton(LanguageEnum language)
    {
        switch (language)
        {
            case LanguageEnum.BRASIL:
                return "Não";

            case LanguageEnum.ENGLISH:
                return "No";

            case LanguageEnum.ESPAÑOL:
                return "No";

            default:
                return "Language not supported.";
        }
    }
}