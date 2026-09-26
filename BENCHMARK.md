# Benchmark Results

## Benchmark Setup

I compared two approaches for repeated string appending:

- String concatenation using `+=`
- `StringBuilder` using `Append()`

The benchmark was run using BenchmarkDotNet with:

- 100 iterations
- 1,000 iterations
- 10,000 iterations
- 100,000 iterations

The benchmark also used `MemoryDiagnoser` to measure allocated memory.

## Results

| Method | Iterations | Mean | Allocated |
|---|---:|---:|---:|
| StringConcatenation | 100 | 5,931.6 ns | 91.17 KB |
| StringBuilderConcatenation | 100 | 289.7 ns | 2.45 KB |
| StringConcatenation | 1,000 | 341,321.1 ns | 8,822.23 KB |
| StringBuilderConcatenation | 1,000 | 1,797.6 ns | 32.35 KB |
| StringConcatenation | 10,000 | 72,444,429.1 ns | 879,309.68 KB |
| StringBuilderConcatenation | 10,000 | 11,665.8 ns | 189.3 KB |
| StringConcatenation | 100,000 | 11,961,745,498.3 ns | 87,899,462.06 KB |
| StringBuilderConcatenation | 100,000 | 115,064.4 ns | 1,774.53 KB |

## Questions and Answers

### 1. Which is faster at 100 iterations?

At 100 iterations, `StringBuilderConcatenation` had a lower mean time:

- String concatenation: 5,931.6 ns
- StringBuilder: 289.7 ns

So the benchmark measured a lower execution time for StringBuilder at 100 iterations.

### 2. Which is faster at 100,000 iterations?

At 100,000 iterations:

- String concatenation: 11,961,745,498.3 ns
- StringBuilder: 115,064.4 ns

The measured execution time of StringBuilder was much lower.

### 3. Which uses more memory?

String concatenation allocated much more memory.

At 100,000 iterations:

- String concatenation: 87,899,462.06 KB
- StringBuilder: 1,774.53 KB

### 4. What happens to string concatenation performance as the loop size increases?

As the number of iterations increases, the execution time of repeated string concatenation increases dramatically.

The measured mean changed from:

- 5,931.6 ns at 100 iterations
- 341,321.1 ns at 1,000 iterations
- 72,444,429.1 ns at 10,000 iterations
- 11,961,745,498.3 ns at 100,000 iterations

This shows that repeated string concatenation becomes much more expensive as the number of iterations grows.

### 5. Why does repeated string concatenation create many allocations?

`string` is immutable in C#.

When using:

```csharp
result += "C# Basics";
```

a new string is created each time because the existing string cannot be changed. This causes many allocations, especially when the operation is repeated many times.

### 6. Why does StringBuilder usually perform better for repeated appending?

`StringBuilder` is designed for changing and building text.

Instead of creating a new string for every append, it uses an internal buffer that can grow as needed. This reduces the number of allocations and improves performance when many strings are appended repeatedly.

### 7. Is StringBuilder always better?

No.

For a small number of simple string operations, normal string concatenation can be clear and perfectly fine.

`StringBuilder` is more useful when many string modifications or repeated appends are needed, especially inside loops.
