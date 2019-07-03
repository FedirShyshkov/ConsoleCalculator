namespace ConsoleCalculatorLibrary.Tokens
{
    struct LexemaNode
    {
        readonly public Lexema LexicalElement;
        readonly public double value;

        public LexemaNode(Lexema lex)
        {
            LexicalElement = lex;
            value = 0;
        }

        public LexemaNode(double _value)
        {
            LexicalElement = Lexema.Number;
            value = _value;
        }
    }
}
