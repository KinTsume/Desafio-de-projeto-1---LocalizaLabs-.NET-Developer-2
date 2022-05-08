using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.media;
using Xunit;

namespace RobertoTest
{
    public class CollisionDetectorTest
    {
        [Theory]
        public void VerifyCollision_TrianguloEPontos_VerificaPontoDentroDoTriangulo()
        {

        }
    }

    public class VerifyCollisionDataGenerator : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {
                new PointCollection
            },
            new object[] {7, 1, 5, 3}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
