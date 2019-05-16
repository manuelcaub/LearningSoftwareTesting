# Testing en .NET - Xunit

Para empezar, vamos a partir de un proyecto ficticio de una tienda de coches. En este proyecto tendremos una serie de clases que iremos testeando para aprender a realizar tests unitarios con Xunit.

Iremos viendo las diferentes posibilidades que tenemos dentro de esta librería a través de una serie de ejercicios.

## Facts

Para marcar un método como un test haremos uso del atributo `Xunit.Fact`.

``` bash
Realizar varios tests unitarios sobre las clases de dominio.
```

``` bash
Realizar un test en el que se compruebe que el resultado esperado es el lanzamiento de una excepción.
```

## Theories

Una Theory es la forma que tiene Xunit de realizar tests parametrizados. Para marcar un método como Theory basta con hacer uso del atributo `Xunit.Theory` y de un atributo que le pase los datos parametrizados al método. Estos atributos son:

- `Xunit.InlineData`
- `Xunit.MemberData`
- `Xunit.ClassData`

``` bash
Identificar qué tests de los anteriores se pueden parametrizar y utilizar estos tres atributos para pasar los datos al test.
```

## FluentAssertions

Vamos a instalar FluentAssertions y cambiaremos la forma en la que hacíamos las aserciones en los tests anteriores. FluentAssertions nos permite realizar aserciones más claras y nos provee una información más legible acerca de lo que ha pasado cuando un test falla.

Por ejemplo, mientras que con las aserciones de Xunit tendríamos algo como:

`Message: Assert.True() Failure
Expected: True
Actual:   False`

con FluentAssertions tendríamos:

 `Message: Expected result to be 3, but found 2.`

 ``` bash
 Instalar FluentAssertions y cambiar las aserciones anteriores para que sean más descriptivas
 ```

```csharp --source-file ./Snippets/Program.cs --project ./Snippets/Snippets.csproj --region XunitVsFluentAssertions
```

## Mocks - NSubtitute

[github](https://nsubstitute.github.io/)

## Contexto compartido

En Xunit, el constructor y el método `Dispose` son compartidos entre los tests de la clase, pero no se comparten las instancias de los objetos creados en ellos.

``` bash
Implementar la interfaz IDisposable y comprobar que tanto el constructor como el método Dispose se ejecutan una vez por cada test.
```

Para compartir un contexto entre todos los tests de una clase debemos hacer uso de la interfaz `IClassFixture<TFixture>` e inyectar esta `TFixture` en el constructor.

Esta `TFixture` sería la clase donde tenemos el contexto que queremos compartir.

``` bash
Crear la una clase Fixture y comprobar el contexto compartido entre los tests de la misma clase.

```

Cuando queremos compartir un contexto entre múltiples clases de tests, debemos crear una clase que implemente la interfaz `ICollectionFixture<TFixture>` y decorarla con un `CollectionDefinition`. Después, en nuestras clases de tests, añadiremos el decorador `Collection` con el nombre que hemos establecido en la definición.

``` bash
Crear una colección y comprobar que la Fixture se comparte entre todos los tests decorados con esa colección.
```

## Inicialización asíncrona - `IAsyncLifetime`

En Xunit, tenemos la posibilidad de inicializar los tests o fixtures de forma asíncrona. Para ello debemos implementar la interfaz `IAsyncLifetime`, que tiene definidos los métodos `InitializeAsync` y `DisposeAsync` que se ejecutarán después del constructor y antes del método `Dispose` (si lo hubiera).

``` bash
Comprobar cómo podemos inicializar de manera asíncrona nuestros tests.
```

Así, el ciclo de vida de una clase de tests quedaría así:

1. Constructor
2. InitializeAsync
3. DisposeAsync
4. Dispose

## Paralelismo

Los tests en Xunit pueden ejecutarse en paralelo. Hay diferentes formas de configurar esta paralelización dependiendo de cada caso. En el json de configuración `xunit.runner.json` podemos establecer tres propiedades:

- parallelizeAssembly: `true` si queremos que los tests dentro de un ensamblado se ejecuten en paralelo con tests de otros ensamblados.

- parallelizeTestCollections: `true` si queremos que los tests de una colección se ejecuten en paralelo con tests de otras colecciones. Los tests dentro de una misma colección se ejecutarán secuencialmente.

- maxParallelThreads: Número de threads que queremos usar en nuestra paralelización. Por defecto será el número de procesadores lógicos de la máquina.

``` bash
Añadir el fichero json de configuración `xunit.runner.json` y customizarlo comprobando los cambios.
```

## Cobertura

[Coverlet](https://github.com/tonerdo/coverlet)

``` bash
dotnet add coverlet.msbuild
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:Exclude="[xunit.*]*" /p:CoverletOutput='./results/'
```

[ReportGenerator](https://github.com/danielpalme/ReportGenerator)

``` bash
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator "-reports:*/*/coverage.opencover.xml" "-targetdir:report"
```