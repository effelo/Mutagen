``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.815 (1909/November2018Update/19H2)
Intel Core i7-4790K CPU 4.00GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|                                      Method |    Mean |    Error |   StdDev |  Median |       Gen 0 |       Gen 1 |     Gen 2 |  Allocated |
|-------------------------------------------- |--------:|---------:|---------:|--------:|------------:|------------:|----------:|-----------:|
|                                CreateBinary | 3.834 s | 0.0764 s | 0.0967 s | 3.810 s | 328000.0000 | 109000.0000 | 1000.0000 | 2298.55 MB |
|           CreateAndWriteBinaryOverlayToDisk | 3.402 s | 0.0154 s | 0.0128 s | 3.398 s | 292000.0000 |  52000.0000 |         - | 2177.75 MB |
|         CreateAndWriteBinaryOverlayToMemory | 2.426 s | 0.0478 s | 0.0621 s | 2.412 s | 332000.0000 |   1000.0000 |         - | 1753.16 MB |
|   CreateAndWriteBinaryOverlayParallelToDisk | 2.355 s | 0.0506 s | 0.1436 s | 2.339 s | 662000.0000 | 211000.0000 | 1000.0000 | 4046.23 MB |
| CreateAndWriteBinaryOverlayParallelToMemory | 2.256 s | 0.0461 s | 0.1308 s | 2.257 s | 829000.0000 | 233000.0000 | 1000.0000 | 4046.07 MB |
|                           WriteBinaryToDisk | 2.331 s | 0.0408 s | 0.0382 s | 2.315 s |  92000.0000 |  30000.0000 |         - |   552.7 MB |
|                         WriteBinaryToMemory | 1.331 s | 0.0060 s | 0.0053 s | 1.328 s |  32000.0000 |           - |         - |  128.11 MB |
|                   WriteBinaryParallelToDisk | 1.658 s | 0.0529 s | 0.1561 s | 1.679 s | 432000.0000 | 150000.0000 | 1000.0000 |  2420.6 MB |
|                 WriteBinaryParallelToMemory | 1.482 s | 0.0590 s | 0.1738 s | 1.420 s | 434000.0000 | 150000.0000 | 1000.0000 | 2420.73 MB |
