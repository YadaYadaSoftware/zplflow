﻿namespace YadaYada.ZplFlow;

public abstract class Fragment
{
    protected Fragment(bool supportsOrigin = false, bool supportsHeight = false)
    {
        this.SupportsOrigin = supportsOrigin;
        this.SupportsHeight = supportsHeight;
    }

    protected Fragment()
    {
        
    }
    public abstract string GetZpl(Document document);
    public bool SupportsOrigin { get; }
    public bool SupportsHeight { get; }

    public virtual int? Height { get; init; } = null;
}