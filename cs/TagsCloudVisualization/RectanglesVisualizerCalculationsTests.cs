﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization
{
    class RectanglesVisualizerСalculationsTests
    {
        [Test]
        public void GetOptimalSizeForImage_ShouldReturnCorrectSize()
        {
            var size = new Size(3, 3);
            var rectangles = new List<Rectangle>
            {
                new Rectangle(new Point(-5, -5), size),
                new Rectangle(new Point(0, 0), size)
            };

            var optimalImageSize = RectanglesVisualizerСalculations.GetOptimalSizeForImage(rectangles, 5);

            optimalImageSize.Should().Be(new Size(18, 18));
        }

        [TestCase(10, 10)]
        [TestCase(9, 9)]
        public void GetCenter_ShouldReturnCorrectCenter(int width, int height)
        {
            var size = new Size(width, height);

            var center = RectanglesVisualizerСalculations.GetCenter(size);

            center.Should().Be(new Point(width / 2, height / 2));
        }

        [Test]
        public void GetRectanglesWithOptimalLocation_ShouldReturnCorrectNewRectangles()
        {
            var size = new Size(3, 3);
            var rectangles = new List<Rectangle>
            {
                new Rectangle(new Point(-5, -5), size),
                new Rectangle(new Point(0, 0), size)
            };

            var newRectangles = RectanglesVisualizerСalculations.GetRectanglesWithOptimalLocation(rectangles, new Size(10, -10));

            var firstExpectedRectangle = new Rectangle(new Point(5, -15), size);
            var secondExpectedRectangle = new Rectangle(new Point(10, -10), size);
            newRectangles.Count.Should().Be(2);
            newRectangles[0].Should().Be(firstExpectedRectangle);
            newRectangles[1].Should().Be(secondExpectedRectangle);
        }
    }
}
