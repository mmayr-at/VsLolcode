//------------------------------------------------------------------------------
// <copyright file="LolcodeClassifier.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace VsLolcode.Classification
{
  /// <summary>
  /// Classifier that classifies all text as an instance of the "LolcodeClassifier" classification type.
  /// </summary>
  internal class LolcodeClassifier : IClassifier
  {
    /// <summary>
    /// Classification type.
    /// </summary>
    private readonly IClassificationType classificationKeyword;
    private readonly IClassificationType classificationUndefined;
    private readonly IClassificationType classificationIdentifier;
    private readonly IClassificationType classificationStringLiteral;
    private readonly IClassificationType classificationComment;
    /// <summary>
    /// Initializes a new instance of the <see cref="LolcodeClassifier"/> class.
    /// </summary>
    /// <param name="registry">Classification registry.</param>
    internal LolcodeClassifier(IClassificationTypeRegistryService registry)
    {
      this.classificationKeyword = registry.GetClassificationType("LolcodeClassifier.Keyword");
      this.classificationUndefined = registry.GetClassificationType("LolcodeClassifier.Undefined");
      this.classificationIdentifier = registry.GetClassificationType("LolcodeClassifier.Identifier");
      this.classificationStringLiteral = registry.GetClassificationType("LolcodeClassifier.StringLiteral");
      this.classificationComment = registry.GetClassificationType("LolcodeClassifier.Comment");
    }

    #region IClassifier

#pragma warning disable 67

    /// <summary>
    /// An event that occurs when the classification of a span of text has changed.
    /// </summary>
    /// <remarks>
    /// This event gets raised if a non-text change would affect the classification in some way,
    /// for example typing /* would cause the classification to change in C# without directly
    /// affecting the span.
    /// </remarks>
    public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

    /// <summary>
    /// Gets all the <see cref="ClassificationSpan"/> objects that intersect with the given range of text.
    /// </summary>
    /// <remarks>
    /// This method scans the given SnapshotSpan for potential matches for this classification.
    /// In this instance, it classifies everything and returns each span as a new ClassificationSpan.
    /// </remarks>
    /// <param name="span">The span currently being classified.</param>
    /// <returns>A list of ClassificationSpans that represent spans identified to be of this classification.</returns>
    public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
    {
      var result = new List<ClassificationSpan>();
      LolcodeTokenizer tokenizer = new LolcodeTokenizer(span);
      foreach (var item in tokenizer.GetAllTokens())
      {
        IClassificationType classificationType = null;
        switch (item.Type)
        {
          case TokenType.Keyword:
            classificationType = this.classificationKeyword;
            break;
          case TokenType.StringLiteral:
            classificationType = this.classificationStringLiteral;
            break;
          case TokenType.Identifier:
            classificationType = this.classificationIdentifier;
            break;
          case TokenType.LineComment:
          case TokenType.BlockComment:
            classificationType = this.classificationComment;
            break;
        }

        if (classificationType != null)
          result.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(span.Start + item.Start, item.End - item.Start + 1)), classificationType));
      }


      return result;
    }

    #endregion
  }
}
