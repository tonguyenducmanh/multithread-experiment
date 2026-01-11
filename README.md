## Project test việc chạy đa luồng ở 1 số ngôn ngữ lập trình

Đối với ngôn ngữ lập trình C#, chạy test bằng project bên dưới

```
/DotNetMultiThread/TDProject.Test
```

# Lộ trình học Multithreading trong C#

## Giai đoạn 1: Nền tảng cơ bản

### 1.1. Khái niệm cốt lõi

- [ ] Thread là gì? Process vs Thread
- [ ] Concurrent vs Parallel
- [ ] Synchronous vs Asynchronous
- [ ] Blocking vs Non-blocking
- [ ] Context Switching
- [ ] Thread Lifecycle (States: New, Running, Waiting, Terminated)
- [ ] Foreground Thread vs Background Thread

### 1.2. Tạo và quản lý Thread cơ bản

- [ ] Tạo Thread với `Thread` class
- [ ] ThreadStart delegate
- [ ] ParameterizedThreadStart delegate
- [ ] Thread.Start(), Thread.Join()
- [ ] Thread.Sleep()
- [ ] Thread.Abort() (deprecated - hiểu tại sao không nên dùng)
- [ ] Thread.IsAlive, Thread.IsBackground
- [ ] Thread Priority (ThreadPriority enum)
- [ ] Thread Name

### 1.3. Thread Pool

- [ ] ThreadPool là gì và tại sao dùng
- [ ] ThreadPool.QueueUserWorkItem()
- [ ] WaitCallback delegate
- [ ] ThreadPool.GetMaxThreads()
- [ ] ThreadPool.SetMaxThreads()
- [ ] Worker Threads vs I/O Completion Threads

---

## Giai đoạn 2: Đồng bộ hóa (Synchronization)

### 2.1. Race Condition và vấn đề đồng bộ

- [ ] Race Condition là gì
- [ ] Critical Section
- [ ] Atomic Operations
- [ ] Memory Visibility Problems
- [ ] Deadlock, Livelock, Starvation

### 2.2. Lock cơ bản

- [ ] `lock` keyword (Monitor.Enter/Exit)
- [ ] Monitor class
- [ ] Monitor.Wait()
- [ ] Monitor.Pulse()
- [ ] Monitor.PulseAll()
- [ ] Monitor.TryEnter()
- [ ] Best practices khi dùng lock

### 2.3. Interlocked

- [ ] Interlocked.Increment()
- [ ] Interlocked.Decrement()
- [ ] Interlocked.Add()
- [ ] Interlocked.Exchange()
- [ ] Interlocked.CompareExchange()
- [ ] Interlocked.Read()
- [ ] Khi nào dùng Interlocked thay vì lock

### 2.4. Mutex

- [ ] Mutex class
- [ ] Mutex.WaitOne()
- [ ] Mutex.ReleaseMutex()
- [ ] Named Mutex (cross-process synchronization)
- [ ] So sánh Mutex vs Monitor

### 2.5. Semaphore

- [ ] Semaphore class
- [ ] Semaphore(initialCount, maximumCount)
- [ ] Semaphore.WaitOne()
- [ ] Semaphore.Release()
- [ ] SemaphoreSlim (lightweight version)
- [ ] SemaphoreSlim.WaitAsync()
- [ ] Named Semaphore

### 2.6. ReaderWriterLock

- [ ] ReaderWriterLock class (legacy)
- [ ] ReaderWriterLockSlim
- [ ] EnterReadLock() / ExitReadLock()
- [ ] EnterWriteLock() / ExitWriteLock()
- [ ] EnterUpgradeableReadLock()
- [ ] Use cases: nhiều reader, ít writer

### 2.7. Event Synchronization

- [ ] EventWaitHandle base class
- [ ] AutoResetEvent
- [ ] ManualResetEvent
- [ ] ManualResetEventSlim
- [ ] Set(), Reset(), WaitOne()
- [ ] Khi nào dùng Auto vs Manual

### 2.8. Barrier

- [ ] Barrier class
- [ ] Barrier(participantCount)
- [ ] SignalAndWait()
- [ ] AddParticipant() / RemoveParticipant()
- [ ] PostPhaseAction

### 2.9. CountdownEvent

- [ ] CountdownEvent class
- [ ] Signal()
- [ ] Wait()
- [ ] AddCount()
- [ ] Reset()

### 2.10. SpinLock và SpinWait

- [ ] SpinLock struct
- [ ] Khi nào dùng SpinLock
- [ ] SpinWait struct
- [ ] Spin-waiting vs Blocking
- [ ] SpinWait.SpinUntil()

---

## Giai đoạn 3: Task và Async/Await

### 3.1. Task cơ bản

- [ ] Task class vs Thread class
- [ ] Task.Run()
- [ ] Task.Factory.StartNew()
- [ ] Task.Wait()
- [ ] Task.Result
- [ ] Task.Status (TaskStatus enum)
- [ ] Task.IsCompleted, IsCanceled, IsFaulted
- [ ] ContinueWith()

### 3.2. Task<TResult>

- [ ] Generic Task với giá trị trả về
- [ ] Task.FromResult()
- [ ] Task.FromException()
- [ ] Task.FromCanceled()

### 3.3. Task Coordination

- [ ] Task.WaitAll()
- [ ] Task.WaitAny()
- [ ] Task.WhenAll()
- [ ] Task.WhenAny()
- [ ] Task.Delay()

### 3.4. Async/Await

- [ ] async modifier
- [ ] await operator
- [ ] Async method naming convention (suffix Async)
- [ ] Async method return types: Task, Task<T>, void, ValueTask
- [ ] ConfigureAwait(false)
- [ ] SynchronizationContext
- [ ] Async all the way principle
- [ ] Avoid async void (trừ event handlers)

### 3.5. ValueTask

- [ ] ValueTask<T> struct
- [ ] Khi nào dùng ValueTask thay vì Task
- [ ] Performance benefits
- [ ] Limitations của ValueTask

### 3.6. TaskCompletionSource

- [ ] TaskCompletionSource<T>
- [ ] SetResult()
- [ ] SetException()
- [ ] SetCanceled()
- [ ] TrySetResult/Exception/Canceled
- [ ] Tạo Task wrapper cho callback-based APIs

### 3.7. Cancellation

- [ ] CancellationToken struct
- [ ] CancellationTokenSource class
- [ ] Token.IsCancellationRequested
- [ ] Token.ThrowIfCancellationRequested()
- [ ] Token.Register()
- [ ] CancellationTokenSource.Cancel()
- [ ] CancellationTokenSource.CancelAfter()
- [ ] Linked tokens với CreateLinkedTokenSource()

### 3.8. Task Exception Handling

- [ ] AggregateException
- [ ] Flatten()
- [ ] Handle()
- [ ] InnerExceptions
- [ ] try-catch trong async methods
- [ ] Unobserved task exceptions

---

## Giai đoạn 4: Parallel Programming

### 4.1. Parallel class

- [ ] Parallel.Invoke()
- [ ] Parallel.For()
- [ ] Parallel.ForEach()
- [ ] ParallelOptions
- [ ] MaxDegreeOfParallelism
- [ ] CancellationToken trong Parallel
- [ ] ParallelLoopState (Stop, Break)
- [ ] Thread-local state trong Parallel.For

### 4.2. PLINQ (Parallel LINQ)

- [ ] AsParallel()
- [ ] WithDegreeOfParallelism()
- [ ] WithCancellation()
- [ ] WithExecutionMode() (Default, ForceParallelism)
- [ ] WithMergeOptions() (NotBuffered, AutoBuffered, FullyBuffered)
- [ ] AsOrdered() / AsUnordered()
- [ ] ForAll()
- [ ] PLINQ vs LINQ performance

### 4.3. Partitioning

- [ ] Partitioner<T> class
- [ ] Partitioner.Create()
- [ ] Range partitioning
- [ ] Chunk partitioning
- [ ] Custom partitioners
- [ ] OrderablePartitioner<T>

---

## Giai đoạn 5: Thread-Safe Collections

### 5.1. Concurrent Collections Overview

- [ ] Tại sao không dùng lock + normal collections
- [ ] Lock-free vs Lock-based collections
- [ ] System.Collections.Concurrent namespace

### 5.2. ConcurrentQueue

- [ ] Enqueue()
- [ ] TryDequeue()
- [ ] TryPeek()
- [ ] IsEmpty
- [ ] FIFO behavior

### 5.3. ConcurrentStack

- [ ] Push()
- [ ] TryPop()
- [ ] TryPeek()
- [ ] PushRange()
- [ ] TryPopRange()
- [ ] LIFO behavior

### 5.4. ConcurrentBag

- [ ] Add()
- [ ] TryTake()
- [ ] TryPeek()
- [ ] Unordered collection
- [ ] Thread-local optimization

### 5.5. ConcurrentDictionary

- [ ] TryAdd()
- [ ] TryGetValue()
- [ ] TryUpdate()
- [ ] TryRemove()
- [ ] AddOrUpdate()
- [ ] GetOrAdd()
- [ ] Keys, Values collections
- [ ] Concurrency level

### 5.6. BlockingCollection

- [ ] Producer-Consumer pattern
- [ ] Add() / TryAdd()
- [ ] Take() / TryTake()
- [ ] CompleteAdding()
- [ ] IsCompleted
- [ ] GetConsumingEnumerable()
- [ ] BoundedCapacity
- [ ] Underlying collection types

---

## Giai đoạn 6: Immutable Collections

### 6.1. Immutability Concepts

- [ ] Immutable vs Read-only
- [ ] Thread-safety benefits
- [ ] Performance trade-offs
- [ ] System.Collections.Immutable namespace

### 6.2. Immutable Collection Types

- [ ] ImmutableArray<T>
- [ ] ImmutableList<T>
- [ ] ImmutableQueue<T>
- [ ] ImmutableStack<T>
- [ ] ImmutableHashSet<T>
- [ ] ImmutableSortedSet<T>
- [ ] ImmutableDictionary<K,V>
- [ ] ImmutableSortedDictionary<K,V>

### 6.3. Immutable Collection Builders

- [ ] ToImmutable()
- [ ] CreateBuilder()
- [ ] Builder pattern for bulk operations
- [ ] Performance optimization

---

## Giai đoạn 7: Channels

### 7.1. Channel Basics

- [ ] System.Threading.Channels namespace
- [ ] Channel<T> class
- [ ] Producer-Consumer với Channels
- [ ] Channel.CreateUnbounded()
- [ ] Channel.CreateBounded()

### 7.2. Channel Operations

- [ ] Writer.WriteAsync()
- [ ] Writer.TryWrite()
- [ ] Writer.Complete()
- [ ] Reader.ReadAsync()
- [ ] Reader.TryRead()
- [ ] Reader.WaitToReadAsync()
- [ ] Reader.ReadAllAsync()

### 7.3. Channel Options

- [ ] BoundedChannelOptions
- [ ] UnboundedChannelOptions
- [ ] FullMode (Wait, DropNewest, DropOldest, DropWrite)
- [ ] SingleReader / SingleWriter optimization

---

## Giai đoạn 8: Dataflow (TPL Dataflow)

### 8.1. Dataflow Concepts

- [ ] System.Threading.Tasks.Dataflow namespace
- [ ] Blocks và Links
- [ ] Dataflow vs Channels
- [ ] Target blocks vs Source blocks

### 8.2. Action Blocks

- [ ] ActionBlock<T>
- [ ] Post()
- [ ] SendAsync()
- [ ] Complete()
- [ ] Completion

### 8.3. Transform Blocks

- [ ] TransformBlock<TInput, TOutput>
- [ ] TransformManyBlock<TInput, TOutput>
- [ ] LinkTo()

### 8.4. Buffering Blocks

- [ ] BufferBlock<T>
- [ ] BroadcastBlock<T>
- [ ] WriteOnceBlock<T>

### 8.5. Grouping Blocks

- [ ] BatchBlock<T>
- [ ] JoinBlock<T1, T2>
- [ ] BatchedJoinBlock<T1, T2>

### 8.6. Dataflow Options

- [ ] DataflowBlockOptions
- [ ] MaxDegreeOfParallelism
- [ ] BoundedCapacity
- [ ] CancellationToken
- [ ] TaskScheduler

---

## Giai đoạn 9: Thread-Local Storage

### 9.1. ThreadLocal<T>

- [ ] ThreadLocal<T> class
- [ ] Value property
- [ ] Lazy initialization per thread
- [ ] Dispose pattern
- [ ] Values property (all thread values)

### 9.2. ThreadStatic

- [ ] ThreadStaticAttribute
- [ ] Static field per thread
- [ ] Limitations
- [ ] So sánh với ThreadLocal<T>

### 9.3. AsyncLocal<T>

- [ ] AsyncLocal<T> class
- [ ] Async context flow
- [ ] Value property
- [ ] Use cases: logging context, correlation IDs

---

## Giai đoạn 10: Memory và Threading

### 10.1. Memory Barriers

- [ ] Thread.MemoryBarrier()
- [ ] Volatile reads/writes
- [ ] Memory reordering
- [ ] Happens-before relationship

### 10.2. Volatile

- [ ] volatile keyword
- [ ] Volatile.Read()
- [ ] Volatile.Write()
- [ ] Khi nào dùng volatile

### 10.3. Lazy Initialization

- [ ] Lazy<T> class
- [ ] LazyThreadSafetyMode enum
- [ ] Value property
- [ ] IsValueCreated
- [ ] Double-checked locking pattern

---

## Giai đoạn 11: Timer Types

### 11.1. System.Threading.Timer

- [ ] Timer class
- [ ] TimerCallback delegate
- [ ] Constructor parameters
- [ ] Change()
- [ ] Dispose()

### 11.2. System.Timers.Timer

- [ ] Timer class (event-based)
- [ ] Elapsed event
- [ ] AutoReset property
- [ ] Start() / Stop()

### 11.3. PeriodicTimer (.NET 6+)

- [ ] PeriodicTimer class
- [ ] WaitForNextTickAsync()
- [ ] Async-friendly design
- [ ] Dispose()

---

## Giai đoạn 12: Advanced Topics

### 12.1. Custom TaskScheduler

- [ ] TaskScheduler class
- [ ] QueueTask()
- [ ] TryExecuteTaskInline()
- [ ] MaximumConcurrencyLevel
- [ ] Custom scheduling logic

### 12.2. Custom SynchronizationContext

- [ ] SynchronizationContext class
- [ ] Post() / Send()
- [ ] SetSynchronizationContext()
- [ ] UI thread synchronization

### 12.3. IAsyncEnumerable

- [ ] async streams (C# 8+)
- [ ] yield return trong async methods
- [ ] await foreach
- [ ] ConfigureAwait với streams
- [ ] Cancellation trong async streams

### 12.4. Async Disposal

- [ ] IAsyncDisposable interface
- [ ] DisposeAsync()
- [ ] await using statement

### 12.5. WaitHandle

- [ ] WaitHandle base class
- [ ] WaitAll() / WaitAny()
- [ ] SignalAndWait()
- [ ] SafeWaitHandle

---

## Giai đoạn 13: Best Practices & Patterns

### 13.1. Design Patterns

- [ ] Producer-Consumer pattern
- [ ] Reader-Writer pattern
- [ ] Pipeline pattern
- [ ] Fork-Join pattern
- [ ] Actor model basics

### 13.2. Performance

- [ ] Avoid unnecessary locking
- [ ] Minimize lock duration
- [ ] Lock granularity
- [ ] Lock ordering (deadlock prevention)
- [ ] Use appropriate sync primitives
- [ ] Measure before optimizing

### 13.3. Debugging

- [ ] Visual Studio parallel debugging
- [ ] Threads window
- [ ] Parallel Stacks window
- [ ] Tasks window
- [ ] Debug.WriteLine() với thread ID
- [ ] Debugging deadlocks

### 13.4. Testing

- [ ] Unit testing async code
- [ ] Testing với Task.Delay()
- [ ] ManualResetEventSlim cho testing
- [ ] Mocking async methods
- [ ] Race condition testing strategies

### 13.5. Common Pitfalls

- [ ] Async void dangers
- [ ] Deadlocks với .Result / .Wait()
- [ ] Capturing wrong variables trong loops
- [ ] Disposing active threads
- [ ] Shared state without synchronization
- [ ] Over-parallelization

---

## Giai đoạn 14: Thực hành Projects

### 14.1. Beginner Projects

- [ ] Multi-threaded file downloader
- [ ] Producer-Consumer queue implementation
- [ ] Thread-safe logger
- [ ] Simple web scraper với async/await
- [ ] Parallel image processor

### 14.2. Intermediate Projects

- [ ] Custom thread pool implementation
- [ ] Async HTTP server
- [ ] Dataflow pipeline cho data processing
- [ ] Chat server với concurrent connections
- [ ] Background job scheduler

### 14.3. Advanced Projects

- [ ] Lock-free data structure implementation
- [ ] Custom async iterator
- [ ] Actor-based system
- [ ] High-performance message queue
- [ ] Distributed task coordinator

---

## Checklist Tổng Kết

### Kiến thức cốt lõi

- [ ] Hiểu rõ Thread lifecycle
- [ ] Hiểu Race Condition, Deadlock
- [ ] Thành thạo async/await
- [ ] Biết khi nào dùng Parallel vs Async
- [ ] Hiểu memory model trong multithreading

### Kỹ năng thực hành

- [ ] Tạo và quản lý threads
- [ ] Implement thread-safe code
- [ ] Sử dụng concurrent collections
- [ ] Xử lý cancellation đúng cách
- [ ] Debug multithreaded applications

### Công cụ và APIs

- [ ] Thread, ThreadPool
- [ ] Task, async/await
- [ ] Lock primitives (Monitor, Semaphore, etc.)
- [ ] Concurrent collections
- [ ] Parallel, PLINQ
- [ ] Channels, Dataflow

### Tư duy

- [ ] Tư duy về concurrency
- [ ] Phân tích performance bottlenecks
- [ ] Thiết kế thread-safe systems
- [ ] Chọn đúng tool cho đúng job
