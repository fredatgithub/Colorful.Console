﻿using System;
using System.Collections.Concurrent;
using System.Drawing;
using Xunit;

namespace Colorful.Console.Tests
{
  public sealed class ColorStoreTests
  {
    public static readonly Color TEST_COLOR = Color.Orange;
    public static readonly ConsoleColor TEST_CONSOLE_COLOR = ConsoleColor.White;

    public static ColorStore GetColorStore()
    {
      ColorStore colorStore = new ColorStore(new ConcurrentDictionary<Color, ConsoleColor>(), new ConcurrentDictionary<ConsoleColor, Color>());
      colorStore.Update(TEST_CONSOLE_COLOR, TEST_COLOR);

      return colorStore;
    }

    [Fact]
    public void RequiresUpdate_ReturnsFalse_IfColorStoreContainsColor()
    {
      ColorStore colorStore = GetColorStore();

      bool requiresUpdate = colorStore.RequiresUpdate(TEST_COLOR);

      Assert.False(requiresUpdate);
    }

    [Fact]
    public void RequiresUpdate_ReturnsTrue_IfColorStoreDoesNotContainColor()
    {
      ColorStore colorStore = GetColorStore();

      Color notInStore = Color.Red;
      bool requiresUpdate = colorStore.RequiresUpdate(notInStore);

      Assert.True(requiresUpdate);
    }
  }
}
