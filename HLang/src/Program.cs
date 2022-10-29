using System.Runtime.CompilerServices;

namespace HLang
{
    public class HLang
    {
        // Lex lines from standard input
        public static void Main(String[] args)
        {
            String? line = Console.ReadLine();

            // stop if we find 'q' in standard input
            while (line != "q" && line != null)
            {
                var lexer = new Lexer(line);
                while (true)
                {
                    var token = lexer.NextToken();

                    // if lexer generates illegal token, display error message
                    if (token.Type == TokenType.IllegalToken)
                    {
                        Console.WriteLine($"Illegal Token '{token.Lexeme}' at ({token.LineNumber}:{token.CharacterNumber})");
                        break;
                    }

                    Console.WriteLine(token);

                    // when lexer reaches end of file, stop lexing line
                    if (token.Type == TokenType.EOFToken)
                        break;
                }
                line = Console.ReadLine();
            }
        }

    }
}