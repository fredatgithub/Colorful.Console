using Xunit;

namespace Colorful.Console.Tests
{
  public sealed class TextPatternCollectionTests
  {
    private static readonly string dummyNicePattern = "cat";
    private static readonly string dummyNotNicePattern = "dog";

    [Fact]
    public void MatchFound_ReturnsTrue_WhenIdenticalStringIsMatchedAgainst()
    {
      TextPatternCollection patternCollection = new TextPatternCollection(new[] { dummyNicePattern });

      Assert.True(patternCollection.MatchFound(dummyNicePattern));
    }

    [Fact]
    public void MatchFound_ReturnsFalse_WhenNonoverlappingStringIsMatchedAgainst()
    {
      TextPatternCollection patternCollection = new TextPatternCollection(new[] { dummyNicePattern });

      Assert.False(patternCollection.MatchFound(dummyNotNicePattern));
    }
  }
}