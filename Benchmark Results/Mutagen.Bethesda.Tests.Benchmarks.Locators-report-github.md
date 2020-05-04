``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.815 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|           Method |              Mean |            Error |           StdDev |
|----------------- |------------------:|-----------------:|-----------------:|
| BaseGRUPIterator |          10.23 ns |         0.050 ns |         0.047 ns |
| GetFileLocations | 447,088,066.67 ns | 7,905,999.632 ns | 7,395,276.961 ns |
