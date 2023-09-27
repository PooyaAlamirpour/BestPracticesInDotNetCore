﻿namespace BestPracticeInDotNet.framework.DDD.Abstracts;

public interface IAggregateRoot<out TKey> : IEntity<TKey>
{
    long Version { get; set; }
}