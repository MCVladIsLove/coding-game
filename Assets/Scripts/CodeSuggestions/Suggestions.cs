using Assets.Scripts.LuaLexing;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.CodeSuggestions
{
    public class Suggestions // rename
    {
        private Suggestion _root;

        public Suggestions(List<Suggestion> baseSuggestions)
        {
            _root = new Suggestion("", baseSuggestions, SuggestionType.Common);
        }

        public void AddSuggestion()
        {

        }

        private bool TryGetTypedPart(List<Token> tokenizedText, int currentTokenIndex, out string res)
        {
            res = "";
            switch (tokenizedText[currentTokenIndex].type)
            {
                case TokenType.Whitespace:
                    res = "";
                    return true;
                case TokenType.Operator:
                    if (tokenizedText[currentTokenIndex].text == ".")
                    {
                        res = "";
                        return true;
                    }
                    else
                        return true; // was false
                case TokenType.Identifier:
                    res = tokenizedText[currentTokenIndex].text;
                    return true;
                default:
                    return false;
            }
        }

        private bool TryGetPreviousIdentifier(List<Token> tokenizedText, int currentTokenIndex, out int tokenIndex)
        {
            tokenIndex = currentTokenIndex;

            bool isDotFound = false;

            while (currentTokenIndex >= 0)
                switch (tokenizedText[currentTokenIndex].type)
                {
                    case TokenType.Whitespace:
                        currentTokenIndex--;
                        break;
                    case TokenType.Operator: // functions track '(' and ')' symbols
                        if (tokenizedText[currentTokenIndex].text != ".")
                            return false;
                        if (isDotFound)
                            return false;

                        isDotFound = true;
                        currentTokenIndex--;
                        break;
                    case TokenType.Identifier: 
                        if (!isDotFound)
                            return false;

                        tokenIndex = currentTokenIndex;
                        return true;
                    default:
                        return false;
                }

            return false;
        }

        private bool TryFindSuggestionWithName(string suggestionName, Suggestion where, out Suggestion resultSuggestion)
        {
            resultSuggestion = new Suggestion();

            if (where.suggestions == null)
                return false;

            foreach (Suggestion suggestion in where.suggestions)
                if (suggestion.name == suggestionName)
                {
                    resultSuggestion = suggestion;
                    return true;
                }

            return false;
        }

        private List<Suggestion> GetClosestSuggestions(string typedPart, Suggestion lastPathPart)
        {
            if (lastPathPart.suggestions == null)
                return null;

            List<Suggestion> matchingSuggestions = lastPathPart.suggestions.ToList();
            int j;
            for (int i = 0; i < typedPart.Length; i++)
            {
                j = matchingSuggestions.Count - 1;
                while (j >= 0)
                {
                    if (i >= matchingSuggestions[j].name.Length || typedPart[i] != matchingSuggestions[j].name[i])
                        matchingSuggestions.RemoveAt(j);
                    j--;
                }
            }

            return matchingSuggestions;
        }

        public List<Suggestion> GetSuggestions(List<Token> tokenizedText, int positionInText)
        {
            if (tokenizedText.Count == 0)
                return _root.suggestions;

            int currentTokenIndex = 0;
            while (currentTokenIndex < tokenizedText.Count)
            {
                if (tokenizedText[currentTokenIndex].position > positionInText)
                {
                    currentTokenIndex -= 1;
                    break;
                }
                currentTokenIndex++;
            }
            if (currentTokenIndex == tokenizedText.Count)
                currentTokenIndex = tokenizedText.Count - 1;

            List<string> fullPath = new List<string>();

            string typedPart;
            if (!TryGetTypedPart(tokenizedText, currentTokenIndex, out typedPart))
                return null;

            fullPath.Add(typedPart);

            if (tokenizedText[currentTokenIndex].text != ".")
                currentTokenIndex--;

            while (TryGetPreviousIdentifier(tokenizedText, currentTokenIndex, out int foundTokenIndex))
            {
                currentTokenIndex = foundTokenIndex;
                fullPath.Insert(0, tokenizedText[currentTokenIndex].text);
                currentTokenIndex--;
            }

            Suggestion lastPathPart = _root;
            for (int i = 0; i < fullPath.Count - 1; i++)
                if (!TryFindSuggestionWithName(fullPath[i], lastPathPart, out lastPathPart))
                    return null;

            return GetClosestSuggestions(typedPart, lastPathPart);
        }
    }
}