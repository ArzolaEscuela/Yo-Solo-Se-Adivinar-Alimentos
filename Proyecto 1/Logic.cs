﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Windows;
using Microsoft.Win32;

namespace Proyecto_1
{
    public enum EDirection
    {
        No = 0,
        Yes = 1
    }

    [Serializable]
    public class Node
    {
        public List<EDirection> PathToNode { get; set; } = new List<EDirection>();
        public string Content { get; set; } = string.Empty;

        [JsonIgnore] public Node No { get; set; }
        [JsonIgnore] public Node Yes { get; set; }
        [JsonIgnore] private bool IsAnswer => No == null && Yes == null;
        [JsonIgnore] public bool IsQuestion => !IsAnswer;
    }

    public static class Logic
    {
        //------------------------------------------------------------------------------------//
        /*----------------------------------- FIELDS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        private static List<EDirection> _currentPath = new List<EDirection>();
        private static Node root;

        private static Node currentNode;
        private static Window currentWindow;

        //------------------------------------------------------------------------------------//
        /*---------------------------------- METHODS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        public static void Initialize()
        {
            List<Node> unorderedNodes = SaveManager.SavedData;
            root = unorderedNodes[0];

            int nodeCount = unorderedNodes.Count;
            for (int i = 1; i < nodeCount; i++)
            {
                Node nodeToCheck = unorderedNodes[i];
                Node previousNode = root;
                var path = nodeToCheck.PathToNode;

                while (path.Count > 1)
                {
                    EDirection nextDirection = path[0];
                    path.RemoveAt(0);
                    previousNode = nextDirection == EDirection.No ? previousNode.No : previousNode.Yes;
                }

                EDirection lastDirection = path[0];
                switch (lastDirection)
                {
                    case EDirection.No:
                        previousNode.No = nodeToCheck;
                        break;
                    case EDirection.Yes:
                        previousNode.Yes = nodeToCheck;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public static void StartNewRun(Window initialWindow)
        {
            _currentPath.Clear();
            currentNode = root;
            currentWindow = initialWindow;

            GenerateNodeView();
            initialWindow.Close();
        }

        private static void OnYesPressed()
        {
            if (currentNode.Yes == null)
            {
                // The answer was found!
                Helpers.CreateSingleButtonWindow(currentWindow, ProjectStrings.AnswerFound.Title,
                    ProjectStrings.AnswerFound.ButtonText, () => TitleScreen.StartGame(currentWindow),
                    ProjectStrings.AnswerFound.Subtitle, true);
                return;
            }

            currentNode = currentNode.Yes;
            GenerateNodeView();
        }

        private static void OnNoPressed()
        {
            if (currentNode.No == null)
            {
                // The answer was not found.
                ProcessAnswerNotFound_GetNewAnswer();
                return;
            }

            currentNode = currentNode.No;
            GenerateNodeView();
        }

        #region Process Answer Not Found

        private static void ProcessAnswerNotFound_GetNewAnswer()
        {
            currentWindow = Helpers.CreateTextCaptureWindow(currentWindow, ProjectStrings.AnswerNotFound_GetNewAnswer.Title,
                ProjectStrings.AnswerNotFound_GetNewAnswer.ButtonText, ProjectStrings.AnswerNotFound_GetNewAnswer.Placeholder,
                ProcessAnswerNotFound_GetNewQuestion, ProjectStrings.AnswerNotFound_GetNewAnswer.Subtitle);
        }

        private static void ProcessAnswerNotFound_GetNewQuestion(string newAnswer)
        {
            currentWindow = Helpers.CreateTextCaptureWindow(currentWindow, string.Format(ProjectStrings.AnswerNotFound_GetNewQuestion.NewQuestionTemplate, currentNode.Content, newAnswer),
                ProjectStrings.AnswerNotFound_GetNewQuestion.ButtonText, ProjectStrings.AnswerNotFound_GetNewQuestion.Placeholder,
                newQuestion => ProcessAnswerNotFound_GetYesNoQuestionAnswer(newAnswer, newQuestion), ProjectStrings.AnswerNotFound_GetNewQuestion.Subtitle);
        }

        private static void ProcessAnswerNotFound_GetYesNoQuestionAnswer(string newAnswer, string newQuestion)
        {
            currentWindow = Helpers.CreateYesNoWindow(currentWindow, newQuestion,
                ProjectStrings.Yes, ProjectStrings.No,
                () => ProcessAnswerNotFound_SaveRun(newAnswer, newQuestion, EDirection.Yes),
                () => ProcessAnswerNotFound_SaveRun(newAnswer, newQuestion, EDirection.No),
               string.Format(ProjectStrings.AnswerNotFound_GetYesNoQuestionAnswer.YesNoSubtitleTemplate, newAnswer));
        }

        private static void ProcessAnswerNotFound_SaveRun(string newAnswer, string newQuestion, EDirection newQuestionAnswer)
        {
            // Add Entry To Database
            Console.WriteLine(newAnswer);
            Console.WriteLine(newQuestion);
            Console.WriteLine(newQuestionAnswer);

            // Start Thank You Prompt
            currentWindow = Helpers.CreateSingleButtonWindow(currentWindow, ProjectStrings.ThankYou.Title, ProjectStrings.ThankYou.ButtonText,
                () => TitleScreen.StartGame(currentWindow));
        }

        #endregion Process Answer Not Found

        private static void GenerateNodeView()
        {
            if (currentNode.IsQuestion)
            {
                currentWindow = Helpers.CreateYesNoWindow(currentWindow, currentNode.Content, ProjectStrings.Yes, ProjectStrings.No, OnYesPressed, OnNoPressed);
                return;
            }

            currentWindow = Helpers.CreateYesNoWindow(currentWindow, string.Format(ProjectStrings.GuessScreen.GuessTempalte, currentNode.Content),
                ProjectStrings.Yes, ProjectStrings.No, OnYesPressed, OnNoPressed);
        }

    }
}