using System;

namespace GenexEditor.Core
{
    public abstract class Metadata
    {
        public abstract string Name { get; }

        public abstract string Version { get; }

        public abstract string Description { get; }
    }
}
