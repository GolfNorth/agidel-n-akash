using System.Collections.Generic;

namespace Game.Domain.Placement
{
    /// <summary>
    /// Abstraction that provides placement rules for a given prototype id.
    /// </summary>
    public interface IPlacementRuleProvider
    {
        /// <summary>
        /// Returns the ordered collection of rules bound to the prototype id.
        /// May return an empty sequence if the prototype has no placement restrictions.
        /// Must return null if the prototype id is unknown.
        /// </summary>
        IEnumerable<ITilePlacementRule> GetRules(string protoId);
    }
}