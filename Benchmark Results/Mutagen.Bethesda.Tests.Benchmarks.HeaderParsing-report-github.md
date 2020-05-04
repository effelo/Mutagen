``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.815 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|                     Method |     Mean |    Error |   StdDev |
|--------------------------- |---------:|---------:|---------:|
|      MajorRecordHeaderSpan | 24.78 ns | 0.190 ns | 0.178 ns |
| MajorRecordHeaderGetStream | 31.45 ns | 0.103 ns | 0.092 ns |
|           MajorRecordFrame | 37.36 ns | 0.117 ns | 0.103 ns |
|     MajorRecordMemoryFrame | 39.24 ns | 0.125 ns | 0.117 ns |
