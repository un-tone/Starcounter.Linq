﻿using System.Linq;
using Starcounter.Nova;
using Xunit;
using static Starcounter.Linq.DbLinq;

namespace StarcounterLinqUnitTests.Tests
{
    public class CustomMethodsTests : IClassFixture<BaseTestsFixture>
    {
        private readonly BaseTestsFixture Fixture;

        public CustomMethodsTests(BaseTestsFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void Delete_Predicate()
        {
            Db.Transact(() =>
            {
                Objects<Person>().Delete(x => x.Age > 40);
            });
            Db.Transact(() =>
            {
                var cnt = Objects<Person>().Count();
                Assert.Equal(1, cnt);
            });
            Fixture.RecreateData();
        }

        [Fact]
        public void DeleteAll()
        {
            Db.Transact(() =>
            {
                Objects<Person>().DeleteAll();
            });
            Db.Transact(() =>
            {
                Assert.False(Objects<Person>().Any());
            });
            Fixture.RecreateData();
        }
    }
}