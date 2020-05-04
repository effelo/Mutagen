``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.815 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|          Method |     Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |---------:|---------:|---------:|-------:|------:|------:|----------:|
|    ArrayRenting | 43.80 ns | 0.426 ns | 0.398 ns | 0.0134 |     - |     - |      56 B |
| ArrayAllocation | 28.54 ns | 0.230 ns | 0.216 ns | 0.0268 |     - |     - |     112 B |
|     UnsafeAlloc | 25.45 ns | 0.109 ns | 0.102 ns | 0.0134 |     - |     - |      56 B |
|    StringCreate | 13.84 ns | 0.060 ns | 0.057 ns | 0.0134 |     - |     - |      56 B |
|        ReadSpan | 28.51 ns | 0.227 ns | 0.212 ns | 0.0134 |     - |     - |      56 B |
|      ReadMemory | 21.96 ns | 0.104 ns | 0.092 ns | 0.0134 |     - |     - |      56 B |
