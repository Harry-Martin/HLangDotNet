namespace HLang
{
    public enum TokenType
    {
        IllegalToken,
        EOFToken,
        NumberToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
    }

    // Lexical Token
    public class Token
    {
        private readonly TokenType _type;
        private readonly int _lineNumber;
        private readonly int _characterNumber;
        private readonly string? _lexeme = null;

        // construct token without useful lexeme
        public Token(TokenType type, int lineNumber, int characterNumber)
        {
            _type = type;
            _lineNumber = lineNumber;
            _characterNumber = characterNumber;
        }

        public Token(TokenType type, int lineNumber, int characterNumber, string lexeme)
        {
            _type = type;
            _lineNumber = lineNumber;
            _characterNumber = characterNumber;
            _lexeme = lexeme;
        }

        public override string ToString()
        {
            if (_lexeme is null)
                return $"<{this.Type}>";

            return $"<{this.Type}, \"{this.Lexeme}\">";
        }

        public TokenType Type { get { return _type; } }
        public int LineNumber { get { return _lineNumber; } }
        public int CharacterNumber { get { return _characterNumber; } }
        public string? Lexeme { get { return _lexeme; } }
    }
}
