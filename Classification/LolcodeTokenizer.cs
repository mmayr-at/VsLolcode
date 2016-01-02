using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsLolcode.Classification
{
  enum TokenType
  {
    Keyword, Operator, StringLiteral, NumberLiteral, Identifier, LineComment, BlockComment, Undefined
  }
  struct Token
  {
    public int Start;
    public int End;
    public TokenType Type;

    public Token(int start, int end, TokenType type)
    {
      Start = start;
      End = end;
      Type = type;
    }
  }
  class LolcodeTokenizer
  {
    private readonly LolcodeScanner scanner;
    private readonly SnapshotSpan input;
    public LolcodeTokenizer(SnapshotSpan input)
    {
      this.input = input;
      int start = input.Span.Start;
      int end = input.Span.End;
      var text = input.Snapshot.GetText();
      int tmp = 0;
      if ((tmp = text.LastIndexOf("OBTW", start)) > 0 && text.LastIndexOf("TLDR", start) < tmp)
        start = tmp;

      int nextObtw = text.IndexOf("OBTW", end);
      if ((tmp = text.IndexOf("TLDR", end)) > 0 && (nextObtw > tmp || nextObtw == -1))
        end = tmp + 4;

      // we may need to extend the span to match multiline comments
      scanner = new LolcodeScanner(new Antlr4.Runtime.AntlrInputStream(input.Snapshot.GetText(new Span(start, end - start))));
    }

    public IList<Token> GetAllTokens()
    {
      IList<Token> result = new List<Token>();
      var tokens = scanner.GetAllTokens();
      foreach (var t in tokens)
      {
        TokenType tokenType = TokenType.Undefined;
        switch(t.Type)
        {
          case LolcodeScanner.HAI:
          case LolcodeScanner.KTHXBYE:
          case LolcodeScanner.VISIBLE:
          case LolcodeScanner.I_HAS_A:
          case LolcodeScanner.CAN_HAS:
          case LolcodeScanner.OF:
          case LolcodeScanner.AN:
          case LolcodeScanner.WIN:
          case LolcodeScanner.FAIL:
            tokenType = TokenType.Keyword;
            break;
          case LolcodeScanner.R:
          case LolcodeScanner.SUM:
          case LolcodeScanner.DIFF:
          case LolcodeScanner.PRODUKT:
          case LolcodeScanner.QUOSHUNT:
          case LolcodeScanner.EITHER:
          case LolcodeScanner.BOTH:
          case LolcodeScanner.WON:
          case LolcodeScanner.NOT:
            tokenType = TokenType.Operator;
            break;
          case LolcodeScanner.IDENTIFIER:
            tokenType = TokenType.Identifier;
            break;
          case LolcodeScanner.STRING_LITERAL:
            tokenType = TokenType.StringLiteral;
            break;
          case LolcodeScanner.INTEGER_LITERAL:
          case LolcodeScanner.DOUBLE_LITERAL:
            tokenType = TokenType.NumberLiteral;
            break;
          case LolcodeScanner.LINE_COMMENT:
            tokenType = TokenType.LineComment;
            break;
          //case LolcodeScanner.BLOCK_COMMENT:
          //  tokenType = TokenType.BlockComment;
          //  break;
          default:
            tokenType = TokenType.Undefined;
            break;
        }
        result.Add(new Token(t.StartIndex, t.StopIndex, tokenType));
      }
      return result;
    }


  }
}
