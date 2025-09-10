using System;

namespace Game.Domain.Core
{
    /// <summary>
    /// Domain-level exception for invariant violations or illegal command usage.
    /// Prefer returning validation errors, but use this when state would be corrupted otherwise.
    /// </summary>
    public sealed class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}