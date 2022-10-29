

namespace HLang
{
    public class Lexer
    {

        private readonly string _source;
        private int _cursor = 0;
        private int _lineCount = 1;
        private int _columnCount = 0;
        public Lexer(string source)
        {
            _source = source;
        }
        
        // generates the next lexical token in the source
        public Token NextToken()
        {
            TokenType type = TokenType.IllegalToken;
            string? lexeme = null;

            // these functions define the rules for matching a lexical token.
            // the order of these functions is important,
            // later matches will override earlier matches.
            {
                ConsumeWhitespace();
                LexNumber(ref type, ref lexeme);
                LexSingleCharacter(ref type);
            }

            if (type == TokenType.IllegalToken)
                lexeme = GetCurrent().ToString();

            // consume current lexeme after successful match
            NextChar();

            if (lexeme == null)
                return CreateToken(type);

            return CreateToken(type, lexeme);
        }

        // point the cursor to the next character
        private void NextChar()
        {
            _columnCount++;
            _cursor++;
        }

        // return the next character without moving the cursor
        private char PeekNextChar()
        {
            if (_cursor < _source.Length - 1)
                return _source[_cursor + 1];

            return '\0';
        }

        // return the character at the cursor
        private char GetCurrent()
        {
            if (_cursor >= _source.Length)
                return '\0';

            return _source[_cursor];
        }

        // increment the linebreak counter and reset the column counter
        private void NextLine()
        {
            _columnCount = 0;
            _lineCount++;
        }

        // move the cursor to the next non-whitespace character
        private void ConsumeWhitespace()
        {
            while (true)
            {
                var current = GetCurrent();

                if (current != ' ' && current != '\n')
                    return;

                if (current == '\n') NextLine();

                NextChar();
            }
        }
        
        // generate token without useful lexeme
        private Token CreateToken(TokenType type)
        {
            return new Token(type, _lineCount, _columnCount);
        }

        // generate token
        private Token CreateToken(TokenType type, string lexeme)
        {
            return new Token(type, _lineCount, _columnCount, lexeme);
        }

        // match any single character lexemes
        private void LexSingleCharacter(ref TokenType type)
        {
            switch (GetCurrent())
            {
                case '+': type = TokenType.PlusToken; break;
                case '-': type = TokenType.MinusToken; break;
                case '*': type = TokenType.StarToken; break;
                case '/': type = TokenType.SlashToken; break;

                case '\0': type = TokenType.EOFToken; break;

                default: return;
            }
        }

        // match any number lexemes
        private void LexNumber(ref TokenType type, ref string? lexeme)
        {
            var current = GetCurrent();
            if (!char.IsDigit(current))
                return;

            int start = _cursor;
            int length = 0;

            while(true)
            {
                length++;
                if (!Char.IsDigit(PeekNextChar()))
                    break;

                NextChar();
            }

            if (length > 0) // successfully matched
            {
                lexeme = _source.Substring(start, length);
                type = TokenType.NumberToken;
            }
        }
    }
}
