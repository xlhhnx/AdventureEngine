using System;
using System.Collections.Generic;

public class ContentBatchComparer : IEqualityComparer<ContentBatch>
{
    public bool Equals(ContentBatch x, ContentBatch y)
    {
        return x.BatchId == y.BatchId;
    }

    public int GetHashCode(ContentBatch obj)
    {
        return obj.GetHashCode();
    }
}