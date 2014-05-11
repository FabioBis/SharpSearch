using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSearch
{
    /// <summary>
    /// Defines a constant to identify the type of minimax agent.
    /// An agent can be Min (the opponent) or Max (the IA agent).
    /// </summary>
    public enum MiniMax
    {
        Min,
        Max

    }

    /// <summary>
    /// A superclass for any decision class.
    /// 
    /// Any instance of a decision class must contains an implementation.
    /// </summary>
    public abstract class Decision
    {
        Object impl;

        public Decision(Object obj)
        {
            impl = obj;
        }
        
        public Object GetImpl()
        {
            return impl;
        }
    }

    /// <summary>
    /// The minimax decision class.
    /// 
    /// Any instance of minimax decision must contains the type (Min or Max)
    /// and a ranking value for the related type.
    /// </summary>
    public class MinMaxDecision : Decision
    {
        // The ranking value of this decision.
        public int value;
        // The type of the decision (Min or Max).
        public MiniMax type;

        // Constructors.
        public MinMaxDecision(Object obj, MiniMax type)
            : base(obj)
        {
            value = 0;
            this.type = type;
        }


        public MinMaxDecision(Object obj, MiniMax type, int value)
            : base(obj)
        {
            this.value = value;
            this.type = type;
        }


        /// <summary>
        /// Setter method for the decision ranking value.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(int value)
        {
            this.value = value;
        }


        /// <summary>
        /// getter method for the decision ranking value.
        /// </summary>
        /// <returns></returns>
        public int GetValue()
        {
            return this.value;
        }

    }
}
