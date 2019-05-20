# Snippets

## Fact

``` cs
public class TestClass
{
    [Fact]
    public void Given_precondition_When_something_happens_Then_expectedResult()
    {
        Assert.Equal(1, 2);
    }
}
```

## Theory

``` cs
public class TestClass
{
    [Theory]
    [InlineData(1, 2)]
    public void Given_precondition_When_something_happens_Then_expectedResult(int input, int expectedResult)
    {
        Assert.Equal(input, expetecResult);
    }
}
```

## Member Data

``` cs
public static IEnumerable<object[]> GetNumbers()
{
    yield return new object[] { 5, 1, 3, 9 };
    yield return new object[] { 7, 1, 5, 3 };
}
```

## Class Data

``` cs
public class TestData : List<object[]>
{
    public TestData()
    {
        Add(new object[] {1, 2, 3, 4});
        Add(new object[] {5, 6, 7, 8});
    }
}
```

## Collection Fixture

``` cs
public class Fixture : IDisposable
{
    public Fixture()
    {
    }

    public void Dispose()
    {
    }
}

[CollectionDefinition("MyCollection")]
public class MyCollection : ICollectionFixture<Fixture>
{
}

[Collection("MyCollection")]
public class MyTestClass
{
    private readonly Fixture _fixture;

    public MyTestClass(Fixture fixture)
    {
        _fixture = fixture;
    }
}

```

## xunit.runner.json

``` json
{
  "methodDisplay": "method",
  "longRunningTestSeconds": 1,
  "diagnosticMessages": true,
  "maxParallelThreads": 0,
  "parallelizeAssembly": true,
  "parallelizeTestCollections": true
}
```

## Builder

``` cs
    public class CarBuilder
    {
        private CarDto _car;

        private CarBuilder()
        {
            _car = new CarDto
            {
                Name = "Tesla"
            };
        }

        public static CarBuilder New()
        {
            return new CarBuilder();
        }

        public CarBuilder From1999()
        {
            _car.Year = 1999;
            return this;
        }

        public CarBuilder WithFourDoors()
        {
            _car.Doors = 4;
            return this;
        }

        public CarBuilder WithFourSeats()
        {
            _car.Seats = 4;
            return this;
        }

        public CarBuilder WithDiesel()
        {
            _car.Fuel = "diesel";
            return this;
        }

        public CarBuilder Classic()
        {
            _car.Type = "classic";
            return this;
        }

        public CarDto Build()
        {
            return _car;
        }
    }
```

## Configure TestServer

``` cs
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = new WebHostBuilder()
    .UseConfiguration(configuration)
    .UseStartup<TestStartup>()
    .UseSetting(WebHostDefaults.ApplicationKey, typeof(Startup).GetTypeInfo().Assembly.GetName().Name);

var server = new TestServer(builder);
```

``` cs
public async Task InitializeAsync()
{
    using (var scope = Server.Host.Services.CreateScope())
    {
        var context = (CarShopDbContext)scope
            .ServiceProvider
            .GetService(typeof(CarShopDbContext));
        await context.Database.MigrateAsync();
    }
}
```