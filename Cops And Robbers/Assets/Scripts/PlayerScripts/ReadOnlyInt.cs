using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Me.DerangedSenators.CopsAndRobbers
{
    public class ReadOnlyInt
    {
        private static bool writeComplete;
        private static int mValue;
        public static int roValue
        {
            get { return mValue; }

            set
            {
                if (!writeComplete)
                {
                    mValue = value;
                    writeComplete = true;
                }
            }
        }
    }
}