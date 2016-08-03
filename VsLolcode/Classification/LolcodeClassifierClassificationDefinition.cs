//------------------------------------------------------------------------------
// <copyright file="LolcodeClassifierClassificationDefinition.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VsLolcode.Classification
{
  /// <summary>
  /// Classification type definition export for LolcodeClassifier
  /// </summary>
  internal static class LolcodeClassifierClassificationDefinition
  {
    // This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable 169

    /// <summary>
    /// Defines the "LolcodeClassifier" classification type.
    /// </summary>
    [Export(typeof(ClassificationTypeDefinition))]
    [Name("LolcodeClassifier.Keyword")]
    private static ClassificationTypeDefinition typeDefinitionKeyword;

    /// <summary>
    /// Defines the "LolcodeClassifier" classification type.
    /// </summary>
    [Export(typeof(ClassificationTypeDefinition))]
    [Name("LolcodeClassifier.Identifier")]
    private static ClassificationTypeDefinition typeDefinitionIdentifier;

    /// <summary>
    /// Defines the "LolcodeClassifier" classification type.
    /// </summary>
    [Export(typeof(ClassificationTypeDefinition))]
    [Name("LolcodeClassifier.Undefined")]
    private static ClassificationTypeDefinition typeDefinitionUndefined;

    /// <summary>
    /// Defines the "LolcodeClassifier" classification type.
    /// </summary>
    [Export(typeof(ClassificationTypeDefinition))]
    [Name("LolcodeClassifier.StringLiteral")]
    private static ClassificationTypeDefinition typeDefinitionStringLiteral;

    /// <summary>
    /// Defines the "LolcodeClassifier" classification type.
    /// </summary>
    [Export(typeof(ClassificationTypeDefinition))]
    [Name("LolcodeClassifier.Comment")]
    private static ClassificationTypeDefinition typeDefinitionComment;

#pragma warning restore 169
  }
}
