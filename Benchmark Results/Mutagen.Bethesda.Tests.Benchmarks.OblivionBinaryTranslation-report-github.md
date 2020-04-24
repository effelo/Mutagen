``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.815 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|                                      Method |    Mean |    Error |   StdDev |       Gen 0 |       Gen 1 |     Gen 2 |    Allocated |
|-------------------------------------------- |--------:|---------:|---------:|------------:|------------:|----------:|-------------:|
|                                CreateBinary | 3.972 s | 0.0780 s | 0.0987 s | 323000.0000 | 112000.0000 | 1000.0000 | 2410223296 B |
|           CreateAndWriteBinaryOverlayToDisk | 3.402 s | 0.0468 s | 0.0391 s | 292000.0000 |  52000.0000 |         - | 2283539504 B |
|         CreateAndWriteBinaryOverlayToMemory | 2.381 s | 0.0087 s | 0.0068 s | 331000.0000 |   1000.0000 |         - | 1838321976 B |
|   CreateAndWriteBinaryOverlayParallelToDisk | 2.566 s | 0.0684 s | 0.1940 s | 864000.0000 | 233000.0000 | 1000.0000 | 4242442672 B |
| CreateAndWriteBinaryOverlayParallelToMemory | 2.462 s | 0.0637 s | 0.1867 s | 639000.0000 | 220000.0000 | 1000.0000 |      3.95 GB |
|                           WriteBinaryToDisk | 2.391 s | 0.0372 s | 0.0311 s |  92000.0000 |  30000.0000 |         - |  579548032 B |
|                         WriteBinaryToMemory | 1.327 s | 0.0044 s | 0.0041 s |  32000.0000 |           - |         - |  134330856 B |
|                   WriteBinaryParallelToDisk | 1.635 s | 0.0558 s | 0.1638 s | 436000.0000 | 150000.0000 | 1000.0000 | 2538712360 B |
|                 WriteBinaryParallelToMemory | 1.580 s | 0.0514 s | 0.1508 s | 435000.0000 | 151000.0000 | 1000.0000 | 2538748336 B |
