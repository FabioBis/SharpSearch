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
        public int value;
        public MiniMax type;


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


        public void SetValue(int value)
        {
            this.value = value;
        }


        public int GetValue()
        {
            return this.value;
        }

    }
}
