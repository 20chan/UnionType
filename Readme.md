# UnionType

Simple implementation of union type of Typescript in C#

`Union<T1, T2>` equals to `T1 | T2`

```csharp
Union<int, string> a = 1, b = "hello";

if (a.Is<int>()) {
    Console.WriteLine((int)a + 10);
}
```
