``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.815 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|        Method |      Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |----------:|---------:|---------:|-------:|------:|------:|----------:|
|  ParseFormKey |  28.24 ns | 0.179 ns | 0.168 ns |      - |     - |     - |         - |
|   ParseModKey | 123.59 ns | 0.592 ns | 0.553 ns | 0.0095 |     - |     - |      40 B |
|   ParseFormID |  23.79 ns | 0.103 ns | 0.091 ns |      - |     - |     - |         - |
| ParseFormID0x |  23.45 ns | 0.101 ns | 0.094 ns |      - |     - |     - |         - |
