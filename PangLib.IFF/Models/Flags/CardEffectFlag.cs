namespace PangLib.IFF.Models.Flags
{
    /// <summary>
    /// This flag is handling different card effects
    /// </summary>
    public enum CardEffectFlag : ushort
    {
        /// <summary>
        /// No card effect
        /// </summary>
        None = 0,
        
        /// <summary>
        /// This card grants an experience bonus
        /// </summary>
        Experience = 1,
        
        /// <summary>
        /// This card grants a percentual pang increase
        /// </summary>
        PercentPang = 2,
        
        /// <summary>
        /// This card grants a percentual experience increase
        /// </summary>
        PercentExperience = 3,
        
        /// <summary>
        /// This card adds a fixed pang bonus
        /// </summary>
        Pang = 4,
        
        /// <summary>
        /// This card increases the Power statistic
        /// </summary>
        Power = 5,
        
        /// <summary>
        /// This card increases the Control statistic
        /// </summary>
        Control = 6,
        
        /// <summary>
        /// This card increases the Accuracy statistic
        /// </summary>
        Accuracy = 7,
        
        /// <summary>
        /// This card increases the Spin statistic
        /// </summary>
        Spin = 8,
        
        /// <summary>
        /// This card increases the Curve statistic
        /// </summary>
        Curve = 9,
        
        /// <summary>
        /// This card increases the Power shot gauge at the beginning of a match
        /// </summary>
        StartingGauge = 10,
        
        /// <summary>
        /// TODO: Figure out what this effect does again
        /// </summary>
        Inventory = 11
    }
}
