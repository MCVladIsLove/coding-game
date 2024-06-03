using System.Collections.Generic;

namespace Assets.Scripts.CodeSuggestions
{
    public struct Suggestion
    {
        public List<Suggestion> suggestions;
        public string name;
        public SuggestionType type;

        public Suggestion(string name, List<Suggestion> suggestions, SuggestionType type)
        {
            this.name = name;
            this.suggestions = suggestions;
            this.type = type;
        }
    }
}