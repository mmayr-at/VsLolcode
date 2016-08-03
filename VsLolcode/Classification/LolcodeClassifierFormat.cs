//------------------------------------------------------------------------------
// <copyright file="LolcodeClassifierFormat.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VsLolcode.Classification
{
  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = "LolcodeClassifier.Undefined")]
  [Name("LolcodeClassifier.Undefined")]
  [UserVisible(true)] // This should be visible to the end user
  [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
  internal sealed class LolcodeClassifierFormatUndefined : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LolcodeClassifierFormatUndefined"/> class.
    /// </summary>
    public LolcodeClassifierFormatUndefined()
    {
      this.DisplayName = "LolcodeClassifier.Undefined"; // Human readable version of the name
    }
  }

  /// <summary>
  /// Defines an editor format for the LolcodeClassifier type that has a purple background
  /// and is underlined.
  /// </summary>
  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = "LolcodeClassifier.Keyword")]
  [Name("LolcodeClassifier.Keyword")]
  [UserVisible(true)] // This should be visible to the end user
  [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
  internal sealed class LolcodeClassifierFormatKeyword : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LolcodeClassifierFormatKeyword"/> class.
    /// </summary>
    public LolcodeClassifierFormatKeyword()
    {
      this.DisplayName = "LolcodeClassifier.Keyword"; // Human readable version of the name
      this.ForegroundColor = Colors.Blue;
    }
  }

  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = "LolcodeClassifier.Identifier")]
  [Name("LolcodeClassifier.Identifier")]
  [UserVisible(true)] // This should be visible to the end user
  [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
  internal sealed class LolcodeClassifierFormatIdentifier : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LolcodeClassifierFormatKeyword"/> class.
    /// </summary>
    public LolcodeClassifierFormatIdentifier()
    {
      this.DisplayName = "LolcodeClassifier.Identifier"; // Human readable version of the name
      this.ForegroundColor = Colors.DarkCyan;
    }
  }

  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = "LolcodeClassifier.StringLiteral")]
  [Name("LolcodeClassifier.StringLiteral")]
  [UserVisible(true)] // This should be visible to the end user
  [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
  internal sealed class LolcodeClassifierFormatStringLiteral : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LolcodeClassifierFormatKeyword"/> class.
    /// </summary>
    public LolcodeClassifierFormatStringLiteral()
    {
      this.DisplayName = "LolcodeClassifier.StringLiteral"; // Human readable version of the name
      this.ForegroundColor = Colors.DarkRed;
    }
  }

  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = "LolcodeClassifier.Comment")]
  [Name("LolcodeClassifier.Comment")]
  [UserVisible(true)] // This should be visible to the end user
  [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
  internal sealed class LolcodeClassifierFormatComment : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LolcodeClassifierFormatKeyword"/> class.
    /// </summary>
    public LolcodeClassifierFormatComment()
    {
      this.DisplayName = "LolcodeClassifier.Comment"; // Human readable version of the name
      this.ForegroundColor = Colors.DarkGreen;
    }
  }
}
