//
// Copyright (c) 2014 Fabio Biselli - fabio.biselli.80@gmail.com
//
// This software is provided 'as-is', without any express or implied
// warranty. In no event will the authors be held liable for any damages
// arising from the use of this software.
//
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
//    1. The origin of this software must not be misrepresented; you must not
//    claim that you wrote the original software. If you use this software
//    in a product, an acknowledgment in the product documentation would be
//    appreciated but is not required.
//
//    2. Altered source versions must be plainly marked as such, and must not be
//    misrepresented as being the original software.
//
//    3. This notice may not be removed or altered from any source
//    distribution.
//


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

        public static int Max(int a, int b)
        {
            if (a >= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public static int Min(int a, int b)
        {
            if (a > b)
            {
                return b;
            }
            else
            {
                return a;
            }
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
