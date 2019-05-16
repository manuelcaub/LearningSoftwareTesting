# Software Testing - Conceptos básicos

## Tipos de tests

<img src="https://wac-cdn.atlassian.com/dam/jcr:5bc6cb83-2283-4e3f-8316-51caf5ac0fbf/Types%20of%20software%20testing.2018-07-03-21-15-54.svg" alt="drawing" width="400"/>

### Tests unitarios

Un test unitario es un fragmento de código que tiene la responsabilidad de probar el correcto funcionamiento de una unidad de código.

#### Principios **F.I.R.S.T**

- Fast - Las pruebas unitarias deberían ser rápidas
- Independent - Independientes
- Repeteable - Repetibles, con resultados deterministas
- Self validating - No deberían necesitar de una validación manual, sino que el resultado es validado por sí mismo
- Thorough - Completo, deberían cubrir cada escenario

### Tests de integración

Estos tests se encargan de verificar que las unidades del software se integran correctamente pero no se centran en la funcionalidad de la aplicación.

### Tests funcionales

En estos tests comprobamos simplemente que dada una entrada en nuestra aplicación, se produce la salida y resultado esperado.

Estos suelen ser los tipos principales, pero puede haber muchos más dependiendo del contexto; como por ejemplo pruebas de rendimiento.

## Ventajas

- Calidad del código
- Detección temprana de errores
- Integración continua
- Documentación activa
- Reduce el coste al optimizar tiempos de entrega

## Pirámide de tests

La pirámide de los tests es un concepto que hace incapié en la necesidad de desarrollar una cantidad mayor de tests unitarios que de tests de integración, funcionales o de interfaz. Esto es debido a que los tests unitarios deberían ser más rápidos, menos costosos de realizar y menos costosos de mantener.

![Pirámide de tests](https://martinfowler.com/bliki/images/testPyramid/test-pyramid.png)

Esta es una verdad a medias. Para la mayoría de proyectos puede valer, pero puede que el número de tests de cada tipo que tengas en tu proyecto dependa en mayor medida de la idiosincrasia del mismo.

## Patrón AAA

**Arrange**: Proceso de inicialización de los datos necesarios para la realización del test

**Act**: Invocación del método que se pretende probar

**Assert**: Comprobación de los resultados obtenidos conforme a los resultados esperados

## Naming

Independientemente de qué estrategia de naming se utilice para los tests, es imprescindible que esta se mantenga a lo largo de nuestro proyecto.

Una estrategia muy popular es Given > When > Then, que es una estragia utilizada en desarrollo guiado por comportamiento (BDD).

Ejemplo:

`Given_precondition_When_something_happens_Then_expectedResult`

Otra estrategia muy utilizada sería Should > When

Ejemplo:

`Should_expectedResult_When_something_happens`

## Dependency injection

La inyección de dependencias es una técnica que trata de separar una clase de sus dependencias proporcionándoselas por medio de un objeto en el constructor, en una propiedad o método.

Pero, ¿por qué nos importa la inyección de dependencias en las pruebas?

Al separar la implementación de sus dependencias nos permite mockear estas centrándonos unicamente en el fragmento de código que estamos probando.

## Test doubles

- Dummy

- Stub

- Mock

- Fake

## Builder

El patrón builder es un patrón de diseño de software, creacional, que nos permite una creación sencilla de objetos reduciendo el acoplamiento y encapsulando la creación de los mismos de una manera flexible.

En la implementación de nuestros tests nos servirá para construir los objetos que participarán en el test.

## Code coverage

La cobertura de código es una medida llevada a cabo al ejecutar nuestros tests que nos indica de manera porcentual qué cantidad de nuestro código ha sido probada.